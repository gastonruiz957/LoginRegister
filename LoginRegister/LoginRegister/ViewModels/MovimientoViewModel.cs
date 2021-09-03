using LoginRegister.Models;
using LoginRegister.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoginRegister.ViewModels
{
   public class MovimientoViewModel: BaseMovimientoViewModel
    {
        public Command cmdLoadMov { get; }
        public ObservableCollection<MovimientoModel> MovimientoModels { get; }

        public Command cmdAddMov { get; set; }
        public Command ProductTappedEdit { get; }
        public Command UserTappedDelete { get; }
        public MovimientoViewModel(INavigation _navigation)
        {
            cmdLoadMov = new Command(async () => await ExecuteLoadUserCommand());
            MovimientoModels = new ObservableCollection<MovimientoModel>();
            cmdAddMov = new Command(OnAddUser);
            ProductTappedEdit = new Command<MovimientoModel>(OnEditUser);
            UserTappedDelete = new Command<MovimientoModel>(OnDeleteUser);
            Navigation = _navigation;
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
        async Task ExecuteLoadUserCommand()
        {
            IsBusy = true;
            try
            {
                MovimientoModels.Clear();
                var userList = await App.MovService.GetMovimientoAsync();
                foreach (var user in userList)
                {
                    MovimientoModels.Add(user);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsBusy = false;
            }

        }
        private void OnAddUser(object obj)
        {
            //App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
            App.Current.MainPage = new NavigationPage(new RegisterMovimientoPage());
        }
        private async void OnEditUser(MovimientoModel user)
        {
            await Navigation.PushAsync(new NavigationPage(new RegisterMovimientoPage(user)));
        }
        private async void OnDeleteUser(MovimientoModel mov)
        {
            if (mov == null)
            {
                return;
            }
            await App.MovService.DeleteMovimientoAsync(mov.Id);
            await ExecuteLoadUserCommand();
        }
    }
}

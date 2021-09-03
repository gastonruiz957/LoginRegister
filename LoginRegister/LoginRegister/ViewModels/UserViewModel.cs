using LoginRegister.Models;
using LoginRegister.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoginRegister.ViewModels
{
    public class UserViewModel : BaseUserViewModel
    {
        public Command cmdLoadUser { get; }
        public ObservableCollection<UserModel> UserModels { get; }
        
        public Command cmdAddUser { get; set; }
        public Command ProductTappedEdit { get; }
        public Command UserTappedDelete { get; }
        public UserViewModel(INavigation _navigation)
        {
            cmdLoadUser = new Command(async () => await ExecuteLoadUserCommand());
            UserModels = new ObservableCollection<UserModel>();
            cmdAddUser = new Command(OnAddUser);
            ProductTappedEdit = new Command<UserModel>(OnEditUser);
            UserTappedDelete = new Command<UserModel>(OnDeleteUser);
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
                UserModels.Clear();
                var userList = await App.UserService.GetUserAsync();
                foreach (var user in userList)
                {
                    UserModels.Add(user);
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
            App.Current.MainPage.Navigation.PushAsync(new RegisterPage());

        }
        private async void OnEditUser(UserModel user)
        {
            await Navigation.PushAsync(new RegisterPage(user));
        }
        private async void OnDeleteUser(UserModel user)
        {
            if (user == null)
            {
                return;
            }
            await App.UserService.DeleteUserAsync(user.UserId);
            await ExecuteLoadUserCommand();
        }
    }
}

using LoginRegister.Models;
using LoginRegister.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LoginRegister.ViewModels
{
    public class RegisterMovimientoViewModel:BaseMovimientoViewModel
    {
        public Command cmdRegister { get; }
        public Command cmdCancel { get; }

        public RegisterMovimientoViewModel()
        {
            cmdRegister = new Command(OnSave);
            cmdCancel = new Command(OnCancel);
            this.PropertyChanged += (_, __) => cmdRegister.ChangeCanExecute();
            MovimientoModel = new MovimientoModel();
        }

        private void OnCancel(object obj)
        {
            //App.Current.MainPage.Navigation.PushAsync(new MovimientoHomePage());
            App.Current.MainPage = new NavigationPage(new MainPage());
        }

        private async void OnSave()
        {
            
            var mov = MovimientoModel;
            await App.MovService.AddMovimientoAsync(mov);
            App.Current.MainPage = new NavigationPage(new MainPage());
            //await App.Current.MainPage.Navigation.PushAsync(new MovimientoHomePage());
            //await Shell.Current.GoToAsync("..");
        }

    }
}

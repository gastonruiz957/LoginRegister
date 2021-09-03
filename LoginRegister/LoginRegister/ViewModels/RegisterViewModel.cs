using LoginRegister.Models;
using LoginRegister.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace LoginRegister.ViewModels
{
    public class RegisterViewModel: BaseUserViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command cmdRegister { get; set; }
        public Command cmdCancel { get; }

        public RegisterViewModel()
        {
            cmdRegister = new Command(OnSave);
            cmdCancel = new Command(OnCancel);
            this.PropertyChanged += (_, __) => cmdRegister.ChangeCanExecute();
            UserModel = new UserModel();

        }

        private void OnCancel(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        private async void OnSave(object obj)
        {
            var user = UserModel;
            if (user.Usuario != null && user.Usuario != "" && user.Password != null  && user.Password != "" && user.Legajo != null && user.Legajo != "" && user.Sector != null && user.Sector != "")
            {
                cmdRegister.ChangeCanExecute();

                await App.UserService.AddUserAsync(user);
                App.Current.MainPage = new NavigationPage(new LoginPage());
/*                await App.Current.MainPage.Navigation.PushAsync(new LoginPage())*/;
            }
            else
            {
                RegisterMessage = "Todos los campos son requeridos";
                TurnRegisterMessage = true;
            }
        }
        private string registerMessage;
        public string RegisterMessage
        {
            get { return registerMessage; }
            set
            {
                registerMessage = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RegisterMessage"));

            }
        }

        private bool turnRegisterMessage = false;
        public bool TurnRegisterMessage
        {
            get { return turnRegisterMessage; }
            set
            {
                turnRegisterMessage = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TurnRegisterMessage"));
            }
        }
    }
}

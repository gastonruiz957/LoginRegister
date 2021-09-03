using LoginRegister.Models;
using LoginRegister.Resources;
using LoginRegister.Services;
using LoginRegister.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace LoginRegister.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command cmdLogin { get; set; }
        public Command cmdGoToRegister { get; set; }
        public Command cmdGoToUserList { get; set; }
        public UserModel user { get; set; }


        public LoginViewModel()
        {
            cmdLogin = new Command(gotoHomePage, LoginAllowed);
            cmdGoToRegister = new Command(gotoRegisterPage);
            cmdGoToUserList = new Command(gotoUserPage);
        }


        private void gotoUserPage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new UserPage());
        }

        private void gotoRegisterPage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

        private async void gotoHomePage(object obj)
       {

            if (await App.UserService.Login(userName,Password))/*(Ilog.login(UserName, Password))*/
            {
                Application.Current.Properties["nombre"] = userName;               
                await Application.Current.SavePropertiesAsync();
                user = await App.UserService.GetUserByUserNameAsync(userName);
                UserAuth.Usuario = user.Usuario;
                UserAuth.UserId = user.UserId;
                UserAuth.Sector = user.Sector;
                UserAuth.Legajo = user.Legajo;

                App.Current.MainPage = new NavigationPage(new MainPage());
                //await App.Current.MainPage.Navigation.PushAsync(new MovimientoHomePage());
            }
            else 
            {
               
                LoginMessage = "Usuario o Contraseña Incorrectos";
                TurnLoginMessage = true;
            }
            
        }
        //----------------------------------------------
        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UserName"));
                cmdLogin.ChangeCanExecute();
            }
        }

        private string password;
        public string Password 
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));
                cmdLogin.ChangeCanExecute();

            }
        }
        private string loginMessage;
        public string LoginMessage
        {
            get { return loginMessage; }
            set
            {
                loginMessage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LoginMessage"));

            }
        }

        private bool turnLoginMessage = false;
        public bool TurnLoginMessage
        {
            get { return turnLoginMessage; }
            set {
                turnLoginMessage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TurnLoginMessage"));
            }
        }
        public bool LoginAllowed(object obj) =>
        !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(password);

    }

}
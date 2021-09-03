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
    public class HomeMovimientoViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //public Command cmdMovimiento { get; set; }
        public Command cmdGoToRegister { get; set; }
        public Command cmdGoToMovList { get; set; }
        public Command cmdGoToLogin { get; set; }
        public Command cmdGoToUserList { get; set; }
        public string Usuario { get; set; }
        
        //IMovimientoService Ilog = DependencyService.Get<IMovimientoService>();

        public HomeMovimientoViewModel()
        {
            //cmdMovimiento = new Command(gotoHomePage);
            cmdGoToRegister = new Command(gotoRegisterPage);
            cmdGoToMovList = new Command(gotoMovPage);
            cmdGoToLogin = new Command(gotoLoginPage);
            cmdGoToUserList = new Command(gotoUserPage);
            /*Usuario = Application.Current.Properties["nombre"] as string;*/
            Usuario = UserAuth.Usuario.ToUpper();
        }

        private void gotoUserPage(object obj)
        {
                App.Current.MainPage.Navigation.PushAsync(new UserPage());
        }

        private void gotoLoginPage(object obj)
        {
            App.Current.MainPage = new NavigationPage(new LoginPage());
            //App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        private void gotoMovPage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new MovimientosCargadosPage());
        }

        private void gotoRegisterPage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new RegisterMovimientoPage());
        }

        // private void gotoHomePage(object obj)
        //{

        //     if (Ilog.login(UserName, Password))/*(Ilog.login(UserName, Password))*/
        //     {
        //         App.Current.MainPage.Navigation.PushAsync(new HomePage());
        //     }
        //     else 
        //     {
        //         LoginMessage = "Usuario o Contraseña Incorrectos";
        //         TurnLoginMessage = true;
        //     }

        // }
        // //----------------------------------------------
        //private string saveUser;
        //public string SaveUser
        //{
        //    get { return saveUser; }
        //    set
        //    {
        //        saveUser = value;
        //        _ = App.Current.Properties["nombre"] as string;
        //    }
        //
        public string saveUser { get; set; }

        //private string password;
        //public string Password 
        //{
        //    get { return password; }
        //    set
        //    {
        //        password = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));


        //    }
        //}
        //private string loginMessage;
        //public string LoginMessage
        //{
        //    get { return loginMessage; }
        //    set
        //    {
        //        loginMessage = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LoginMessage"));
        //    }
        //}

        //private bool turnLoginMessage = false;
        //public bool TurnLoginMessage
        //{
        //    get { return turnLoginMessage; }
        //    set {
        //        turnLoginMessage = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TurnLoginMessage"));
        //    }
        //}
    }
}

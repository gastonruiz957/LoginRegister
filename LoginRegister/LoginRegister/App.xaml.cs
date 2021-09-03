using LoginRegister.Services;
using LoginRegister.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginRegister
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDet { get; set; }

        static UserService _userService;
        public static UserService UserService
        {
            get
            {
                if (_userService == null)
                {
                    _userService = new UserService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "User.db3"));
                }
                return _userService;
            }
        }
        static MovimientoService _movService;
        public static MovimientoService MovService
        {
            get
            {
                if (_movService == null)
                {
                    _movService = new MovimientoService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "User.db3"));
                }
                return _movService;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

using LoginRegister.Models;
using LoginRegister.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginRegister.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public UserModel UserModel { get; set; }
        public LoginPage()
        {
            SetValue(NavigationPage.BackButtonTitleProperty, false);
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}
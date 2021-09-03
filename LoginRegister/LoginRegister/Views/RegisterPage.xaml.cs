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
    public partial class RegisterPage : ContentPage
    {
        //RegisterViewModel registerViewModel;
        public UserModel UserModel { get; set; }
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel();
        }
        public RegisterPage(UserModel userModel)
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel();

            if (userModel != null)
            {
                ((RegisterViewModel)BindingContext).UserModel = userModel;
            }
        }
    }
}
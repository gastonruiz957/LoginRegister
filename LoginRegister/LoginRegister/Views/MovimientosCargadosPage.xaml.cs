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
    public partial class MovimientosCargadosPage : ContentPage
    {
        MovimientoViewModel movimientoViewModel;
        public MovimientosCargadosPage()
        {
            InitializeComponent();
            BindingContext = movimientoViewModel = new MovimientoViewModel(Navigation);
            //BindingContext = new UserViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            movimientoViewModel.OnAppearing();
        }
    }
}
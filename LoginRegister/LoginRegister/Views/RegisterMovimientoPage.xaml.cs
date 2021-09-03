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
    public partial class RegisterMovimientoPage : ContentPage
    {
        public MovimientoModel MovimientoModel { get; set; }
        public RegisterMovimientoPage()
        {
            InitializeComponent();
            BindingContext = new RegisterMovimientoViewModel();
        }
        public RegisterMovimientoPage(MovimientoModel movimientoModel)
        {
            InitializeComponent();
            BindingContext = new RegisterMovimientoViewModel();
            if (movimientoModel != null)
            {
                ((RegisterMovimientoViewModel)BindingContext).MovimientoModel = movimientoModel;
            }

        }
    }
}
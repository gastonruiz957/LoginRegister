﻿using LoginRegister.ViewModels;
using LoginRegister.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginRegister
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {

        public Master()
        {
            InitializeComponent();
            BindingContext = new HomeMovimientoViewModel();
            //cmdGoToRegister = new Command(gotoRegisterPage);
            //cmdGoToMovList = new Command(gotoMovPage);
        }

        
    }
}
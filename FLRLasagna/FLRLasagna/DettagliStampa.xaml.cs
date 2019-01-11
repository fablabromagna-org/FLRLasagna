using System;
using System.Collections.Generic;
using FLRLasagna.Models;
using Xamarin.Forms;

namespace FLRLasagna
{
    public partial class DettagliStampa : ContentPage
    {
        public DettagliStampa()
        {
            InitializeComponent();
        }

        public DettagliStampa(RecordStampa r) 
            : this()
        {
            BindingContext = r;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using FLRLasagna.Models;

namespace FLRLasagna
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            image.Source = ImageSource.FromResource("FLRLasagna.Images.LogoFabLab.png");
        }

        async void ApriElencoLasagne(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ElencoLasagne());
        }

        async void ApriElencoStampe(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ElencoStampe());
        }

    }
}

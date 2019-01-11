using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

using FLRLasagna.Models;

namespace FLRLasagna
{
    public partial class ElencoLasagne : ContentPage
    {
        public ElencoLasagne()
        {
            InitializeComponent();
        }

        public async void LoadData()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string response = await client.GetStringAsync(
                                 "https://flr.azurewebsites.net/api/Lasagna");

                    var result = JsonConvert.DeserializeObject
                                 <IEnumerable<Lasagna>>(response);

                    lvDati.ItemsSource = result;
                }
            }
            catch (Exception err)
            {
                await DisplayAlert("Ocio!!", err.Message, "Ok");
            }
        }

        void MaggioriInfo(object sender, System.EventArgs e)
        {
            DisplayAlert("Info", "Hai chiesto maggiori info...", "OK");
        }

        void Ordina(object sender, System.EventArgs e)
        {
            DisplayAlert("Compra", "Hai comprato una lasagna...", "OK");
        }
    }
}

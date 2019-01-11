using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using Newtonsoft.Json;
using Xamarin.Forms;
using FLRLasagna.Models;

namespace FLRLasagna
{
    public partial class ElencoStampe : ContentPage
    {
        public ElencoStampe()
        {
            InitializeComponent();
            LoadData();
        }

        async void LoadData()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string response = await client.GetStringAsync(
                                 "https://flr.azurewebsites.net/api/stampe");

                    var result = JsonConvert.DeserializeObject
                                 <IEnumerable<RecordStampa>>(response).ToList();

                    result.RemoveAt(0);
                    lvStampe.ItemsSource = result;
                }
            }
            catch (Exception err)
            {
                await DisplayAlert("Ocio!!", err.Message, "Ok");
            }
        }
    }
}

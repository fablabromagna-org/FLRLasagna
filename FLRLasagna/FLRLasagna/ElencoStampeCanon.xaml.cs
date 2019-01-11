using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FLRLasagna.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace FLRLasagna
{
    public partial class ElencoStampeCanon : ContentPage
    {
        public ElencoStampeCanon()
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

        async void VisualizzaDettagli(object sender, System.EventArgs e)
        {
            MenuItem m = sender as MenuItem;
            if (m != null)
            {
                RecordStampa r = m.CommandParameter as RecordStampa;
                if (r != null)
                {
                    string strMessaggio = r.ToString();
                    await Navigation.PushAsync(new DettagliStampa(r));
                }
            }
        }

        async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            RecordStampa r = e.Item as RecordStampa;
            if (r != null)
            {
                string strMessaggio = r.ToString();
                await Navigation.PushAsync(new DettagliStampa(r));
            }
        }
    }
}

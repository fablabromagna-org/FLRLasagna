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
        }

        async void Go_Clicked(object sender, System.EventArgs e)
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

        async void Go_Clicked2(object sender, System.EventArgs e)
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

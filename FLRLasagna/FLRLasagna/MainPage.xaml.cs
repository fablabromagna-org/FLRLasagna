using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace FLRLasagna
{
    public partial class MainPage : ContentPage
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
    }

    public class Lasagna
    {
        public string Nome { get; set; }
        public string Peso { get; set; }
        public string UrlImmagine { get; set; }
    }

}

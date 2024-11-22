using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace azizapp.home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class allNotificatoin : ContentPage
    {
        private readonly HttpClient _client = new HttpClient();
        private const string ApiUrl = "http://10.0.2.2:8090/api/collections/Log_temperature/records";

        public allNotificatoin()
        {
            InitializeComponent();
            LoadTemperatureLogs();
        }

        private async void LoadTemperatureLogs()
        {
            try
            {
                var response = await _client.GetStringAsync(ApiUrl);
                var logTemperatureResponse = JsonConvert.DeserializeObject<LogTemperatureApiResponse>(response);

                // Trier les logs par date de création décroissante
                var sortedLogs = logTemperatureResponse.items.OrderByDescending(log => log.created).ToList();

                TemperatureLogListView.ItemsSource = sortedLogs;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load temperature logs: {ex.Message}", "OK");
            }
        }
    }

    public class LogTemperatureApiResponse
    {
        public List<LogTemperature> items { get; set; }
    }

    public class LogTemperature
    {
        public string Id_terminal { get; set; }
        public string Nom_terminal { get; set; }
        public string Type_terminal { get; set; }
        public string Valeur_temperature { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public string id { get; set; }
    }
}

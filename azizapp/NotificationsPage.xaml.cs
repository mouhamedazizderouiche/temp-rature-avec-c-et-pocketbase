using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace azizapp
{
    public partial class NotificationsPage : ContentPage
    {
        private const string PocketBaseSSEUrl = "http://10.0.2.2:8090/api/realtime"; // URL de l'API SSE de PocketBase
        private HttpClient _httpClient;
        private ObservableCollection<Notification> _notifications;

        public NotificationsPage()
        {
            InitializeComponent();
            _notifications = new ObservableCollection<Notification>();
            NotificationsListView.ItemsSource = _notifications;
            _httpClient = new HttpClient();

            StartListeningForNotifications();
        }

        private async void StartListeningForNotifications()
        {
            while (true) // Boucle pour reconnexion automatique
            {
                try
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, PocketBaseSSEUrl);
                    var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                    if (response.IsSuccessStatusCode)
                    {
                        var stream = await response.Content.ReadAsStreamAsync();
                        using (var reader = new System.IO.StreamReader(stream))
                        {
                            while (!reader.EndOfStream)
                            {
                                var line = await reader.ReadLineAsync();
                                if (!string.IsNullOrWhiteSpace(line))
                                {
                                    ProcessSSEMessage(line);
                                }
                            }
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", $"Failed to connect to SSE endpoint: {response.ReasonPhrase}", "OK");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
                }

                // Attendre avant de tenter une reconnexion
                await Task.Delay(5000);
            }
        }

        private void ProcessSSEMessage(string message)
        {
            try
            {
                if (message.StartsWith("data:"))
                {
                    var json = message.Substring("data:".Length).Trim();
                    var notificationData = JsonConvert.DeserializeObject<NotificationData>(json);

                    if (notificationData?.Record != null)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            var notification = new Notification
                            {
                                // Vérifie si 'Contenu' et 'Created' sont null
                                Message = notificationData.Record.Contenu ?? "No Content", // Valeur par défaut si null
                                CreatedAt = notificationData.Record.Created ?? "Unknown Date" // Valeur par défaut si null
                            };
                            _notifications.Add(notification);
                        });
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            await DisplayAlert("Warning", "Received notification data is missing record information.", "OK");
                        });
                    }
                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await DisplayAlert("Warning", "Received message does not start with 'data:'.", "OK");
                    });
                }
            }
            catch (Exception ex)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Error", $"Error processing SSE message: {ex.Message}", "OK");
                });
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _httpClient?.Dispose();
        }
    }

    public class Notification
    {
        public string Message { get; set; }
        public string CreatedAt { get; set; }
    }

    public class NotificationData
    {
        public string Action { get; set; }
        public NotificationRecord Record { get; set; }
    }

    public class NotificationRecord
    {
        public string Id { get; set; }
        public string CollectionId { get; set; }
        public string CollectionName { get; set; }
        public string Created { get; set; }
        public string Updated { get; set; }
        public string Contenu { get; set; }
        public string Date { get; set; }
        public string IdTerminal { get; set; }
        public string[] IdUtilisateur { get; set; }
    }
}

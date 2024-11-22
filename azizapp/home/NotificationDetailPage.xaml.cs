using azizapp.messs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static azizapp.MainPage;

namespace azizapp.home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationDetailPage : ContentPage
    {
        public event EventHandler MarkAsReadClicked;
        private readonly HttpClient _client = new HttpClient();
        public event EventHandler NotificationMarkedAsRead;


        public NotificationDetailPage(NotificationDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
          
        }

        private async void MarkAsReadButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as NotificationDetailViewModel;
            var selectedNotificationId = viewModel?.NotificationId;

            if (selectedNotificationId == null)
            {
                await DisplayAlert("Error", "Failed to get the selected notification ID.", "OK");
                return;
            }

            var userId = SessionManager.CurrentUserId;
            var isAdmin = SessionManager.UserType == "Admin"; // Check if the user is an admin

            try
            {
                var apiUrl = $"http://10.0.2.2:8090/api/collections/notification_utilisateur/records";
                var response = await _client.GetAsync(apiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Error", "Failed to fetch notification utilisateur records.", "OK");
                    return;
                }

                var content = await response.Content.ReadAsStringAsync();
                var notifications = JsonConvert.DeserializeObject<NotificationUtilisateurResponse>(content);

                // Find the notification for the current user or admin
                var notification = notifications.items.FirstOrDefault(n =>
                    (isAdmin && n.id_admin == userId && n.id_notification == selectedNotificationId) || // For admin
                    (!isAdmin && n.id_utilisateur == userId && n.id_notification == selectedNotificationId)); // For regular user

                if (notification == null)
                {
                    await DisplayAlert("Error", "Notification not found.", "OK");
                    return;
                }

                notification.lue = true;
                var json = JsonConvert.SerializeObject(notification);
                var patchUrl = $"http://10.0.2.2:8090/api/collections/notification_utilisateur/records/{notification.id}";
                var patchContent = new StringContent(json, Encoding.UTF8, "application/json");
                var patchResponse = await _client.PatchAsync(patchUrl, patchContent, CancellationToken.None);

                if (!patchResponse.IsSuccessStatusCode)
                {
                    await DisplayAlert("Error", "Failed to update notification utilisateur.", "OK");
                    return;
                }

                if (viewModel.Notification != null)
                {
                    viewModel.Notification.IsUnread = false;
                }

                await DisplayAlert("Success", "Notification utilisateur updated successfully.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
        public async void ReplyButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new createmessage());
        }

        public class NotificationUtilisateur
        {
            [JsonProperty("id_utilisateur")]
            public string id_utilisateur { get; set; }

            [JsonProperty("lue")]
            public bool lue { get; set; }

            [JsonProperty("date_lue")]
            public DateTime date_lue { get; set; }

            [JsonProperty("id_notification")]
            public string id_notification { get; set; }

            [JsonProperty("id")]
            public string id { get; set; }
            [JsonProperty("id_admin")]
            public string id_admin { get; set; }
        }

        public class NotificationUtilisateurResponse
        {
            [JsonProperty("items")]
            public List<NotificationUtilisateur> items { get; set; }
        }


        public class NotificationDetailViewModel : INotifyPropertyChanged
        {
            private Notification _notification;

            public Notification Notification
            {
                get { return _notification; }
                set
                {
                    if (_notification != value)
                    {
                        _notification = value;
                        OnPropertyChanged(nameof(Notification));
                    }
                }
            }

            public string NotificationId { get; set; }
            public string NotificationTitle { get; set; }
            public string NotificationContent { get; set; }
            public DateTime NotificationDate { get; set; }

            public NotificationDetailViewModel(Notification notification)
            {
                Notification = notification;
                NotificationId = notification?.Id;
                NotificationTitle = "Notification Details";
                NotificationContent = notification?.Content;
                NotificationDate = notification?.Date ?? DateTime.Now;
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = content
            };

            var response = await client.SendAsync(request, cancellationToken);
            return response;
        }
    }



}

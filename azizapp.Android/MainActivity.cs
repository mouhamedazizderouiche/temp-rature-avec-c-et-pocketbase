using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Plugin.LocalNotification;
using Android.Content;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using Plugin.FirebasePushNotification;

namespace azizapp.Droid
{
    [Activity(Label = "Scapcb", Icon = "@drawable/logoApp", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private readonly HttpClient _client = new HttpClient();
        private const string PocketBaseUrl = "http://10.0.2.2:8090";
        private int _storedNotificationCount = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            OxyPlot.Xamarin.Forms.Platform.Android.PlotViewRenderer.Init();
            LocalNotificationCenter.CreateNotificationChannel();

            LoadApplication(new App());

            LocalNotificationCenter.NotifyNotificationTapped(Intent);

            FirebasePushNotificationManager.ProcessIntent(this, Intent);
            Device.BeginInvokeOnMainThread(async () =>
            {
                _storedNotificationCount = await GetNotificationCountAsync();
            });

            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await CheckForNewNotificationsAsync();
                });
                return true;
            });
            FirebasePushNotificationManager.NotificationActivityType = typeof(MainActivity);
            #if DEBUG
            FirebasePushNotificationManager.Initialize(this, true);
#else
            FirebasePushNotificationManager.Initialize(this,false);
#endif

            CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;
            var token = CrossFirebasePushNotification.Android.Token;

            CrossFirebasePushNotification.Android.OnNotificationReceived += async (s, p) =>
            {
                var notificationRequest = new NotificationRequest
                {
                    NotificationId = new Random().Next(),
                    Title = "New Notification from firebase",
                    Description = "Exemple",
                    ReturningData = JsonConvert.SerializeObject(p.Data),
                    Schedule = { NotifyTime = DateTime.Now }
                };
                await LocalNotificationCenter.Current.Show(notificationRequest);
            };
            //Handle notification when app is closed here
            CrossFirebasePushNotification.Current.OnNotificationReceived += async (s, p) =>
            {
                var notificationRequest = new NotificationRequest
                {
                    NotificationId = new Random().Next(),
                    Title = "New Notification from firebase",
                    Description = "Exemple",
                    ReturningData = JsonConvert.SerializeObject(p.Data),
                    Schedule = { NotifyTime = DateTime.Now }
                };
                await LocalNotificationCenter.Current.Show(notificationRequest);
            };
        }
        private void Current_OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Token: {e.Token}");
        }
        private async Task<int> GetNotificationCountAsync()
        {
            var response = await _client.GetStringAsync($"{PocketBaseUrl}/api/collections/notification/records");
            var notifications = JsonConvert.DeserializeObject<NotificationsApiResponse>(response);
            return notifications.Items.Count;
        }

        private async Task CheckForNewNotificationsAsync()
        {
            var currentNotificationCount = await GetNotificationCountAsync();
            if (currentNotificationCount > _storedNotificationCount)
            {
                await PushNewNotificationsAsync(currentNotificationCount - _storedNotificationCount);
                _storedNotificationCount = currentNotificationCount;
            }
        }

        private async Task PushNewNotificationsAsync(int newNotificationCount)
        {
            try
            {
                var response = await _client.GetStringAsync($"{PocketBaseUrl}/api/collections/notification/records");
                var notifications = JsonConvert.DeserializeObject<NotificationsApiResponse>(response);
                var newNotifications = notifications.Items.OrderByDescending(n => n.Date).Take(newNotificationCount);

                foreach (var notification in newNotifications)
                {
                    var notificationRequest = new NotificationRequest
                    {
                        NotificationId = new Random().Next(),
                        Title = "Nouvelle Notification",
                        Description = $"Le valeur de température : {notification.Contenu} °C, Date : {notification.Date.ToString("g")}", 
                        Schedule = { NotifyTime = DateTime.Now.AddSeconds(1) }
                    };
                    Console.WriteLine($"Showing notification: {notificationRequest.Description}");
                    await LocalNotificationCenter.Current.Show(notificationRequest);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error pushing new notifications: {ex.Message}");
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnNewIntent(Intent intent)
        {
            LocalNotificationCenter.NotifyNotificationTapped(intent);
            base.OnNewIntent(intent);
        }
    }


    public class NotificationItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("created")]
        public DateTime Date { get; set; }
    }

    public class Notification
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("contenu")]
        public string Contenu { get; set; }

        [JsonProperty("created")]
        public DateTime Date { get; set; }

        // Vous pouvez ajouter d'autres propriétés si nécessaire
    }

    public class NotificationsApiResponse
    {
        public List<Notification> Items { get; set; }
    }

}

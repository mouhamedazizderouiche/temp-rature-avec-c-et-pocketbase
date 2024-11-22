using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static azizapp.home.NotificationDetailPage;
using static azizapp.MainPage;


namespace azizapp.home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class notification : ContentPage
    {
        private readonly HttpClient _client = new HttpClient();
        private const string PocketBaseUrl = "http://10.0.2.2:8090";
        private int _previousNotificationCount = 0;
        public bool viss = false;

        public event PropertyChangedEventHandler PropertyChanged;


        public List<Notification> Notifications { get; set; } = new List<Notification>();
        public List<User> Users { get; set; } = new List<User>();
        public List<NotificationUtilisateur> NotificationUtilisateurs { get; set; } = new List<NotificationUtilisateur>();

        private ObservableCollection<Notification> _notifications = new ObservableCollection<Notification>();
        public ObservableCollection<Notification> notifications
        {
            get { return _notifications; }
            set
            {
                if (_notifications != value)
                {
                    _notifications = value;
                    OnPropertyChanged(nameof(notifications));
                }
            }
        }
        private bool _showNoNotificationMessage;
        public bool ShowNoNotificationMessage
        {
            get { return _showNoNotificationMessage; }
            set
            {
                if (_showNoNotificationMessage != value)
                {
                    _showNoNotificationMessage = value;
                    OnPropertyChanged(nameof(ShowNoNotificationMessage));
                }
            }
        }


        public notification()
        {
            InitializeComponent();
            BindingContext = this;
            
            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await LoadNotificationsAsync();
                });
                return true;
            });
           
            var viewModel = new NotificationDetailPage.NotificationDetailViewModel(new Notification());
            var detailPage = new NotificationDetailPage(viewModel);
            LoadDataAsync();
            _previousNotificationCount = Notifications.Count;
        }




        private async Task LoadDataAsync()
        {
            try
            {
                await LoadNotificationsAsync();
                await LoadUsersAsync();
                await CreateNotificationsForAllUsers();
                



                NotificationUtilisateurs = await LoadNotificationUtilisateursAsync();

                
                foreach (var notification in Notifications)
                {
                    // Rechercher la notification utilisateur correspondante
                    var correspondingNotification = NotificationUtilisateurs.FirstOrDefault(nu => nu.id_notification == notification.Id && nu.id_utilisateur == SessionManager.CurrentUserId);
                    var correspondingNotificationAdmin = NotificationUtilisateurs.FirstOrDefault(nu => nu.id_notification == notification.Id && nu.id_admin == SessionManager.CurrentUserId);


                    if (correspondingNotification != null)
                    {
                        notification.IsUnread = !correspondingNotification.lue;
                    }
                    else
                    {
                        notification.IsUnread = !correspondingNotificationAdmin.lue;
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        private List<Notification> ConvertToNotifications(List<NotificationItem> notificationItems)
        {
            List<Notification> notifications = new List<Notification>();

            foreach (var item in notificationItems)
            {
                Notification notification = new Notification
                {
                    Id = item.Id,
                    Content = item.Content,
                    Date = item.Date

                };

                notifications.Add(notification);
            }

            return notifications;
        }


        private async Task LoadNotificationsAsync()
        {
            try
            {
                string apiUrl = $"{PocketBaseUrl}/api/collections/notification/records";
                var response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var notificationsApiResponse = JsonConvert.DeserializeObject<NotificationsApiResponse>(content);
                    Notifications = ConvertToNotifications(notificationsApiResponse.Items);
                    notificationListView.ItemsSource = Notifications;
                    ShowNoNotificationMessage = Notifications.Count == 0;

                    // Mettez à jour l'état de chaque notification
                    foreach (var notification in Notifications)
                    {
                        var correspondingNotification = NotificationUtilisateurs.FirstOrDefault(nu => nu.id_notification == notification.Id && nu.id_utilisateur == SessionManager.CurrentUserId);
                        var correspondingNotificationAdmin = NotificationUtilisateurs.FirstOrDefault(nu => nu.id_notification == notification.Id && nu.id_admin == SessionManager.CurrentUserId);


                        if (correspondingNotification != null)
                        {
                            notification.IsUnread = !correspondingNotification.lue;
                        }
                        else
                        {
                            notification.IsUnread = !correspondingNotificationAdmin.lue;
                        }
                    }

                    viss = Notifications.Count != 0;
                }
                else
                {
                    await DisplayAlert("Error", "Unable to retrieve notifications.", "OK");
                }
            }
            catch (Exception ex)
            {
            }
        }
        private async Task CheckAndLoadNotifications()
        {
            try
            {
                // Obtenir le nombre de notifications actuel
                var currentNotificationCount = Notifications.Count;

                // Vérifier s'il y a un nouveau nombre de notifications
                if (currentNotificationCount != _previousNotificationCount)
                {
                    // S'il y a de nouvelles notifications, recharger les données
                    await LoadDataAsync();

                    // Mettre à jour le nombre de notifications précédentes
                    _previousNotificationCount = currentNotificationCount;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred while checking and loading notifications: {ex.Message}", "OK");
            }
        }
        private async Task LoadUsersAsync()
        {
            try
            {
                string apiUrl = $"{PocketBaseUrl}/api/collections/Utilisateur/records";
                var response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var usersApiResponse = JsonConvert.DeserializeObject<UsersApiResponse>(content);
                    Users = usersApiResponse.Users;
                }
                else
                {
                    await DisplayAlert("Error", "Unable to retrieve users.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred while retrieving users: {ex.Message}", "OK");
            }
        }

        private async Task<List<AdminUser>> LoadAdminUsersAsync()
        {
            try
            {
                string apiUrl = $"{PocketBaseUrl}/api/collections/admin/records";
                var response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var adminApiResponse = JsonConvert.DeserializeObject<AdminApiResponse>(content);
                    return adminApiResponse.Items;
                }
                else
                {
                    await DisplayAlert("Error", "Unable to retrieve admin users.", "OK");
                    return new List<AdminUser>();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred while retrieving admin users: {ex.Message}", "OK");
                return new List<AdminUser>();
            }
        }

        public class AdminApiResponse
        {
            public int Page { get; set; }
            public int PerPage { get; set; }
            public int TotalItems { get; set; }
            public int TotalPages { get; set; }
            public List<AdminUser> Items { get; set; }
        }


        private async Task CreateNotificationsForAllUsers()
        {
            try
            {
                string apiUrl = $"{PocketBaseUrl}/api/collections/notification_utilisateur/records";

                // Charger les notifications utilisateur existantes
                var notificationUtilisateurs = await LoadNotificationUtilisateursAsync();

                // Charger les utilisateurs admin
                var adminUsers = await LoadAdminUsersAsync();

                // Combiner les utilisateurs et les utilisateurs admin
                var allUsers = Users.Concat(adminUsers.Select(admin => new User
                {
                    Id = admin.Id,
                    Nom = admin.Nom_admin,
                    Email = admin.Email,
                    IsAdmin = true
                })).ToList();

                foreach (var user in allUsers)
                {
                    foreach (var notification in Notifications)
                    {
                        // Vérifier si une notification utilisateur existe déjà pour cette paire utilisateur-notification
                        bool notificationExists = notificationUtilisateurs.Any(nu =>
                            (user.IsAdmin && nu.id_admin == user.Id && nu.id_notification == notification.Id) ||
                            (!user.IsAdmin && nu.id_utilisateur == user.Id && nu.id_notification == notification.Id)
                        );

                        if (!notificationExists)
                        {
                            var newNotification = new NotificationUtilisateur
                            {
                                id_utilisateur = user.IsAdmin ? null : user.Id,
                                id_admin = user.IsAdmin ? user.Id : null,
                                lue = false,
                                date_lue = DateTime.Now, // Utiliser la date actuelle
                                id_notification = notification.Id
                            };

                            var json = JsonConvert.SerializeObject(newNotification);
                            var content = new StringContent(json, Encoding.UTF8, "application/json");

                            var response = await _client.PostAsync(apiUrl, content);

                            if (!response.IsSuccessStatusCode)
                            {
                                await DisplayAlert("Error", $"Failed to create notification for user {user.Nom}", "OK");
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred while creating notifications: {ex.Message}", "OK");
            }
        }


        private async Task<List<NotificationUtilisateur>> LoadNotificationUtilisateursAsync()
        {
            try
            {
                string apiUrl = $"{PocketBaseUrl}/api/collections/notification_utilisateur/records";
                var response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var notificationUtilisateurApiResponse = JsonConvert.DeserializeObject<NotificationUserApiResponse>(content);
                    return notificationUtilisateurApiResponse.Items;
                }
                else
                {
                    return new List<NotificationUtilisateur>();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred while retrieving notification utilisateur records: {ex.Message}", "OK");
                return new List<NotificationUtilisateur>();
            }
        }

        // Correction pour l'erreur concernant l'absence de 'Id' dans 'NotificationUtilisateur'
        /*private async Task OnDeleteAllNotification(NotificationUtilisateur notification, EventArgs e)
        {
            bool isConfirmed = await DisplayAlert("Confirm Delete", "Are you sure you want to delete this notification?", "Yes", "No");
            if (!isConfirmed)
                return;

            try
            {
                string apiUrl = $"http://10.0.2.2:8090/api/collections/notification_utilisateur/records/{notification.id}";

                var response = await _client.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Success", "Notification deleted successfully.", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "Failed to delete the notification.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred while deleting the notification: {ex.Message}", "OK");
            }
        }

        // Correction pour l'erreur concernant l'absence de 'Items' dans 'NotificationUtilisateurResponse'
        private async Task DeleteNotificationsCreatedTwoDaysAgo()
        {
            try
            {
                var response = await _client.GetAsync("http://10.0.2.2:8090/api/collections/notification_utilisateur/records");
                if (!response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Error", "Failed to retrieve notification utilisateur.", "OK");
                    return;
                }

                var content = await response.Content.ReadAsStringAsync();
                var notificationsResponse = JsonConvert.DeserializeObject<NotificationUserApiResponse>(content);

                if (notificationsResponse?.Items == null)
                {
                    await DisplayAlert("Error", "No notifications found.", "OK");
                    return;
                }

                DateTime twoDaysAgo = DateTime.Now.AddDays(-2).Date;

                var notificationsToBeDeleted = notificationsResponse.Items
                    .Where(n => n.created.Date == twoDaysAgo)
                    .ToList();

                foreach (var notification in notificationsToBeDeleted)
                {
                    await OnDeleteAllNotification(notification, EventArgs.Empty);
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred while deleting notifications created two days ago: {ex.Message}", "OK");
            }
        }*/


        private async void OnNotificationTapped(object sender, EventArgs e)
        {
            var notification = (sender as View).BindingContext as Notification;
            if (notification != null)
            {
                var viewModel = new NotificationDetailPage.NotificationDetailViewModel(notification);
                var detailPage = new NotificationDetailPage(viewModel);
                await Navigation.PushAsync(detailPage);
            }
        }

    }

    // Définition des classes de réponse
    public class NotificationsApiResponse
    {
        [JsonProperty("items")]
        public List<NotificationItem> Items { get; set; }
    }
    public class NotificationItem
    {
        [JsonProperty("id")] // Assurez-vous que cette propriété correspond à l'ID dans votre API
        public string Id { get; set; }

        [JsonProperty("contenu")]
        public string Content { get; set; }

        [JsonProperty("created")]
        public DateTime Date { get; set; }
    }

    public class UsersApiResponse
    {
        [JsonProperty("items")]
        public List<User> Users { get; set; }
    }

    // Définition des modèles de données
    public class Notification : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string LogId { get; set; }
        public DateTime Date { get; set; }
        public bool Read { get; set; }
        public DateTime Updated { get; set; }
        public bool ShowBlueDot { get; set; }
        public string Id_utilisateur { get; set; }
        private bool _isUnread;
        public bool IsUnread
        {
            get { return _isUnread; }
            set
            {
                if (_isUnread != value)
                {
                    _isUnread = value;
                    OnPropertyChanged(nameof(IsUnread));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }



    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Nom { get; set; }
        public string Password { get; set; }
        public string PostPicker { get; set; }
        public string CollectionId { get; set; }
        public string CollectionName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool IsAdmin { get; set; }
    }

    // Modèle de vue pour les détails de la notification
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
    public class AdminUser
    {
        public string Mail_admin { get; set; }
        public string Nom_admin { get; set; }
        public string Password_admin { get; set; }
        public string Post_admin { get; set; }
        public string CollectionId { get; set; }
        public string CollectionName { get; set; }
        public DateTime Created { get; set; }
        public string Email { get; set; }
        public bool EmailVisibility { get; set; }
        public string Id { get; set; }
        public DateTime Updated { get; set; }
        public string Username { get; set; }
        public bool Verified { get; set; }
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
        [JsonProperty("created")]
        public DateTime created { get; set; }
        [JsonProperty("id_admin")]
        public string id_admin { get; set; }
    }
    public class NotificationUserApiResponse
    {
        [JsonProperty("items")]
        public List<NotificationUtilisateur> Items { get; set; }
    }

}


using azizapp.messs;
using azizapp.profil;
using Microcharts;
using Newtonsoft.Json;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OxyPlot.Annotations;
using static azizapp.MainPage;
using static azizapp.home.receivemessage;


namespace azizapp.home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeUtilisateurPage : ContentPage, INotifyPropertyChanged
    {
        private readonly HttpClient _client = new HttpClient();
        private bool _hasUnreadNotifications;

        public bool HasUnreadNotifications
        {
            get => _hasUnreadNotifications;
            set
            {
                _hasUnreadNotifications = value;
                OnPropertyChanged(nameof(HasUnreadNotifications));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public List<Notification> NotificationData { get; set; }
        private List<Microcharts.Entry> entries = new List<Microcharts.Entry>();
        private List<TemperatureData> temperatures = new List<TemperatureData>();
        private List<Microcharts.Entry> _entries = new List<Microcharts.Entry>();
        private List<DataPoint> _chartData = new List<DataPoint>();



        public HomeUtilisateurPage()
        {
            InitializeComponent();
            BindingContext = this;
            CheckUnreadNotifications();
            LoadTemperatureLogs();
          //  LoadUserDataAsync();
            LoadChartDataAsync();
            // Initialiser le timer pour mettre à jour l'heure
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                DateTime currentTime = DateTime.Now.AddHours(1);
                TimeLabel.Text = currentTime.ToString("HH:mm:ss");
                return true;
            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
           // await LoadUserDataAsync();
            await LoadChartDataAsync();
            await CheckUnreadNotifications();

        }



        private async Task CheckUnreadNotifications()
        {
            try
            {
                // Récupérer les notifications utilisateur
                var response = await _client.GetAsync("http://10.0.2.2:8090/api/collections/notification_utilisateur/records");
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Failed to retrieve notification utilisateur.");
                    return;
                }

                var content = await response.Content.ReadAsStringAsync();
                var notificationResponse = JsonConvert.DeserializeObject<NotificationUserApiResponse>(content);

                // Récupérer l'ID de l'utilisateur authentifié
                var currentUserId = SessionManager.CurrentUserId;

                // Vérifier s'il y a des notifications non lues pour l'utilisateur authentifié
                HasUnreadNotifications = notificationResponse.Items.Any(n => n.id_admin == currentUserId && !n.lue);

                // Si aucune notification non lue n'a été trouvée, vérifier les notifications où l'ID de l'utilisateur authentifié est dans le champ id_admin
                if (!HasUnreadNotifications)
                {
                    HasUnreadNotifications = notificationResponse.Items.Any(n => n.id_admin == currentUserId && !n.lue);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking unread notifications: {ex.Message}");
            }
        }
        private string id=SessionManager.CurrentUserId;

        private async Task LoadUserDataAsync()
        {
            try
            {
                string apiUrl = "http://10.0.2.2:8090/api/collections/Utilisateur/records/id";
                var response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var utilisateur = JsonConvert.DeserializeObject<UtilisateurResponse>(content);

                    if (utilisateur != null)
                    {
                        titleLabel.Text = utilisateur.Nom;
                        maintenance.Text = utilisateur.PostPicker;
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Unable to retrieve user information.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }


        private void CoolingTemperatureButton_Clicked(object sender, EventArgs e)
        {
            hottempContent.IsVisible = false;
            referoiContent.IsVisible = true;
            chartFrame.IsVisible = false;

        }

        private void StationTemperatureButton_Clicked(object sender, EventArgs e)
        {
            hottempContent.IsVisible = true;
            referoiContent.IsVisible = false;
            chartFrame.IsVisible = false;
        }

        private async void NotificationsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new notification());
        }

        private async void SendMessageButton_Clicked(object sender, EventArgs e)
        {
            // await Navigation.PushAsync(new envoyermessage());
            await Navigation.PushAsync(new createmessage());
        }

        private async void Alltemp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new allNotificatoin());
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            // Ajoutez le code pour le gestionnaire d'événements DateSelected du DatePicker ici
            TimeLabel.Text = DateTime.Now.ToString("T");
        }

        private async Task<List<Notification>> FetchTodayNotificationDataAsync()
        {
            try
            {
                string apiUrl = "http://10.0.2.2:8090/api/collections/Notification/records";
                var response = await _client.GetAsync(apiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    return new List<Notification>();
                }

                var json = await response.Content.ReadAsStringAsync();
                var notificationResponse = JsonConvert.DeserializeObject<NotificationResponse>(json);

                var todayNotifications = notificationResponse.Items
                    .Where(n => n.Created.Date == DateTime.Now.Date)
                    .ToList();

                return todayNotifications;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching today's notification data: {ex.Message}");
                return new List<Notification>();
            }
        }
        private async Task LoadChartDataAsync()
        {
            var notifications = await FetchTodayNotificationDataAsync();
            if (notifications == null || !notifications.Any())
            {
                Console.WriteLine("Aucune donnée de notification disponible !");
                return;
            }

            Console.WriteLine($"Nombre de notifications récupérées : {notifications.Count}");

            CreateTemperatureChart(notifications);
        }

        private async Task LoadTemperatureLogs()
        {
            try
            {
                string apiUrl = "http://10.0.2.2:8090/api/collections/Log_temperature/records";
                var response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    // Vérifier si la réponse est vide
                    if (string.IsNullOrEmpty(content))
                    {
                        // Afficher une alerte indiquant que les données sont vides
                        await DisplayAlert("Error", "Temperature data is empty.", "OK");
                        return;
                    }

                    var temperatureLogResponse = JsonConvert.DeserializeObject<TemperatureLogResponse>(content);

                    // Vérifier si la liste des logs de température est vide
                    if (temperatureLogResponse?.Items == null || temperatureLogResponse.Items.Count == 0)
                    {
                        // Afficher une alerte indiquant qu'aucun log de température n'a été trouvé
                        await DisplayAlert("Error", "No temperature logs found.", "OK");
                        return;
                    }

                    // Trier les logs par date de création décroissante et prendre le dernier
                    var latestTemperatureLog = temperatureLogResponse.Items.OrderByDescending(t => t.Created).FirstOrDefault();

                    if (latestTemperatureLog != null)
                    {
                        // Convertir la valeur de température de string en double
                        if (double.TryParse(latestTemperatureLog.Valeur_temperature, out double temperature))
                        {
                            // Mettre à jour l'étiquette avec la valeur de la température la plus récente
                            Van1Label.Text = $"VAN1 : {temperature}°C";
                        }
                        else
                        {
                            // La conversion a échoué, afficher un message d'erreur
                            await DisplayAlert("Error", "Unable to parse temperature value.", "OK");
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Unable to retrieve temperature logs.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred while retrieving temperature logs: {ex.Message}", "OK");
            }
        }



        private void CreateTemperatureChart(List<Notification> notifications)
        {
            var plotModel = new PlotModel
            {
                Title = "Nombre de Notifications par Heure",
                Subtitle = "Contenu des Notifications"
            };

            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Contenu",
                MinorGridlineStyle = LineStyle.Solid,
                MajorGridlineStyle = LineStyle.Solid
            };
            plotModel.Axes.Add(valueAxis);

            var dateTimeAxis = new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Heure de Création",
                StringFormat = "HH:mm", // Format d'affichage de l'heure
                MinorGridlineStyle = LineStyle.Solid,
                MajorGridlineStyle = LineStyle.Solid
            };
            plotModel.Axes.Add(dateTimeAxis);

            var temperatureSeries = new LineSeries
            {
                Title = "Notifications",
                MarkerType = MarkerType.Circle,
                MarkerSize = 6,
                MarkerStroke = OxyColors.Black,
                MarkerFill = OxyColors.Red,
                StrokeThickness = 7,
                LineStyle = LineStyle.Solid,
                Color = OxyColors.Red
            };

            // Tri des notifications par heure de création
            var sortedNotifications = notifications.OrderBy(n => n.Created).ToList();

            // Parcours des notifications
            foreach (var notification in sortedNotifications)
            {
                double x = DateTimeAxis.ToDouble(notification.Created); // Conversion de l'heure en double
                double y = double.Parse(notification.Contenu); // Conversion du contenu en double

                // Ajout du point de notification sur le graphique
                temperatureSeries.Points.Add(new DataPoint(x, y));
            }

            // Ajout de la série de données de notification au modèle de tracé
            plotModel.Series.Add(temperatureSeries);

            // Affichage du graphique dans le contrôle PlotView
            plotView.Model = plotModel;
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private async void accountButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new account1());
        }

        public void homeButton_Clicked(object sender, EventArgs e)
        {
            hottempContent.IsVisible = false;
            referoiContent.IsVisible = false;
            chartFrame.IsVisible = true;
        }

        private async void RefreshChart(object sender, EventArgs e)
        {
            await LoadChartDataAsync();
            await CheckUnreadNotifications();
        }



        public class UtilisateurResponse
        {
            public string Email { get; set; }
            public string Nom { get; set; }
            public string Password { get; set; }
            public string PostPicker { get; set; }
            public string CollectionId { get; set; }
            public string CollectionName { get; set; }
            public DateTime Created { get; set; }
            public string Id { get; set; }
            public DateTime Updated { get; set; }
        }

        public class NotificationResponse
        {
            public int Page { get; set; }
            public int PerPage { get; set; }
            public int TotalItems { get; set; }
            public int TotalPages { get; set; }
            public List<Notification> Items { get; set; }
        }

        public class Notification
        {
            public string Contenu { get; set; }
            public DateTime Created { get; set; }
        }

        public class TemperatureData
        {
            public DateTime Date { get; set; }
            public float Value { get; set; }
        }
        public class MyDataPoint
        {
            public double X { get; set; }
            public double Y { get; set; }

            public MyDataPoint(double x, double y)
            {
                X = x;
                Y = y;
            }
        }
        public class NotificationUtilisateur
        {
            [JsonProperty("id_utilisateur")]
            public string id_utilisateur { get; set; }
            [JsonProperty("id_admin")]
            public string id_admin { get; set; }

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
        }
        public class NotificationUserApiResponse
        {
            public List<NotificationUtilisateur> Items { get; set; }
        }

        public class TemperatureLogResponse
        {
            public List<TemperatureLog> Items { get; set; }
        }

        public class TemperatureLog
        {
            [JsonProperty("created")]
            public DateTime Created { get; set; }

            [JsonProperty("Valeur_temperature")]
            public string Valeur_temperature { get; set; }
        }





    }
}

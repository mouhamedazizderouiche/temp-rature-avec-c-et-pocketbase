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


namespace azizapp.home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class homePage : ContentPage, INotifyPropertyChanged
    {
        private readonly HttpClient _client = new HttpClient();
        string userName = SessionManager.CurrentUserId;
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
        private bool _hasNewMessages;

        public bool HasNewMessages
        {
            get => _hasNewMessages;
            set
            {
                _hasNewMessages = value;
                OnPropertyChanged(nameof(HasNewMessages));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Notification> NotificationData { get; set; }
        private List<Microcharts.Entry> entries = new List<Microcharts.Entry>();
        private List<TemperatureData> temperatures = new List<TemperatureData>();
        private List<Microcharts.Entry> _entries = new List<Microcharts.Entry>();
        private List<DataPoint> _chartData = new List<DataPoint>();

        public homePage()
        {
            InitializeComponent();
            BindingContext = this;
            CheckUnreadNotifications();
            FetchTemperatureLogsAsync();
            LoadUsersAsync();
            LoadTemperatureLogs();
            LoadChartDataAsyncLogTemp();



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
            await LoadUsersAsync();
            await CheckUnreadNotifications();
            await CheckForNewMessagesAsync();
           await FetchTemperatureLogsAsync();
        }

        private async void Alltemp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new allNotificatoin());
        }

        private async Task CheckForNewMessagesAsync()
        {
            try
            {
                var response = await _client.GetAsync("http://10.0.2.2:8090/api/collections/message/records");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var messageListResponse = JsonConvert.DeserializeObject<MessageListResponse>(content);

                    // Dictionnaire pour stocker les derniers messages par utilisateur
                    var lastMessagesByUser = new Dictionary<string, Message>();

                    // Récupérer l'ID de l'utilisateur actuellement authentifié
                    var currentUserId = SessionManager.CurrentUserId;

                    foreach (var message in messageListResponse.Items)
                    {
                        // Récupérer l'ID de l'autre utilisateur
                        var otherUserId = message.Id_source == currentUserId ? message.Id_destination : message.Id_source;

                        // Si l'utilisateur est déjà dans le dictionnaire, vérifier si le message actuel est plus récent
                        if (lastMessagesByUser.ContainsKey(otherUserId))
                        {
                            if (message.SentTime > lastMessagesByUser[otherUserId].SentTime)
                            {
                                lastMessagesByUser[otherUserId] = message;
                            }
                        }
                        else
                        {
                            // Ajouter le message dans le dictionnaire
                            lastMessagesByUser[otherUserId] = message;
                        }
                    }

                    // Vérifier si le dernier message de chaque utilisateur a été envoyé par l'autre utilisateur
                    var hasNewMessages = lastMessagesByUser.Values.Any(m => m.Id_source != currentUserId);

                    // Mettre à jour l'indicateur de nouveaux messages
                    HasNewMessages = hasNewMessages;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking for new messages: {ex.Message}");
            }
        }

        private async void OnViewNotificationsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotificationsPage());
        }


        private async Task CheckUnreadNotifications()
        {
            try
            {
                var response = await _client.GetAsync("http://10.0.2.2:8090/api/collections/notification_utilisateur/records");
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Failed to retrieve notification utilisateur.");
                    return;
                }

                var content = await response.Content.ReadAsStringAsync();
                var notificationResponse = JsonConvert.DeserializeObject<NotificationUserApiResponse>(content);

                HasUnreadNotifications = notificationResponse.Items.Any(n => n.id_utilisateur == SessionManager.CurrentUserId && !n.lue);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking unread notifications: {ex.Message}");
            }
        }

        private async Task LoadUsersAsync()
        {
            try
            {
                // Récupération de l'ID et du type de l'utilisateur actuellement authentifié
                string userId = SessionManager.CurrentUserId;
                string userType = SessionManager.UserType;
                Console.WriteLine($"Current User ID: {userId}, User Type: {userType}");

                // Sélection de l'URL de l'API en fonction du type d'utilisateur
                string apiUrl;
                if (userType == "Admin")
                {
                    apiUrl = $"http://10.0.2.2:8090/api/collections/admin/records/{userId}";
                }
                else
                {
                    apiUrl = $"http://10.0.2.2:8090/api/collections/utilisateur/records/{userId}";
                }

                var response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var utilisateur = JsonConvert.DeserializeObject<User>(content);

                    if (utilisateur != null)
                    {
                        // Mettre à jour le titre de la page avec le nom de l'utilisateur
                        titleLabel.Text = utilisateur.Nom ?? utilisateur.Nom_admin;
                        maintenance.Text = utilisateur.PostPicker ?? utilisateur.Post_admin;
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Unable to retrieve user information.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred while retrieving user information: {ex.Message}", "OK");
            }
        }

        private void CoolingTemperatureButton_Clicked(object sender, EventArgs e)
        {
            hottempContent.IsVisible = false;
            referoiContent.IsVisible = true;
            chartFrame.IsVisible = false;
        }

        private void temp(object sender, EventArgs e)
        {
            // Logique pour gérer l'événement de clic sur l'étiquette de température (si nécessaire)
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
            await Navigation.PushAsync(new createmessage());
        }

        private async void ReceiveMessageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new receivemessage());
            await CheckUnreadNotifications();
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            TimeLabel.Text = DateTime.Now.ToString("T");
        }

        private async Task<List<TemperatureLog>> FetchTemperatureLogsAsync()
        {
            try
            {
                string apiUrl = "http://10.0.2.2:8090/api/collections/log_temperature/records";
                var response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var temperatureLogResponse = JsonConvert.DeserializeObject<TemperatureLogResponse>(content);

                    return temperatureLogResponse?.Items ?? new List<TemperatureLog>();
                }
                else
                {
                    Console.WriteLine("Unable to retrieve temperature logs.");
                    return new List<TemperatureLog>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving temperature logs: {ex.Message}");
                return new List<TemperatureLog>();
            }
        }

        private async Task LoadChartDataAsyncLogTemp()
        {
            var temperatureLogs = await FetchTemperatureLogsAsync();
            if (temperatureLogs == null || !temperatureLogs.Any())
            {
                Console.WriteLine("Aucune donnée de notification disponible !");
                return;
            }

            Console.WriteLine($"Nombre de notifications récupérées : {temperatureLogs.Count}");

            CreateTemperatureChart(temperatureLogs);
        }

        private void CreateTemperatureChart(List<TemperatureLog> temperatureLogs)
        {
            var today = DateTime.Today;
            var todayLogs = temperatureLogs.Where(log => log.Created.Date == today).ToList();

            // Créez un modèle de graphique
            var plotModel = new PlotModel
            {
                Title = "Température de Réfrigération",
                Subtitle = $"Logs de Température pour {today:dd MMM yyyy}",
                PlotAreaBackground = OxyColor.FromRgb(240, 240, 240),
                Background = OxyColors.White
            };

            // Configurez l'axe des valeurs (température)
            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Température (°C)",
                MinorGridlineStyle = LineStyle.Solid,
                MajorGridlineStyle = LineStyle.Solid,
                IsZoomEnabled = true,
                IsPanEnabled = true
            };
            plotModel.Axes.Add(valueAxis);

            // Configurez l'axe des heures
            var dateTimeAxis = new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Heure de Création",
                StringFormat = "HH:mm",
                IntervalType = DateTimeIntervalType.Hours,
                MinorIntervalType = DateTimeIntervalType.Minutes,
                IntervalLength = 60,
                MinorGridlineStyle = LineStyle.Solid,
                MajorGridlineStyle = LineStyle.Solid,
                IsZoomEnabled = true,
                IsPanEnabled = true
            };
            plotModel.Axes.Add(dateTimeAxis);

            // Configurez la série de données (température)
            var temperatureSeries = new LineSeries
            {
                Title = "Température",
                MarkerType = MarkerType.Circle,
                MarkerSize = 6,
                MarkerStroke = OxyColors.Black,
                MarkerFill = OxyColors.Red,
                StrokeThickness = 2,
                LineStyle = LineStyle.Solid,
                Color = OxyColors.Red
            };

            // Groupement des données par heure
            var groupedLogs = todayLogs
                .GroupBy(log => new DateTime(log.Created.Year, log.Created.Month, log.Created.Day, log.Created.Hour, 0, 0))
                .OrderBy(g => g.Key)
                .ToList();

            foreach (var group in groupedLogs)
            {
                DateTime hour = group.Key;
                double averageTemperature = group.Average(log => double.Parse(log.Valeur_temperature));
                double x = DateTimeAxis.ToDouble(hour);
                double y = averageTemperature;

                temperatureSeries.Points.Add(new DataPoint(x, y));

                var textAnnotation = new TextAnnotation
                {
                    Text = $"{averageTemperature:F1}°C",
                    TextPosition = new DataPoint(x, y),
                    TextColor = OxyColors.Black,
                    FontSize = 10,
                    Stroke = OxyColors.Transparent,
                    Background = OxyColor.FromArgb(180, 255, 255, 255)
                };
                plotModel.Annotations.Add(textAnnotation);
            }

            plotModel.Series.Add(temperatureSeries);

            plotView.Model = plotModel;

            // Configurer le contrôleur de graphiques
            plotView.Controller = new PlotController();
            plotView.Controller.UnbindAll();
            plotView.Controller.BindMouseDown(OxyMouseButton.Left, PlotCommands.PanAt);
            plotView.Controller.BindMouseDown(OxyMouseButton.Right, PlotCommands.ZoomRectangle);
            plotView.Controller.BindMouseWheel(PlotCommands.ZoomWheel);

            // Afficher la dernière valeur de température
            if (todayLogs.Any())
            {
                var latestLog = todayLogs.Last();
                var latestTemp = latestLog.Valeur_temperature;
                plotModel.Subtitle += $"\nDernière valeur de température: {latestTemp}°C à {latestLog.Created:HH:mm}";
            }
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
            await CheckForNewMessagesAsync();
            await CheckUnreadNotifications();
            await FetchTemperatureLogsAsync();
            await LoadChartDataAsyncLogTemp();

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
            [JsonProperty("items")]
            public List<NotificationUtilisateur> Items { get; set; }
        }

        public class Message
        {
            public string id { get; set; }
            public string CollectionId { get; set; }
            public string CollectionName { get; set; }
            public DateTime Created { get; set; }
            public DateTime Updated { get; set; }
            public string Contenu { get; set; }
            public DateTime SentTime { get; set; }
            public string Id_source { get; set; }
            public string Id_destination { get; set; }
            public LayoutOptions HorizontalOption { get; set; }
        }

        public class MessageListResponse
        {
            public List<Message> Items { get; set; }
            public int Page { get; set; }
            public int PerPage { get; set; }
            public int TotalPages { get; set; }
            public int TotalItems { get; set; }
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

        public class User
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Nom { get; set; }
            public string PostPicker { get; set; }
            public string Mail_admin { get; set; }
            public string Nom_admin { get; set; }
            public string Post_admin { get; set; }
        }

        public class AuthResponse
        {
            public string token { get; set; }
            public User record { get; set; }
        }

        public class UserListApiResponse
        {
            public List<User> Items { get; set; }
        }
    }
}

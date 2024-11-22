using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.ComponentModel;
using azizapp.messs;
using static azizapp.MainPage;
using System.Linq;

namespace azizapp.home
{
    public partial class receivemessage : ContentPage, INotifyPropertyChanged
    {
        private readonly HttpClient _client = new HttpClient();
        private const string ApiUrl = "http://10.0.2.2:8090/api/collections/message/records";
        private bool _hasNewMessagesFromOtherUser;
        private string _currentUserId;

        public bool HasNewMessagesFromOtherUser
        {
            get { return _hasNewMessagesFromOtherUser; }
            set
            {
                if (_hasNewMessagesFromOtherUser != value)
                {
                    _hasNewMessagesFromOtherUser = value;
                    OnPropertyChanged(nameof(HasNewMessagesFromOtherUser));
                }
            }
        }

#pragma warning disable CS0067 // L'événement 'receivemessage.NewMessagesReceived' n'est jamais utilisé
        public event EventHandler NewMessagesReceived;

        public receivemessage()
        {
            InitializeComponent();
            BindingContext = this;
            _currentUserId = SessionManager.CurrentUserId;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await AfficherTousLesMessages();
        }

        private async Task AfficherTousLesMessages()
        {
            try
            {
                // Appel de l'API pour récupérer la liste de tous les messages
                var response = await _client.GetAsync(ApiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var messageListResponse = JsonConvert.DeserializeObject<MessageListResponse>(content);

                    var messages = new List<MessageItem>();

                    // Dictionnaire pour stocker les messages par utilisateur
                    var userMessages = new Dictionary<string, List<MessageItem>>();

                    // Récupérer l'ID de l'utilisateur actuellement authentifié
                    var currentUserId = SessionManager.CurrentUserId;

                    foreach (var message in messageListResponse.Items)
                    {
                        // Récupérer l'ID de l'utilisateur autre que l'utilisateur actuellement authentifié
                        var otherUserId = message.Id_source == currentUserId ? message.Id_destination : message.Id_source;
                        var otherUserName = await GetUserNameById(otherUserId);

                        // Créer un objet MessageItem avec les informations nécessaires
                        var messageItem = new MessageItem
                        {
                            Id_source = message.Id_source,
                            Id_destination = message.Id_destination,
                            UserName = otherUserName,
                            SentTime = message.SentTime,
                            Contenu = message.Id_source == currentUserId ? $"Vous: {message.Contenu}" : message.Contenu,
                            id_message = message.id,
                            UserId = otherUserId // Stocker l'ID de l'autre utilisateur
                        };

                        // Déterminer si le point bleu doit être affiché
                        messageItem.ShowBlueDot = message.Id_source != currentUserId;

                        // Vérifier si l'utilisateur existe déjà dans le dictionnaire
                        if (userMessages.ContainsKey(otherUserId))
                        {
                            // Vérifier si le message est plus récent que le message existant
                            var existingMessage = userMessages[otherUserId][0]; // Le premier message est le plus récent
                            if (message.SentTime > existingMessage.SentTime)
                            {
                                // Remplacer le message existant par le nouveau message
                                userMessages[otherUserId][0] = messageItem;
                            }
                        }
                        else
                        {
                            // Ajouter le message dans le dictionnaire
                            userMessages.Add(otherUserId, new List<MessageItem> { messageItem });
                        }
                    }

                    // Convertir le dictionnaire de messages en une liste
                    foreach (var kvp in userMessages)
                    {
                        messages.AddRange(kvp.Value);
                    }

                    // Afficher les messages dans la ListView
                    messageListView.ItemsSource = messages;
                }
                else
                {
                    await DisplayAlert("Error", "Failed to fetch messages", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        private async Task<string> GetUserNameById(string userId)
        {
            try
            {
                var response = await _client.GetAsync($"http://10.0.2.2:8090/api/collections/Utilisateur/records/{userId}?fields=Nom");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var utilisateur = JsonConvert.DeserializeObject<UtilisateurResponse>(content);
                    return utilisateur.Nom;
                }
                else
                {
                    return "Unknown";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving user data: {ex.Message}");
                return "Unknown";
            }
        }

        private void ReceiveMessagePage_NewMessagesReceived(object sender, EventArgs e)
        {
            // Mettre à jour HasNewMessagesFromOtherUser pour indiquer qu'il y a de nouveaux messages de l'autre utilisateur
            HasNewMessagesFromOtherUser = true;
        }

        // Méthode pour supprimer les messages entre l'utilisateur authentifié et un autre utilisateur


        private async void DeleteMessagesBetweenUsers(object sender, EventArgs e)
        {
            if (sender is SwipeItem swipeItem && swipeItem.CommandParameter is MessageItem messageItem)
            {
                string otherUserId = messageItem.UserId;

                try
                {
                    // Appel de l'API pour récupérer toutes les messages
                    var allMessagesResponse = await _client.GetAsync(ApiUrl);

                    if (allMessagesResponse.IsSuccessStatusCode)
                    {
                        var allMessagesContent = await allMessagesResponse.Content.ReadAsStringAsync();
                        var allMessagesList = JsonConvert.DeserializeObject<MessageListResponse>(allMessagesContent);

                        // Filtrer localement les messages pour obtenir ceux entre les deux utilisateurs
                        var messagesToDelete = allMessagesList.Items
                            .Where(message =>
                                (message.Id_source == _currentUserId && message.Id_destination == otherUserId) ||
                                (message.Id_source == otherUserId && message.Id_destination == _currentUserId))
                            .ToList();

                        // Supprimer chaque message individuellement
                        foreach (var message in messagesToDelete)
                        {
                            await DeleteMessage(message.id);

                        }

                        await DisplayAlertWithTimer("Success", "Messages deleted successfully", Color.FromHex("#CCCCCC"), TimeSpan.FromSeconds(5));
                        await AfficherTousLesMessages();
                    }
                    else
                    {
                        await DisplayAlert("Error", "Failed to fetch messages", "OK");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
                }
            }
        }
        private async Task DisplayAlertWithTimer(string title, string message, Color backgroundColor, TimeSpan duration)
        {
            var alert = await DisplayAlert(title, message, null, "OK");

            if (alert)
            {
                // Démarrez une minuterie pour fermer automatiquement l'alerte après la durée spécifiée
                Device.StartTimer(duration, () =>
                {
                    Application.Current.MainPage.Navigation.PopModalAsync();
                    return false;
                });
            }

            // Définissez la couleur de fond de l'alerte
            var modalPage = (Application.Current.MainPage as NavigationPage).CurrentPage as ContentPage;
            modalPage.BackgroundColor = backgroundColor;
        }



        private async Task DeleteMessage(string messageId)
        {
            try
            {
                var response = await _client.DeleteAsync($"{ApiUrl}/{messageId}");

                if (!response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Error", $"Failed to delete message with ID {messageId}", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }


        private async void messageListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && e.Item is azizapp.home.receivemessage.MessageItem message)
            {
                // Navigate to DetailMessagePage with message and current user ID
                await Navigation.PushAsync(new azizapp.messs.DetailMessagePage(message, SessionManager.CurrentUserId));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        public class MessageItem : INotifyPropertyChanged
        {
            public string Id_source { get; set; }
            public string Id_destination { get; set; }
            public string UserName { get; set; }
            public string Contenu { get; set; }
            public DateTime SentTime { get; set; }
            public string id_message { get; set; }
            public string UserId { get; set; }
            public bool IsCurrentUserMessage { get; set; }

            public LayoutOptions HorizontalOption { get; set; }
            private bool _showBlueDot;
            public bool ShowBlueDot
            {
                get { return _showBlueDot; }
                set
                {
                    if (_showBlueDot != value)
                    {
                        _showBlueDot = value;
                        OnPropertyChanged(nameof(ShowBlueDot));

                    }
                }
            }
            private bool _isVisible = true;
            public bool IsVisible
            {
                get { return _isVisible; }
                set
                {
                    if (_isVisible != value)
                    {
                        _isVisible = value;
                        OnPropertyChanged(nameof(IsVisible));
                    }
                }
            }
            public Command DeleteMessageCommand { get; }


          


            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public class UtilisateurResponse
        {
            public string Id { get; set; }
            public string CollectionId { get; set; }
            public string CollectionName { get; set; }
            public DateTime Created { get; set; }
            public DateTime Updated { get; set; }
            public string Nom { get; set; }
            public string Password { get; set; }
            public string PostPicker { get; set; }
            public string Email { get; set; }
        }
    }
}

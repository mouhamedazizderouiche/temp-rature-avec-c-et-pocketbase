using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static azizapp.home.receivemessage;

namespace azizapp.messs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailMessagePage : ContentPage, INotifyPropertyChanged
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly string _currentUserId;
        private readonly string _otherUserId;
        private ObservableCollection<MessageItem> _messages;
#pragma warning disable CS0414 // Le champ 'DetailMessagePage._tapCount' est assigné, mais sa valeur n'est jamais utilisée
        private int _tapCount = 0;
#pragma warning restore CS0414 // Le champ 'DetailMessagePage._tapCount' est assigné, mais sa valeur n'est jamais utilisée
        private DateTime _lastTapTime = DateTime.MinValue;
        public DetailMessagePage(MessageItem message, string currentUserId)
        {
            InitializeComponent();

            _currentUserId = currentUserId;
            _otherUserId = message.UserId;
            _messages = new ObservableCollection<MessageItem>();
            BindingContext = this;

            Title = message.UserName;

#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
            LoadMessagesAsync();
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
            MessageEntry = (Entry)FindByName("MessageEntry");
        }

        private async Task LoadMessagesAsync()
        {
            try
            {
                var url = $"http://10.0.2.2:8090/api/collections/message/records";
                var response = await _client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var messageListResponse = JsonConvert.DeserializeObject<MessageListResponse>(content);

                    var filteredMessages = messageListResponse.Items
                        .Where(message => (message.Id_source == _currentUserId && message.Id_destination == _otherUserId) ||
                                           (message.Id_source == _otherUserId && message.Id_destination == _currentUserId))
                        .Select(message => new MessageItem
                        {
                            Id_source = message.Id_source,
                            Id_destination = message.Id_destination,
                            Contenu = message.Contenu,
                            SentTime = message.SentTime,
                            IsCurrentUserMessage = message.Id_source == _currentUserId,
                            id_message = message.id
                        })
                        .ToList();

                    if (filteredMessages.Any())
                    {
                        filteredMessages.Reverse();

                        foreach (var msg in filteredMessages)
                        {
                            _messages.Insert(0, msg);
                        }

                        OnPropertyChanged(nameof(Messages));
                    }
                    else
                    {
                        await DisplayAlert("Info", "No messages found.", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Failed to load messages", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        public ObservableCollection<MessageItem> Messages => _messages;

        private async void SendButton_Clicked(object sender, EventArgs e)
        {
            var messageEntry = (Entry)FindByName("MessageEntry");
            string messageContent = MessageEntry.Text;

            if (string.IsNullOrEmpty(messageContent))
            {
                await DisplayAlert("Error", "Please enter a message to send", "OK");
                return;
            }

            var newMessage = new MessageItem
            {
                Id_source = _currentUserId,
                Id_destination = _otherUserId,
                Contenu = messageContent,
                SentTime = DateTime.Now.AddHours(1)
            };

            await SendMessageAsync(newMessage);

            messageEntry.Text = string.Empty;
        }

        private async Task SendMessageAsync(MessageItem message)
        {
            try
            {
                var serializedMessage = JsonConvert.SerializeObject(message);
                var content = new StringContent(serializedMessage, Encoding.UTF8, "application/json");

                var url = "http://10.0.2.2:8090/api/collections/message/records";
                var response = await _client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    message.IsCurrentUserMessage = message.Id_source == _currentUserId;
                    _messages.Add(message);
                    OnPropertyChanged(nameof(Messages));
                }
                else
                {
                    await DisplayAlert("Error", "Failed to send message", "OK");
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



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task DeleteMessageAsync(MessageItem message)
        {
            try
            {
                var response = await _client.DeleteAsync($"http://10.0.2.2:8090/api/collections/message/records/{message.id_message}");

                if (response.IsSuccessStatusCode)
                {
                    _messages.Remove(message);
                    OnPropertyChanged(nameof(Messages));
                }
                else
                {
                    await DisplayAlert("Error", "Failed to delete message", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        private async void MessageItem_DoubleTapped(object sender, EventArgs e)
        {
            var messageItem = (sender as Label).BindingContext as MessageItem;

            // Check if the message was sent by the current user
            if (messageItem.Id_source == _currentUserId)
            {
                // Update like status on the server (replace with your actual API call)
                var url = $"http://10.0.2.2:8090/api/collections/message/records/{messageItem.id_message}/like";
                var response = await _client.PutAsync(url, new StringContent("{}", Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    // Update message locally
                    messageItem.Contenu += " ❤️";
                    OnPropertyChanged(nameof(Messages));
                }
                else
                {
                    await DisplayAlert("Error", "Failed to like message", "OK");
                }
            }
            else
            {
                
                await DisplayAlert("Info", "You reacted to another user's message.", "OK");
            }
        }


        private async void MessageItem_LongPressed(object sender, EventArgs e)
        {
            var messageItem = (sender as Label).BindingContext as MessageItem;

            // Check if the message was sent by the current user
            if (messageItem.Id_source == _currentUserId)
            {
                // Display confirmation dialog for deletion
                if (await DisplayAlert("Confirmation", "Do you want to delete this message?", "Yes", "No"))
                {
                    await DeleteMessageAsync(messageItem);
                }
            }
            else
            {
                // Inform the user that they cannot delete this message
                await DisplayAlert("Error", "You are not allowed to delete this message.", "OK");
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

    public class MessageAlignmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isCurrentUserMessage)
            {
                return isCurrentUserMessage ? LayoutOptions.End : LayoutOptions.Start;
            }

            return LayoutOptions.Start;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class MessageColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isCurrentUserMessage = (bool)value;

            if (isCurrentUserMessage)
            {
                return Color.FromHex("#47f8f1");
            }
            else
            {
                return Color.FromHex("#afafaf");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

    public class MessageTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isCurrentUserMessage = (bool)value;

            if (isCurrentUserMessage)
            {
                return Color.White;
            }
            else
            {
                return Color.Black;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

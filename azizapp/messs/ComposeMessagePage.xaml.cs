using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using azizapp.home;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static azizapp.MainPage;

namespace azizapp.message
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComposeMessagePage : ContentPage
    {
        private HttpClient _client;
        private messs.createmessage.User _selectedUser;

        public ComposeMessagePage(string userId, string userName)
        {
            InitializeComponent();
            _selectedUser = new messs.createmessage.User { Id = userId, Nom = userName };
            selectedUserLabel.Text = _selectedUser.Nom;
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://10.0.2.2:8090/api/collections/message/records");
        }






        private async void SendButtonClicked(object sender, EventArgs e)
        {
            string contenu = messageEditor.Text;
            string sentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string idSource = SessionManager.CurrentUserId; // Utilisez l'ID de l'utilisateur actuel
            string idDestination = _selectedUser.Id;

            bool success = await SendMessage(contenu, sentTime, idSource, idDestination);
            if (success)
            {
                await DisplayAlert("Success", "Message sent successfully", "OK");
                messageEditor.Text = "";
            }
            else
            {
                await DisplayAlert("Error", "Failed to send message", "OK");
            }
        }



        private async Task<bool> SendMessage(string contenu, string sentTime, string idSource, string idDestination)
        {
            try
            {
                var messageData = new
                {
                    Contenu = contenu,
                    SentTime = sentTime,
                    Id_source = idSource,
                    Id_destination = idDestination
                };

                var json = JsonConvert.SerializeObject(messageData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Failed to send message. Status code: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message: {ex.Message}");
                return false;
            }
        }
    }
}
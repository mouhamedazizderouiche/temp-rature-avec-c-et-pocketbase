using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static azizapp.MainPage;

namespace azizapp.profil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountInformation : ContentPage
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string PocketBaseUrl = "http://10.0.2.2:8090";

        public AccountInformation()
        {
            InitializeComponent();
            SetupLabels();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            string userId = SessionManager.CurrentUserId;

            // Test admin URL first
            string adminApiUrl = $"{PocketBaseUrl}/api/collections/admin/records/{userId}";
            HttpResponseMessage adminResponse = await _httpClient.GetAsync(adminApiUrl);

            if (adminResponse.IsSuccessStatusCode)
            {
                await ProcessApiResponse(adminResponse);
            }
            else
            {
                // If admin URL fails, try utilisateur URL
                string utilisateurApiUrl = $"{PocketBaseUrl}/api/collections/Utilisateur/records/{userId}";
                HttpResponseMessage utilisateurResponse = await _httpClient.GetAsync(utilisateurApiUrl);

                if (utilisateurResponse.IsSuccessStatusCode)
                {
                    await ProcessApiResponse(utilisateurResponse);
                }
                else
                {
                    await DisplayAlert("Erreur", "Impossible de récupérer les informations de l'utilisateur.", "OK");
                }
            }
        }

        private async Task ProcessApiResponse(HttpResponseMessage response)
        {
            try
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                User user = JsonConvert.DeserializeObject<User>(jsonResponse);

                nameLabel.Text = $"Nom: {user.Nom_admin ?? user.Nom}";
                creationDateLabel.Text = $"Date de création de compte:  {user.created}";
                postLabel.Text = $"Poste: \"{user.Post_admin ?? user.PostPicker}\"";
                emailLabel.Text = $"Adresse mail: {user.Email}";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erreur", $"Une erreur s'est produite : {ex.Message}", "OK");
            }
        }

        private void SetupLabels()
        {

            Span nomSpan = new Span { Text = "Nom: ", ForegroundColor = Color.Red };
            Span creationDateSpan = new Span { Text = "Date de création de compte: ", ForegroundColor = Color.Black };
            Span postSpan = new Span { Text = "Poste: ", ForegroundColor = Color.Red };
            Span emailSpan = new Span { Text = "Adresse mail: ", ForegroundColor = Color.Black };

            var formattedNameLabel = new FormattedString();
            formattedNameLabel.Spans.Add(nomSpan);
            nameLabel.FormattedText = formattedNameLabel;

            creationDateLabel.Text = creationDateSpan.Text;
            postLabel.Text = postSpan.Text;
            emailLabel.Text = emailSpan.Text;
        }

        // User data model (matches the corresponding properties in the API response)
        public class User
        {
            public string Email { get; set; }
            public string Nom_admin { get; set; }
            public string Post_admin { get; set; }
            public string created { get; set; }
            public string Nom { get; set; }
            public string PostPicker { get; set; }
        }
    }
}

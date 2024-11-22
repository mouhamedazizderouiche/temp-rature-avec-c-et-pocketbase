using Newtonsoft.Json;
using System.Net.Http;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using System;

namespace azizapp.profil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModifieAccount : ContentPage
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public ModifieAccount()
        {
            InitializeComponent();


        }

        private async void OnSubmitButtonClicked(object sender, EventArgs e)

        {
            try
            {
                // Récupérer l'ID de l'utilisateur authentifié
                string userId = SessionManager.CurrentUserId;

                // Récupérer les données de l'utilisateur depuis l'API de l'admin
                string adminApiUrl = $"http://10.0.2.2:8090/api/collections/admin/records/{userId}";
                HttpResponseMessage adminResponse = await _httpClient.GetAsync(adminApiUrl);

                if (adminResponse.IsSuccessStatusCode)
                {
                    string adminJsonResponse = await adminResponse.Content.ReadAsStringAsync();
                    AdminData adminData = JsonConvert.DeserializeObject<AdminData>(adminJsonResponse);

                    // Remplir les champs avec les données de l'administrateur
                    nomEntry.Text = adminData.Nom_admin;
                    emailEntry.Text = adminData.Mail_admin;
                    ancienPasswordEntry.Text = adminData.Password_admin;
                    // Vous pouvez ajouter d'autres champs si nécessaire
                }
                else
                {
                    await DisplayAlert("Erreur", "Impossible de récupérer les informations de l'administrateur.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erreur", $"Une erreur s'est produite : {ex.Message}", "OK");
            }
        }

        public class AdminData
        {
            public string Nom_admin { get; set; }
            public string Mail_admin { get; set; }
            public string Password_admin { get; set; }
            // Ajoutez d'autres propriétés si nécessaire
        }

        public class SessionManager
        {
            public static string CurrentUserId { get; set; }
        }
    }
}
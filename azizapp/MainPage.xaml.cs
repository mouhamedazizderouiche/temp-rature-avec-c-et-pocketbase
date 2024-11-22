using azizapp.home; // Assurez-vous que ce namespace est correct
using Newtonsoft.Json;
using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace azizapp
{
    public partial class MainPage : ContentPage
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly string _apiUrl = "http://10.0.2.2:8090";
        private string _currentUserId;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                string identifier = textnamee.Text;
                string password = passwordd.Text;

                if (string.IsNullOrEmpty(identifier) || string.IsNullOrEmpty(password))
                {
                    await DisplayAlert("Erreur", "Veuillez saisir votre nom d'utilisateur ou votre adresse e-mail et votre mot de passe.", "OK");
                    return;
                }

                var authData = await AuthenticateAsync(identifier, password);

                if (authData != null)
                {
                    await DisplayAlert("Succès", "Authentification réussie!", "OK");
                    SessionManager.CurrentUserId = authData.record.Id;
                    if (SessionManager.UserType == "Admin")
                    {
                        await Navigation.PushAsync(new HomeUtilisateurPage());
                    }
                    else
                    {
                        await Navigation.PushAsync(new homePage());
                    }

                    textnamee.Text = string.Empty;
                    passwordd.Text = string.Empty;
                }
                else
                {
                    await DisplayAlert("Erreur", "Email ou mot de passe incorrect.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erreur", $"Une erreur s'est produite : {ex.Message}", "OK");
            }
        }

        private async Task<AuthResponse> AuthenticateAsync(string identifier, string password)
        {
            try
            {
                // Requête pour obtenir la liste des administrateurs
                var response = await _client.GetAsync($"{_apiUrl}/api/collections/admin/records");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var adminListApiResponse = JsonConvert.DeserializeObject<UserListApiResponse>(jsonResponse);

                    // Rechercher l'administrateur avec l'identifiant et le mot de passe corrects
                    var admin = adminListApiResponse.Items.FirstOrDefault(a => a.Mail_admin == identifier && a.Password_admin == password);
                    if (admin != null)
                    {
                        SessionManager.CurrentUserId = admin.Id;
                        SessionManager.UserType = "Admin";
                        return new AuthResponse { record = admin };
                    }
                }

                // Requête pour obtenir la liste des utilisateurs
                response = await _client.GetAsync($"{_apiUrl}/api/collections/utilisateur/records");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var userListApiResponse = JsonConvert.DeserializeObject<UserListApiResponse>(responseContent);

                    var user = userListApiResponse.Items.FirstOrDefault(u => u.Email == identifier && u.Password == password);
                    if (user != null)
                    {
                        SessionManager.CurrentUserId = user.Id;
                        SessionManager.UserType = "Utilisateur";
                        return new AuthResponse { record = user };
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'authentification : {ex.Message}");
                return null;
            }
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

        public class AdminListApiResponse
        {
            public List<Admin> Items { get; set; }
        }

        public static class SessionManager
        {
            public static string CurrentUserId { get; set; }
            public static string UserType { get; set; }
        }

        public class User
        {
            public string email { get; set; }
            public string Id { get; set; }
            public string password { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Nom { get; set; }
            public string PostPicker { get; set; }
            public string Mail_admin { get; set; }
            public string Password_admin { get; set; }
        }

        public class Admin
        {
            public string Mail_admin { get; set; }
            public string Nom_admin { get; set; }
            public string Post_admin { get; set; }
            public string Password_admin { get; set; }
            public string Id { get; set; }
        }
    }
}

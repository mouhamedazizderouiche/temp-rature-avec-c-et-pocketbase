using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace azizapp
{

    public partial class add : ContentPage
    {

        public add()
        {
            InitializeComponent();


        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            // Récupérer les valeurs saisies par l'utilisateur
            string nom = UsernameEntry.Text;
            string password = PasswordEntry.Text;
            string confirmPassword = ConfirmPasswordEntry.Text;
            string postPicker = PostPicker.SelectedItem as string;
            string email = mail.Text;

            UsernameEntry.Text = string.Empty;
            PasswordEntry.Text = string.Empty;
            ConfirmPasswordEntry.Text = string.Empty;
            mail.Text = string.Empty;

            // Sélectionner le premier élément dans le Picker
            if (PostPicker.SelectedIndex != -1)
                PostPicker.SelectedIndex = 0;

            // Vérifier si les champs obligatoires sont remplis
            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(postPicker) || string.IsNullOrEmpty(email))
            {
                await DisplayAlert("Erreur", "Veuillez remplir tous les champs.", "OK");
                return;
            }

            // Vérifier si le mot de passe et la confirmation sont identiques
            if (password != confirmPassword)
            {
                await DisplayAlert("Erreur", "Les mots de passe ne correspondent pas.", "OK");
                return;
            }

            // Créer un nouvel objet Utilisateur
            Utilisateur utilisateur = new Utilisateur
            {
                Nom = nom,
                Password = password,
                PostPicker = postPicker,
                Email = email
            };

            // Appeler la méthode AjouterUtilisateur du view model pour envoyer l'utilisateur à PocketBase
            AddPageViewModel viewModel = new AddPageViewModel();
            bool ajoutReussi = await viewModel.AjouterUtilisateur(utilisateur);

            // Afficher un message de succès ou d'erreur en fonction du résultat
            if (ajoutReussi)
            {
                await DisplayAlert("Succès", "Utilisateur ajouté avec succès.", "OK");
            }
            else
            {
                await DisplayAlert("Erreur", "Une erreur s'est produite lors de l'ajout de l'utilisateur.", "OK");
            }
        }
    }




    public class Utilisateur
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Password { get; set; }
        public string PostPicker { get; set; }
        public string Email { get; set; }

        public string Post { get; internal set; }

    }

    public class AddPageViewModel
    {
        private readonly HttpClient _httpClient;

        public AddPageViewModel()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> AjouterUtilisateur(Utilisateur utilisateur)
        {
            try
            {
                string apiUrl = "http://10.0.2.2:8090/api/collections/Utilisateur/records";

                string json = JsonConvert.SerializeObject(utilisateur);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);
                response.EnsureSuccessStatusCode(); // Lève une exception si la requête n'a pas réussi

                return true; // Retourne true si l'ajout a réussi
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'ajout de l'utilisateur : {ex.Message}");
                return false; // Retourne false si une erreur s'est produite
            }
        }
    }
}


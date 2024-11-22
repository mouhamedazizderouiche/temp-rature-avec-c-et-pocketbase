using System;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Text;

namespace azizapp
{
    public partial class modif : ContentPage
    {
        private readonly HttpClient _client = new HttpClient();
        private Utilisateur _selectedUser;



        public modif(Utilisateur selectedUser)
        {
            InitializeComponent();
            _selectedUser = selectedUser;

            // Remplir les champs avec les données de l'utilisateur sélectionné
            UsernameEntry.Text = selectedUser.Nom;
            PasswordEntry.Text = selectedUser.Password;
            PostPicker.SelectedItem = selectedUser.Post;
            EmailEntry.Text = selectedUser.Email;

            initialPassword = PasswordEntry.Text;

            // Gérer la visibilité du champ de confirmation du mot de passe lors de l'initialisation de la page
            PasswordEntry_TextChanged(null, null);
        }


        private string initialPassword = "";


        private void PasswordEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Vérifie si le mot de passe a été modifié
            if (PasswordEntry.Text != initialPassword)
            {
                // Rendre le champ ConfirmPasswordEntry visible et activé
                ConfirmPasswordEntry.IsVisible = true;
                ConfirmPasswordEntry.IsEnabled = true;
                ConfirmPasswordLabel.IsVisible = true;
            }
            else
            {
                // Si le mot de passe n'a pas été modifié, masquer le champ de confirmation
                ConfirmPasswordEntry.IsVisible = false;
                ConfirmPasswordEntry.IsEnabled = false;
                ConfirmPasswordEntry.Text = "";
                ConfirmPasswordLabel.IsVisible = false;
            }
        }

        private async void ModifButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (_selectedUser == null)
                {
                    await DisplayAlert("Erreur", "Utilisateur non trouvé.", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(UsernameEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text) || string.IsNullOrEmpty(EmailEntry.Text))
                {
                    await DisplayAlert("Erreur", "Veuillez remplir tous les champs.", "OK");
                    return;
                }

              

                Utilisateur utilisateur = new Utilisateur
                {
                    // Assignez les propriétés de l'utilisateur avec les valeurs des Entry correspondants
                    Nom = UsernameEntry.Text,
                    Password = PasswordEntry.Text,
                    PostPicker = PostPicker.SelectedItem?.ToString(), // Récupérer la valeur sélectionnée du Picker
                    Email = EmailEntry.Text
                };

                // Convertissez l'objet utilisateur en JSON
                string utilisateurJson = JsonConvert.SerializeObject(utilisateur);

                // Construire l'URL de l'API avec l'ID de l'utilisateur sélectionné
                string apiUrl = $"http://10.0.2.2:8090/api/collections/Utilisateur/records/{_selectedUser.Id}";

                // Créez une requête HTTP PATCH
                var request = new HttpRequestMessage(new HttpMethod("PATCH"), apiUrl)
                {
                    Content = new StringContent(utilisateurJson, Encoding.UTF8, "application/json")
                };

                // Envoyer la requête PATCH à l'API
                var response = await _client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Succès", "Utilisateur modifié avec succès.", "OK");
                    // Redirigez l'utilisateur vers la page précédente ou effectuez toute autre action nécessaire
                }
                else
                {
                    await DisplayAlert("Erreur", $"Échec de la modification de l'utilisateur : {response.StatusCode}", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erreur", $"Une erreur s'est produite lors de la modification de l'utilisateur : {ex.Message}", "OK");
            }
        }




    }
}

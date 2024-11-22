using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using azizapp.models;
using System.Net;

namespace azizapp
{
    public partial class UserListPage : ContentPage
    {

        private readonly HttpClient _client = new HttpClient();
        public UserListPage()
        {
            InitializeComponent();
#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
            LoadUsers();
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
        }

        private async Task LoadUsers()
        {
            try
            {
                string apiUrl = "http://10.0.2.2:8090/api/collections/Utilisateur/records";
                var response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var userListApiResponse = JsonConvert.DeserializeObject<UserListApiResponse>(content);

                    if (userListApiResponse.Users != null && userListApiResponse.Users.Any())
                    {
                        var sortedUsers = userListApiResponse.Users.OrderBy(u => u.Nom).ToList();
                        userListView.ItemsSource = sortedUsers;
                    }
                    else
                    {
                        await DisplayAlert("Aucun utilisateur", "Aucun utilisateur trouvé.", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Erreur", "Impossible de récupérer la liste des utilisateurs.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erreur", $"Une erreur s'est produite lors de la récupération des utilisateurs : {ex.Message}", "OK");
            }
        }

        public class UserListApiResponse
        {
            [JsonProperty("items")]
            public List<Utilisateur> Users { get; set; }
        }



        private void HandleSearch(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchBar.Text))
            {
#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
                LoadUsers();
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
            }
            else
            {
                var filteredUsers = ((List<Utilisateur>)userListView.ItemsSource).Where(user =>
                  user.Nom.ToLower().Contains(searchBar.Text.ToLower()) ||
                  user.PostPicker.ToLower().Contains(searchBar.Text.ToLower()) ||
                  user.Email.ToLower().Contains(searchBar.Text.ToLower())).ToList();
                userListView.ItemsSource = filteredUsers;
            }
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            if (e.SelectedItem is Utilisateur utilisateur)
            {
                // Hide action buttons initially (if needed)
                HideActionButtons();

                var cell = userListView.TemplatedItems.FirstOrDefault(c => c.BindingContext == utilisateur) as ViewCell;
                if (cell != null)
                {
                    // Find email and post labels by name
                    var emailLabel = cell.FindByName<Label>("emailLabel");
                    var postLabel = cell.FindByName<Label>("postLabel");

                    // Make email label visible
                    emailLabel.IsVisible = true;
                    postLabel.IsVisible = true;

                    var buttonStack = cell.FindByName<StackLayout>("buttonStack");
                    buttonStack.IsVisible = true;
                }

            }
        }


        private void HideActionButtons()
        {
            foreach (var item in userListView.ItemsSource)
            {
                if (item is Utilisateur utilisateur)
                {
                    var cell = userListView.TemplatedItems.FirstOrDefault(c => c.BindingContext == utilisateur) as ViewCell;
                    if (cell != null)
                    {
                        var buttonStack = cell.FindByName<StackLayout>("buttonStack");
                        var emailLabel = cell.FindByName<Label>("emailLabel");
                        var postLabel = cell.FindByName<Label>("postLabel");
                        emailLabel.IsVisible = false;
                        postLabel.IsVisible = false;
                        buttonStack.IsVisible = false;
                    }
                }
            }
        }

        private async void OnModifierButtonClicked(object sender, EventArgs e)
        {
            if (userListView.SelectedItem == null)
            {
                await DisplayAlert("Aucun utilisateur sélectionné", "Sélectionnez un utilisateur à modifier.", "OK");
                return;
            }

            var selectedUser = userListView.SelectedItem as Utilisateur;

            if (selectedUser == null)
            {
                await DisplayAlert("Erreur", "Utilisateur sélectionné non valide.", "OK");
                return;
            }

            // Passer les données de l'utilisateur sélectionné à la page de modification
            var modifPage = new modif(selectedUser);
            await Navigation.PushAsync(modifPage);
        }


        private async void OnSupprimerButtonClickedd(object sender, EventArgs e)
        {
            try
            {
                if (userListView.SelectedItem == null)
                {
                    await DisplayAlert("Aucun utilisateur sélectionné", "Sélectionnez un utilisateur à supprimer.", "OK");
                    return;
                }

                Utilisateur selectedUser = userListView.SelectedItem as Utilisateur;

                if (selectedUser == null || string.IsNullOrEmpty(selectedUser.Id))
                {
                    await DisplayAlert("Erreur", "ID de l'utilisateur non valide.", "OK");
                    return;
                }

                bool confirmation = await DisplayAlert("Suppression", $"Êtes-vous sûr de vouloir supprimer l'utilisateur {selectedUser.Nom} ?", "Supprimer", "Annuler");

                if (!confirmation)
                {
                    return;
                }

                string apiUrl = $"http://10.0.2.2:8090/api/collections/Utilisateur/records/{selectedUser.Id}";

                HttpResponseMessage response = await _client.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Succès", "Utilisateur supprimé avec succès.", "OK");
                    await LoadUsers();
                }
                else
                {
                    await DisplayAlert("Erreur", $"Échec de la suppression de l'utilisateur : {response.StatusCode}", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erreur", $"Une erreur s'est produite lors de la suppression de l'utilisateur : {ex.Message}", "OK");
            }
        }






    }
}

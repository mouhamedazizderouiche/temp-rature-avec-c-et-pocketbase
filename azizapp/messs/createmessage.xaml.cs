using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using azizapp.message;

namespace azizapp.messs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class createmessage : ContentPage
    {
        private HttpClient _client = new HttpClient();
        private List<User> allUsers = new List<User>();
        private bool _isDropDownVisible = false;
        private string _currentFilter = "Tous";

        public createmessage()
        {
            InitializeComponent();
            Title = "Liste des Utilisateurs";

            LoadUsers(_currentFilter);
        }

        private async void LoadUsers(string filter)
        {
            try
            {
                string apiUrl = "http://10.0.2.2:8090/api/collections/Utilisateur/records";
                var response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var userListApiResponse = JsonConvert.DeserializeObject<UserListApiResponse>(content);

                    if (filter == "Tous")
                    {
                        allUsers = userListApiResponse.Items.OrderBy(u => u.Nom).ToList();
                    }
                    else if (filter == "Maintenance")
                    {
                        allUsers = userListApiResponse.Items.Where(u => u.PostPicker == "Maintenance").OrderBy(u => u.Nom).ToList();
                    }
                    else if (filter == "Laboratoire")
                    {
                        allUsers = userListApiResponse.Items.Where(u => u.PostPicker == "Laboratoire").OrderBy(u => u.Nom).ToList();
                    }

                    userListView.ItemsSource = allUsers;
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

        private async void OnFilterButtonClicked(object sender, EventArgs e)
        {
            try
            {
                if (_isDropDownVisible)
                {
                    await dropDownFrame.FadeTo(0, 250, Easing.Linear);
                    dropDownFrame.IsVisible = false;
                }
                else
                {
                    dropDownFrame.IsVisible = true;
                    await dropDownFrame.FadeTo(1, 250, Easing.Linear);
                }
                _isDropDownVisible = !_isDropDownVisible;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erreur", $"Une erreur s'est produite : {ex.Message}", "OK");
            }
        }

        private void OnLaboButtonClicked(object sender, System.EventArgs e)
        {
            _currentFilter = "Laboratoire";
            LoadUsers(_currentFilter);
        }

        private void OnMaintenanceButtonClicked(object sender, System.EventArgs e)
        {
            _currentFilter = "Maintenance";
            LoadUsers(_currentFilter);
        }

        private async void OnUserSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                if (e.SelectedItem == null)
                    return;

                var selectedUser = e.SelectedItem as User;

                var composeMessagePage = new ComposeMessagePage(selectedUser.Id, selectedUser.Nom);
                

                await Navigation.PushAsync(composeMessagePage);

                ((ListView)sender).SelectedItem = null;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erreur", $"Une erreur s'est produite : {ex.Message}", "OK");
            }
        }

        private void HandleSearch(object sender, TextChangedEventArgs e)
        {
            string keyword = e.NewTextValue.ToLower();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                userListView.ItemsSource = allUsers; // Afficher tous les utilisateurs si la barre de recherche est vide
            }
            else
            {
                userListView.ItemsSource = allUsers.Where(u => u.Nom.ToLower().Contains(keyword)).ToList(); // Filtrer les utilisateurs par nom
            }
        }



        public class UserListApiResponse
        {
            public List<User> Items { get; set; }
        }

        public class User
        {
            public string Id { get; set; }
            public string Nom { get; set; } = string.Empty;
            public string Email { get; set; }
            public string Password { get; set; }
            public string PostPicker { get; set; }
            public Color TextColor { get; set; }
            public double TextSize { get; set; }

            public User()
            {
                TextColor = Color.Black;
                TextSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            }
        }
    }
}

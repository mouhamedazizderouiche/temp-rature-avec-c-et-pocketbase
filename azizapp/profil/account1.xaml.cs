using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static azizapp.MainPage;

namespace azizapp.profil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class account1 : ContentPage
    {
        public account1()
        {
            InitializeComponent();

        }


        private async void Deconnexion_Clicked(object sender, EventArgs e)
        {
            SessionManager.CurrentUserId = null;

            await Navigation.PopToRootAsync();
        }
        private async void ModifierProfil_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ModifieAccount());
        }
        private async void Informations_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new AccountInformation());
        }
    }
}
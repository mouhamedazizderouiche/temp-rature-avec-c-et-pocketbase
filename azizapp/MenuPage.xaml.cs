using System;



using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace azizapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }
        private async void MenuButton_Clicked(object sender, EventArgs e)
        {
        }
        private async void Option1_Clicked(object sender, EventArgs e)
        {
            if (Application.Current.MainPage is MasterDetailPage masterDetailPage)
            {
                masterDetailPage.IsPresented = false; // Masquer le menu
                if (masterDetailPage.Detail is NavigationPage navigationPage)
                {
                    await navigationPage.PushAsync(new add());
                }
            }
        }



        private async void Option3_Clicked(object sender, EventArgs e)
        {
#pragma warning disable CS0618 // Le type ou le membre est obsolète
            if (Application.Current.MainPage is MasterDetailPage masterDetailPage)
            {
                masterDetailPage.IsPresented = false; // Masquer le menu
                if (masterDetailPage.Detail is NavigationPage navigationPage)
                {
                    await navigationPage.PushAsync(new UserListPage());
                }
            }
#pragma warning restore CS0618 // Le type ou le membre est obsolète
        }
    }
}
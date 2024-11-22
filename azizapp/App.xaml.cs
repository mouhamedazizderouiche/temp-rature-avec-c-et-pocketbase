using System;
using Xamarin.Forms;
using System.IO;
using azizapp.home;
using SQLite;
namespace azizapp
{
    public partial class App : Application
    {
        public static string CurrentUserId { get; set; }
        public static string UserType { get; set; }
        public App()
        {
            InitializeComponent();
            var mainPageNavigation = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.White
            };



#pragma warning disable CS0618 // Le type ou le membre est obsolète
            MainPage = new MasterDetailPage
            {
                Master = new MenuPage(),
                Detail = mainPageNavigation
            };
#pragma warning restore CS0618 // Le type ou le membre est obsolète


        }

#pragma warning disable CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone
        protected override async void OnStart()
#pragma warning restore CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone
        {

        }

#pragma warning disable CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone
        protected override async void OnSleep()
#pragma warning restore CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone
        {

        }

#pragma warning disable CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone
        protected override async void OnResume()
#pragma warning restore CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone
        {
            ;
        }

    }

    internal class UserService
    {
        private SQLiteAsyncConnection database;

        public UserService(SQLiteAsyncConnection database)
        {
            this.database = database;
        }
    }
}

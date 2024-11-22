using azizapp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace azizapp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
using ShoppingP6_EdisonChavarriaVasquez.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ShoppingP6_EdisonChavarriaVasquez.Views
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
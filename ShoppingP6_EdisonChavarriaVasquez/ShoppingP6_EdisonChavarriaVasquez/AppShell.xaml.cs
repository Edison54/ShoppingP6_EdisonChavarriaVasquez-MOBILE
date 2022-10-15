using ShoppingP6_EdisonChavarriaVasquez.ViewModels;
using ShoppingP6_EdisonChavarriaVasquez.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ShoppingP6_EdisonChavarriaVasquez
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}

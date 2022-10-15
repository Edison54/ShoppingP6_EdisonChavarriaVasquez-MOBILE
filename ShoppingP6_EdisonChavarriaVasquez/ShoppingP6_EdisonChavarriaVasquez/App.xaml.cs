using ShoppingP6_EdisonChavarriaVasquez.Services;
using ShoppingP6_EdisonChavarriaVasquez.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingP6_EdisonChavarriaVasquez
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

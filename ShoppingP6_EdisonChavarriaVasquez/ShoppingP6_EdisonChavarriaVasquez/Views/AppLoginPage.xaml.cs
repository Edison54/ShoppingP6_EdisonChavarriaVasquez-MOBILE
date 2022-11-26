using ShoppingP6_EdisonCV.ViewModels;
using ShoppingP6_EdisonCV.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ShoppingP6_EdisonCV;

namespace ShoppingP6_EdisonChavarriaVasquez.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppLoginPage : ContentPage
    {

        UserViewModel vm;
        public AppLoginPage()
        {

            InitializeComponent();

            this.BindingContext = vm = new UserViewModel();
        }
        private void CmdWatchPassword(Object sender , ToggledEventArgs e)
        {
            if (WatchPassword.IsToggled)
            {
                TxtPassword.IsPassword = false;
            }
            else
            {
                TxtPassword.IsPassword = true;
            }

        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserSignUpPage());
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {



           

            bool R = false;
            if (TxtUsername.Text != null && !string.IsNullOrEmpty(TxtUsername.Text.Trim())&&
               TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {

                try
                {
                    UserDialogs.Instance.ShowLoading("Checking user data . . .");
                    await Task.Delay(1000);
                    string u = TxtUsername.Text.Trim();
                    string p = TxtPassword.Text.Trim();

                    R = await vm.UserAccessValidation(u, p);

                  
                }
                catch (Exception)
                {

                    throw;
                }
                finally 
                {

                    UserDialogs.Instance.HideLoading();
                }
              

               
            }
            else
            {
                await DisplayAlert("validation error", "User and password is needed", "OK");
                return;
            }
        

            if (R)
            {

                try
                {
                    //todo: cargar info en un objeto global tipo user (o userDTO)
                    GlobalObjects.GlobalUser = await vm.GetUserData(TxtUsername.Text.Trim());
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "OK");
                    return;
                }
               

                await Navigation.PushAsync(new ActionMenuPage());
               
            }
            else
            {
                await DisplayAlert(":c", "Incorrect Username or password", "OK");
            }
        }
    }
}
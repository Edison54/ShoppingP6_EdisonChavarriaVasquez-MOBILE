using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingP6_EdisonChavarriaVasquez.ViewModels;
using ShoppingP6_EdisonCV.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingP6_EdisonCV.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserSignUpPage : ContentPage
    {


        UserViewModel viewModel;
        public UserSignUpPage()
        {
            InitializeComponent();
            //se agrega un biding context
            BindingContext = viewModel = new UserViewModel();
            LoadUserRolesList();
            LoadCountryList();
        }


        private async void LoadUserRolesList()
        {
            PckUserRoles.ItemsSource = await viewModel.GetUserRolelist();
        }

        private async void LoadCountryList()
        {
            PckCountry.ItemsSource = await viewModel.GetCountrylist();
        }



        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private  async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            //EN ESTE CASO LA LLAMADA A LA FUNCIONALIDAD NO SERA POR COMMAND
            //TO DO IMPLEMENTAR COMMAND
            bool R = await viewModel.AddNewUser(TxtName.Text.Trim(),
                 TxtEmail.Text.Trim(),
                 TxtPassword.Text.Trim(),
                 TxtEmailBackup.Text.Trim(),
                 TxtPhone.Text.Trim());

            if (R)
            {
                await DisplayAlert(":)", "Everyting is OK", "OK");
                await Navigation.PopAsync();

            }
            else
            {
                await DisplayAlert(":C", "Someting went wrong", "OK");
            }
        }
    }
}
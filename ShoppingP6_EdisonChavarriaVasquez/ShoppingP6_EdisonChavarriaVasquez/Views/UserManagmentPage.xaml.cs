using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ShoppingP6_EdisonCV.Models;
using ShoppingP6_EdisonCV.ViewModels;

namespace ShoppingP6_EdisonCV.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserManagmentPage : ContentPage
    {


        UserViewModel viewModel;
        public UserManagmentPage()
        {
            InitializeComponent();

            //se agrega un biding context
            BindingContext = viewModel = new UserViewModel();
            LoadUserRolesList();
            LoadCountryList();
            //llenar campso con data del user con el usuario global.
            LoadUserData();
        }


        private async void LoadUserData()
        {
            TxtName.Text = GlobalObjects.GlobalUser.Nombre;
            TxtEmail.Text = GlobalObjects.GlobalUser.CorreoElectronico;
            TxtEmailBackup.Text = GlobalObjects.GlobalUser.CorreoRespaldo;
            TxtPhone.Text = GlobalObjects.GlobalUser.NumeroTelefono;
            

        }



        private async void LoadUserRolesList()
        {
            PckUserRoles.ItemsSource = await viewModel.GetUserRolelist();
        }

        private async void LoadCountryList()
        {
            PckCountry.ItemsSource = await viewModel.GetCountrylist();
        }

        private void BtnAdd_Clicked(object sender, EventArgs e)
        {

        }


        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }







    }
}
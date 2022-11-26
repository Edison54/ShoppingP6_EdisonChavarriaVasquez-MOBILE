using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingP6_EdisonChavarriaVasquez.ViewModels;
using ShoppingP6_EdisonCV.Models;
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


        private bool UserImputValidation()
        {
            bool R = false;

            if (TxtName.Text != null && !string.IsNullOrEmpty(TxtName.Text.Trim()) &&
               TxtEmail.Text != null && !string.IsNullOrEmpty(TxtEmail.Text.Trim()) &&
               TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()) &&
               TxtEmailBackup.Text != null && !string.IsNullOrEmpty(TxtEmailBackup.Text.Trim()) &&
               TxtPhone.Text != null && !string.IsNullOrEmpty(TxtPhone.Text.Trim()) &&
               PckUserRoles.SelectedIndex >-1 && PckCountry.SelectedIndex > -1)
              
               {
                R = true;

            }
            else
            {

                if(TxtName.Text == null || string.IsNullOrEmpty(TxtName.Text.Trim()))
                {
                    DisplayAlert("Validation error", "User name is needed","OK");
                    TxtName.Focus();
                    return false;
                }
                if (TxtEmail.Text == null || string.IsNullOrEmpty(TxtEmail.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Email is needed", "OK");
                    TxtEmail.Focus();
                    return false;
                }
                if (TxtPassword.Text == null || string.IsNullOrEmpty(TxtPassword.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Password is needed", "OK");
                    TxtPassword.Focus();
                    return false;
                }
                if (TxtEmailBackup.Text == null || string.IsNullOrEmpty(TxtEmailBackup.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Backup email is needed", "OK");
                    TxtEmailBackup.Focus();
                    return false;
                }
                if (TxtPhone.Text == null || string.IsNullOrEmpty(TxtPhone.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Phone is needed", "OK");
                    TxtPhone.Focus();
                    return false;
                }
                if (PckUserRoles.SelectedIndex == -1)
                {
                    DisplayAlert("Validation error", "User role is needed", "OK");
                    //PckUserRoles.Focus();
                    return false;
                }
                if (PckCountry.SelectedIndex == -1)
                {
                    DisplayAlert("Validation error", "User role is needed", "OK");
                   // PckCountry.Focus();
                    return false;
                }

            }

            return R;
        }
        private  async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            //EN ESTE CASO LA LLAMADA A LA FUNCIONALIDAD NO SERA POR COMMAND
            if (UserImputValidation())
            {
            //TO DO IMPLEMENTAR COMMAND
            int IdRol = 1;

  
                UserRole UsrRol = PckUserRoles.SelectedItem as UserRole;

                IdRol = UsrRol.IduserRole;
            
            int IdCountry = 1;

           
                Country countryid = PckCountry.SelectedItem as Country;

                IdCountry = countryid.Idcountry;
            


            //confirmacion

            var answer = await DisplayAlert("Confirmation required","Are you sure?","Yes", "No");

            if (answer)
            {
                bool R = await viewModel.AddNewUser(TxtName.Text.Trim(),
                               TxtEmail.Text.Trim(),
                               TxtPassword.Text.Trim(),
                               TxtEmailBackup.Text.Trim(),
                               TxtPhone.Text.Trim(),
                               IdRol, IdCountry);

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
    }
}

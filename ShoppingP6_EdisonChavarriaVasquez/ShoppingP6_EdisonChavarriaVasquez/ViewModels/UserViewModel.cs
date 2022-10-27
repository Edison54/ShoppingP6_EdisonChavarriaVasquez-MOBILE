using ShoppingP6_EdisonChavarriaVasquez.ViewModels;
using ShoppingP6_EdisonCV.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingP6_EdisonCV.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public UserRole MyUserRole { get; set; }

        public User MyUser { get; set; }
      
        public UserViewModel()
        {
            MyUserRole = new UserRole();
            MyUser = new User();
        }

        public async Task<List<UserRole>> GetUserRolelist()
        {

            try
            {
                List<UserRole> list = new List<UserRole>();

                list = await MyUserRole.GetUserRoles();

                if (list == null)
                {
                    return null;
                }
                else
                {
                    return list;
                }
            }
            catch(Exception)
            {

                return null;
            }
        }



        //funcion para agregar usuario

        public async Task<bool> AddNewUser(
            string pName,
            string pEmail,
            string pPassword,
            string pBckupEmail,
            string pPhoneNumber,
            int pUserRole = 1,
            int pCountry = 1)
        {
            if (IsBusy)return false;
            IsBusy = true;
            try
            {
                MyUser.Name = pName;
                MyUser.Email = pEmail;
                MyUser.BackUpEmail = pBckupEmail;
                MyUser.PhoneNumber = pPhoneNumber;
                MyUser.UserPassword = pPassword;
                MyUser.IduserRole = pUserRole;
                MyUser.Idcountry = pCountry;

                bool R = await MyUser.AddUser();
                return R;
            }
            catch(Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
                   }
    }
}

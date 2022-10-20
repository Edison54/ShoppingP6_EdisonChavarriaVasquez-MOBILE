using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingP6_EdisonCV.Models
{
    public class UserRole
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }

        public int IduserRole { get; set; }
        public string UserRoleDescription { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}

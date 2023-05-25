using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Authentication
{
    public class UserSellerLogin
    {
        [Required(ErrorMessage = "User Email Is Mandetory")]
        public string email { get; set; }
        [Required(ErrorMessage = "Password Is Mandetory")]
        public string password { get; set; }
    }
}

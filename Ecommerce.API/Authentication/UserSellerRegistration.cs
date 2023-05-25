using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Authentication
{
    public class UserSellerRegistration
    {
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int role { get; set; }
    }
}
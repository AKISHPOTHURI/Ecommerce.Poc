using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Api.Model
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Role { get; set; }

        public virtual Role RoleNavigation { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

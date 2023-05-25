using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Api.Model
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
        }

        public int Id { get; set; }
        public int SellerId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Colour { get; set; }
        public int Category { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }

        public virtual Category CategoryNavigation { get; set; }
        public virtual Colour ColourNavigation { get; set; }
        public virtual User Seller { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}

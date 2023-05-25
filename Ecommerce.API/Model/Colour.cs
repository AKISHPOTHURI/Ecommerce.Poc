using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Api.Model
{
    public partial class Colour
    {
        public Colour()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Colour1 { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

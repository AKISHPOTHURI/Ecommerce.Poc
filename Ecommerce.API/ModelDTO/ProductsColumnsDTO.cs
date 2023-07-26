namespace Ecommerce.Api.ModelDTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductsColumnsDTO
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Colour { get; set; }
        public int Category { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.ModelDTO
{
    public class ProductsPostDTO
    {
        public int id { get; set; }
        public int sellerId { get; set; }
        public string productName { get; set; }
        public int price { get; set; }
        public int colour { get; set; }
        public int category { get; set; }
        public string description { get; set; }
        public string imagelink { get; set; }
    }
}

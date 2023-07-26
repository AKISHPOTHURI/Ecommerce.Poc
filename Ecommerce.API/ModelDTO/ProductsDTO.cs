using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.ModelDTO
{
    public class ProductsDTO
    {
        public int productId { get; set; }
        public int sellerID { get; set; }
        public string sellerName { get; set; }
        public string productName { get; set; }
        public string price { get; set; }
        public string colour { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string image { get; set; }
    }
}

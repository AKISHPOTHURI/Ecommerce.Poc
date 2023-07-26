namespace Ecommerce.Api.ModelDTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CartDTO
    {
        public int quantity { get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public string imageurl { get; set; }
        public string colour { get; set; }
        public string category { get; set; }
        
        
    }
}

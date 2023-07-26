namespace Ecommerce.Api.ModelDTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class importProductsMessage
    {
        public string ProductName { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }
}

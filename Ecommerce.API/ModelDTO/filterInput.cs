namespace Ecommerce.Api.ModelDTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class filterInput
    {
        public int seller { get; set; }
        public int? colour { get; set; }
        public int? category { get; set; }  
    }
}

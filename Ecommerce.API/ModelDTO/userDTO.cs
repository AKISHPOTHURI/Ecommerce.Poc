using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.ModelDTO
{
    public class userDTO
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public int role { get; set; }
    }
}

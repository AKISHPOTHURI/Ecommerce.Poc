using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Authentication
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public userdata data { get; set; }
        public string Token { get; set; }
    }
}

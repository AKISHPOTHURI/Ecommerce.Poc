using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.ModelDTO
{
    public class EmailDTO
    {
        [Required]
        public string email { get; set; }
    }
}

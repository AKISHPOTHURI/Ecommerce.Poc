﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Api.Model
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}

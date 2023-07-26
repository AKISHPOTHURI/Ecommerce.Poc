namespace Ecommerce.Api.IRepository
{
    using Ecommerce.Api.ModelDTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICartRepository
    {
        public Task<List<CartDTO>> GetCart(int userId);
    }
}

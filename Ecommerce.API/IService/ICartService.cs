namespace Ecommerce.Api.IService
{
    using Ecommerce.Api.ModelDTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICartService
    {
        public Task<Result<List<CartDTO>>> GetCart(int userId);
    }
}

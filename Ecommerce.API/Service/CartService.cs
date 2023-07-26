namespace Ecommerce.Api.Service
{
    using Ecommerce.Api.IRepository;
    using Ecommerce.Api.IService;
    using Ecommerce.Api.ModelDTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<Result<List<CartDTO>>> GetCart(int userId)
        {
            var response =await _cartRepository.GetCart(userId);
            return Result.Ok(response);
        }
    }
}

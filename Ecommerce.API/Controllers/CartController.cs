namespace Ecommerce.Api.Controllers
{
    using Ecommerce.Api.IService;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet]
        public  async Task<IActionResult> GetCart([FromQuery] int userId)
        {
            var result = await _cartService.GetCart(userId);
            return Ok(result.Value); 
        }
        //[HttpGet]
        //public async Task<IActionResult> GetDerpartmentTemp([FromQuery] int userId)
        //{
        //    var result = await _cartService.GetCart(userId);
        //    return Ok(result.Value);
        //}

    }
}

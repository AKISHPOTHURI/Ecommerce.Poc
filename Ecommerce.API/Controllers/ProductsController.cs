using Ecommerce.Api.IService;
using Ecommerce.Api.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productService;
        private readonly IConfiguration _configuration;

        public ProductsController(IProductsService productsService, IConfiguration configuration)
        {
            _productService = productsService;
            _configuration = configuration;
        }

        [HttpPost("InsertProducts")]
        public async Task<IActionResult> InsertProducts([FromQuery]ProductsPostDTO productsPost)
        {
            var response = await _productService.productInsert(productsPost);
            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }
            return Ok(response);
           
        }
    }
}

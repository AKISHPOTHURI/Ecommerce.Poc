using ClosedXML.Excel;
using Ecommerce.Api.Authentication;
using Ecommerce.Api.IService;
using Ecommerce.Api.Model;
using Ecommerce.Api.ModelDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productService;
        private readonly IConfiguration _configuration;

        public ProductsController(IProductsService productsService, IConfiguration configuration)
        {
            _productService = productsService;
            _configuration = configuration;
        }

        //[AllowAnonymous]
        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _productService.GetProducts();
            //if (result.Rows.Count <= 0)
            //{
            //    return NotFound("The Data Table was Empty");
            //}
            //using (XLWorkbook wb = new XLWorkbook())
            //{
            //    wb.Worksheets.Add(result);
            //    using (MemoryStream stream = new MemoryStream())
            //    {
            //        wb.SaveAs(stream);
            //        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ProductList.xlsx");
            //    }
            //};
            //if (!result.IsSucceeded)
            //{
            //    return BadRequest(result.GetErrorString());
            //}
            return Ok(result);
        }

        [Authorize(Roles = UserRoles.Seller)]
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

        [Authorize(Roles = UserRoles.Seller)]
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _productService.RemoveProduct(id);
            if (!response.IsSucceeded)
            {
                return BadRequest(response.GetErrorString());
            }
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("productFilter")]
        public async Task<IActionResult> productFilter([FromQuery]filterInput filterInput)
        {
            var response = await _productService.productFilter(filterInput);
            return Ok(response);
        }

        [HttpPost("importProducts")]
        public async Task<IActionResult> importProducts(IFormFile file)
        {
            var response = await _productService.BulkUploadandUpdate(file);
            return Ok(response);
        }
    }
}
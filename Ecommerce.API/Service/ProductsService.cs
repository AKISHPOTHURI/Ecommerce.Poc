using Ecommerce.Api.IRepository;
using Ecommerce.Api.IService;
using Ecommerce.Api.Model;
using Ecommerce.Api.ModelDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Service
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }


        public async Task<List<ProductsDTO>> GetProducts()
        {
                var response = await _productsRepository.GetProducts();
                return (response);
        }
        public async Task<Result<string>> productInsert(ProductsPostDTO productsPost)
        {
            try
            {
                var response = await _productsRepository.productInsert(productsPost);
                return Result.Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            

        }

        public async Task<Result<bool>> RemoveProduct(int id)
        {
            try
            {
                var response = await _productsRepository.RemoveProduct(id);
                return Result.Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<string>> productFilter(filterInput filterInput) 
        {
            var result = await _productsRepository.productFilter(filterInput);
            return result;
        }

        public async Task<List<importProductsMessage>> BulkUploadandUpdate(IFormFile file)
        {
            var result = await _productsRepository.BulkUploadandUpdate(file);
            return result;
        }
    }
}

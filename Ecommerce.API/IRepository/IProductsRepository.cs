using Ecommerce.Api.Model;
using Ecommerce.Api.ModelDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.IRepository
{
    public interface IProductsRepository
    {
        public Task<List<ProductsDTO>> GetProducts();
        public Task<string> productInsert(ProductsPostDTO productsPost);
        public Task<bool> RemoveProduct(int id);
        public Task<List<string>> productFilter(filterInput filterInput);
        public Task<List<importProductsMessage>> BulkUploadandUpdate(IFormFile file);

    }
}

namespace Ecommerce.Api.IService
{
    using Ecommerce.Api.Model;
    using Ecommerce.Api.ModelDTO;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IProductsService
    {
        public Task<List<ProductsDTO>> GetProducts();
        public Task<Result<string>> productInsert(ProductsPostDTO productsPost);
        public Task<Result<bool>> RemoveProduct(int id);
        public Task<List<string>> productFilter(filterInput filterInput);
        public Task<List<importProductsMessage>> BulkUploadandUpdate(IFormFile file);

    }
}

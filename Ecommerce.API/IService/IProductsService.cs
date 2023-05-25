namespace Ecommerce.Api.IService
{
    using Ecommerce.Api.ModelDTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IProductsService
    {
        public Task<Result<string>> productInsert(ProductsPostDTO productsPost);
        public Task<Result<bool>> RemoveProduct(int id);
    }
}

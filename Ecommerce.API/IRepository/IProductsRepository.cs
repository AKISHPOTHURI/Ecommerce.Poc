using Ecommerce.Api.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.IRepository
{
    public interface IProductsRepository
    {
        public Task<string> productInsert(ProductsPostDTO productsPost);
    }
}

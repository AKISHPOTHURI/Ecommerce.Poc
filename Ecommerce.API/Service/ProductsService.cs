namespace Ecommerce.Api.Service
{
    using Ecommerce.Api.IRepository;
    using Ecommerce.Api.IService;
    using Ecommerce.Api.ModelDTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
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
    }
}

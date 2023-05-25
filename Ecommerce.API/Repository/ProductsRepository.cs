using Ecommerce.Api.IRepository;
using Ecommerce.Api.Model;
using Ecommerce.Api.ModelDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        protected readonly EcommerceContext _dbContext;
        public IConfiguration _configuration { get; }

        public ProductsRepository(EcommerceContext dbContext,IConfiguration configuration)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public async Task<string> productInsert(ProductsPostDTO productsPost)
        {
            var productTable = await _dbContext.Products.Where(x => x.Id == productsPost.id).FirstOrDefaultAsync();
            if (productTable != null)//insert the data
            {
                productTable.SellerId = productsPost.sellerId;
                productTable.ProductName = productsPost.productName;
                productTable.Price = productsPost.price;
                productTable.Colour = productsPost.colour;
                productTable.Category = productsPost.category;
                productTable.ProductDescription = productsPost.description;
                productTable.ProductImage = productsPost.imagelink;

                _dbContext.Products.Update(productTable);
                await _dbContext.SaveChangesAsync();
                return "Updated";
            }
            else //edit the data
            {
                var prod = new Product()
                {
                    SellerId = productsPost.sellerId,
                    ProductName = productsPost.productName,
                    Price = productsPost.price,
                    Colour = productsPost.colour,
                    Category = productsPost.category,
                    ProductDescription = productsPost.description,
                    ProductImage = productsPost.imagelink
                };
                await _dbContext.Products.AddAsync(prod);
                await _dbContext.SaveChangesAsync();
                return "Data Inserted";
            }
        }
    }
}

using AutoMapper;
using ClosedXML.Excel;
using Ecommerce.Api.Common.Constants;
using Ecommerce.Api.IRepository;
using Ecommerce.Api.Model;
using Ecommerce.Api.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Api.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly EcommerceContext _dbContext;
        public IConfiguration _configuration { get; }
        private readonly IMapper _mapper;

        public ProductsRepository(EcommerceContext dbContext, IConfiguration configuration,IMapper mapper)
        {
            _configuration = configuration;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ProductsDTO>> GetProducts()
        {
            List<ProductsDTO> products = new List<ProductsDTO>();
            using (var con = _dbContext.Database.GetDbConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(Constants.GetProducts, (SqlConnection)con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    var product = _mapper.Map<ProductsDTO>(row);
                    products.Add(product);
                }
                //return products;
            }
            DataTable dataTableExcel = new DataTable("ProductList");
            dataTableExcel.Columns.AddRange(new DataColumn[8] {
                                        new DataColumn("Id"),
                                        new DataColumn("SellerId"),
                                        new DataColumn("ProductName"),
                                        new DataColumn("Price"),
                                        new DataColumn("Colour"),
                                        new DataColumn("Category"),
                                        new DataColumn("ProductDescription"),
                                        new DataColumn("ProductImage")

                                         });
            foreach (var product in products)
            {
                DataRow dataRow = dataTableExcel.NewRow();
                dataRow["Id"] = product.productId;
                dataRow["SellerId"] = product.sellerID;
                dataRow["ProductName"] = product.productName;
                dataRow["Price"] = product.price;
                dataRow["Colour"] = product.colour;
                dataRow["Category"] = product.category;
                dataRow["ProductDescription"] = product.description;
                dataRow["ProductImage"] = product.image;
                dataTableExcel.Rows.Add(dataRow);
            }
            return await Task.FromResult(products);
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

        public async Task<bool> RemoveProduct(int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return false;
            }
            else
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<string>> productFilter(filterInput filterInput)
        {
            var sellerList = new List<string>();
            if (filterInput.seller == null && filterInput.category == null && filterInput.colour == null)            
            {
                var response = _dbContext.Products.Include(s => s.Seller).ToList();
                //.Where(x => x.SellerId == filterInput.seller);
                //.Where(x => x.SellerId == filterInput.seller && x.Colour == filterInput.colour && x.Category == filterInput.category);
                

                foreach (Product row in response)
                {
                    var list = row.Seller.UserName;
                    sellerList.Add(list);
                }                
            }
            return sellerList;
        }

        public async Task<List<importProductsMessage>> BulkUploadandUpdate(IFormFile file)
        {
            var allmessages = new List<importProductsMessage>();
            if (file == null)
            {
                var error = new importProductsMessage()
                {
                    Message = "No file uploaded."
                };
                allmessages.Add(error);
                return allmessages;
            }
            using var stream = new MemoryStream();
            file.CopyTo(stream);
            XLWorkbook wbook = null;
            try
            {
                wbook = new XLWorkbook(stream);
            }
            catch
            {
                var error = new importProductsMessage()
                {
                    Message = "The uploaded file cannot be read. Please upload an excel file."
                };
                allmessages.Add(error);
                return allmessages;
            }

            var ws1 = wbook.Worksheets.FirstOrDefault();
            if (!ws1.IsEmpty())
            {
                var firstRow = ws1.FirstRowUsed().RowNumber();
                List<string> fileColumns = new List<string>();
                List<string> templateColumns = new List<string>();
                var properties = typeof(ProductsColumnsDTO).GetProperties();
                var count = 0; 
                foreach (IXLCell cell in ws1.FirstRowUsed().CellsUsed())
                {
                    fileColumns.Add(cell.Value.ToString().Replace(" ", ""));
                }
                foreach (var prop in properties)
                {
                    templateColumns.Add(prop.Name.ToString());
                }
                if (templateColumns.Count == fileColumns.Count)
                {
                    for (var i = 0; i < templateColumns.Count; i++)
                    {
                        if (fileColumns[i] == templateColumns[i])
                            count++;
                    }
                }
                if (count != templateColumns.Count)
                {
                    var error = new importProductsMessage()
                    {
                        Message = "The uploaded file does not follow the template. Please download the template and add users' data."
                    };
                    allmessages.Add(error);
                    return allmessages;
                }

                //reading individual rows
                foreach (var row in ws1.RowsUsed().Skip(1))
                {
                    var obj = new ProductsColumnsDTO();
                    StringBuilder message = new StringBuilder("");
                    string catchprop = null;

                    //mapping cell values to corresponding properties of DTO
                    var colIndex = ws1.FirstColumnUsed().ColumnNumber();
                    foreach (var prop in properties)
                    {
                        var val = row.Cell(colIndex).Value;
                        var type = prop.PropertyType;
                        try
                        {
                            if (val.ToString() == "")
                            {
                                if (type == typeof(int))
                                    val = 0;
                                else
                                    val = null;
                            }
                            prop.SetValue(obj, Convert.ChangeType(val, type));
                        }
                        catch
                        {
                            if (type == typeof(int))
                                message.Append($"{ws1.Cell(firstRow, colIndex).Value} must have numbers only. ");
                            else
                                message.Append($"{ws1.Cell(firstRow, colIndex).Value} is not in correct format. ");
                            val = null;
                            catchprop = ws1.Cell(firstRow, colIndex).Value.ToString();
                            colIndex++;
                            continue;
                        }
                        colIndex++;
                    }

                    //validations for data
                    Product product = new Product();
                    //Employee employee = new Employee();
                    var validator = new ProductsDTOValidations();
                    var validationResult = validator.Validate(obj);
                    if (obj != null)
                    {
                        //employee = _mapper.Map<Employee>(obj);
                        product.Id = obj.Id;
                        product.SellerId = obj.SellerId;
                        product.ProductName = obj.ProductName;
                        product.Price = obj.Price;
                        product.Colour = obj.Colour;
                        product.Category = obj.Category;
                        product.ProductDescription = obj.ProductDescription;
                        product.ProductImage = obj.ProductImage;                     
                    }
                    else
                    {
                        foreach (var failure in validationResult.Errors)
                        {
                            if (catchprop != null)
                            {
                                failure.ErrorMessage = failure.ErrorMessage.Contains(catchprop) ? "" : failure.ErrorMessage;
                            }
                            message.Append(failure.ErrorMessage);
                        }
                    }

                    //add or update
                    var ImportUserMessage = new importProductsMessage()
                    {
                        ProductName = obj.ProductName
                    };
                    if (message.ToString() != "")
                    {
                        ImportUserMessage.Message = message.ToString();
                        ImportUserMessage.Status = "Failure";
                        allmessages.Add(ImportUserMessage);
                        continue;
                    }
                    else
                    {
                        //user.ModifiedDate = DateTime.Now;
                        if (_dbContext.Products.Select(u => u.ProductName).Contains(obj.ProductName))
                        {
                            var a = _dbContext.Products.First(x => x.ProductName == obj.ProductName);
                            _dbContext.Entry(a).State = EntityState.Detached;
                            product.Id = a.Id;
                            _dbContext.Products.Update(product);
                            message.Append("User updated.");
                        }
                        else
                        {
                            _dbContext.Products.Add(product);
                            message.Append("User added.");
                        }
                        await _dbContext.SaveChangesAsync();
                        ImportUserMessage.Message = message.ToString();
                        ImportUserMessage.Status = "Success";
                    }
                    allmessages.Add(ImportUserMessage);
                }
                if (ws1.RowsUsed().Skip(1).Count() == 0)
                {
                    var error = new importProductsMessage()
                    {
                        Message = "The uploaded file has no data to import."
                    };
                    allmessages.Add(error);
                }
            }
            else
            {
                var error = new importProductsMessage()
                {
                    Message = "The uploaded file is empty."
                };
                allmessages.Add(error);
            }
            return allmessages;
        }

    }
}

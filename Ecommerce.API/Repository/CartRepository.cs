using AutoMapper;
using Ecommerce.Api.Common.Constants;
using Ecommerce.Api.IRepository;
using Ecommerce.Api.Model;
using Ecommerce.Api.ModelDTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Repository
{
    public class CartRepository: ICartRepository
    {
        private readonly EcommerceContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public CartRepository(EcommerceContext dbContext,IConfiguration configuration,IMapper mapper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<List<CartDTO>> GetCart(int userId)
        {
            List<CartDTO> cart = new List<CartDTO>();
            using (var con = _dbContext.Database.GetDbConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(Constants.Cart, (SqlConnection)con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id", userId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //var CartDto = new CartDTO();
                foreach(DataRow row in dt.Rows)
                {
                    var cartDTO = _mapper.Map<CartDTO>(row);
                    cart.Add(cartDTO);
                }
                return cart;
            }
        }
        //Scaffold-DbContext "Server=GGKU4DELL1254;Database=Ecommerce;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model
        //public async Task<List<DepartmentDTO>> GetDerpartmentTemp()
        //{

        //}
    }
}

using Ecommerce.Api.Authentication;
using Ecommerce.Api.IRepository;
using Ecommerce.Api.Middleware;
using Ecommerce.Api.Model;
using Ecommerce.Api.ModelDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Api.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly EcommerceContext _dbContext;
        
        public IConfiguration _configuration { get; }
        public UserRepository(EcommerceContext dbContext,IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            //_tokenGeneration = tokenGeneration;
        }

        public async Task<Response> Login(UserSellerLogin userSellerLogin)
        {
            var user = await _dbContext.Users.Where(d => d.Email == userSellerLogin.email && d.Password == userSellerLogin.password)
                .FirstOrDefaultAsync();
            try
            {
                Response response = new Response
                {
                    IsSuccess = true,
                    Message = "login sucesscefull",
                    data = new userdata
                    {
                        id = user.Id,
                        userName = user.UserName,
                        email = user.Email,
                        role = (int)user.Role
                    },
                    Token = ""

                };
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}


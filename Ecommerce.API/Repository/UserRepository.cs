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
        public UserRepository(EcommerceContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            //_tokenGeneration = tokenGeneration;
        }

        public async Task<Response> Login(UserSellerLogin userSellerLogin)
        {
            var currentUser = await _dbContext.Users.Where(d => d.Email == userSellerLogin.email && d.Password == userSellerLogin.password)
                .FirstOrDefaultAsync();
            if(currentUser != null)
            {
                Response response = new Response
                {
                    IsSuccess = true,
                    Message = "Token Generated",
                    data = new userdata
                    {
                        id = currentUser.Id,
                        userName = currentUser.UserName,
                        email = currentUser.Email,
                        //role = (int)currentUser.Role                      
                    },
                    Token = ""

                };
                if (currentUser.Role == 1)
                {
                    response.data.role = UserRoles.User;
                }
                else if (currentUser.Role == 2)
                {
                    response.data.role = UserRoles.Seller;
                }
                else if (currentUser.Role == 3)
                {
                    response.data.role = UserRoles.Admin;
                }
                else if (currentUser.Role == 4)
                {
                    response.data.role = UserRoles.Guest;
                }
                return response;
            }
            else
            {
                throw new Exception("data not found");
            }
        }

        public async Task<string> RegisterUser(UserSellerRegistration userSellerRegistration)
        {
            var data = new User()
            {
                UserName = userSellerRegistration.userName,
                Email = userSellerRegistration.email,
                Password = userSellerRegistration.password,
                Role = userSellerRegistration.role
            };

            _dbContext.Users.AddAsync(data);
            await _dbContext.SaveChangesAsync();
            return "Registration is Successfull";
        }
    }
}


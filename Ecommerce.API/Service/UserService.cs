using Ecommerce.Api.Authentication;
using Ecommerce.Api.IRepository;
using Ecommerce.Api.IService;
using Ecommerce.Api.Middleware;
using Ecommerce.Api.Model;
using Ecommerce.Api.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenGeneration _tokenGeneration;
        public UserService(IUserRepository userRepository,ITokenGeneration tokenGeneration)
        {
            _userRepository = userRepository;
            _tokenGeneration = tokenGeneration;
        }

        public async Task<Response> Login(UserSellerLogin userSellerLogin)
        {
            try
            {
                var result = await _userRepository.Login(userSellerLogin);
                result.Token = await _tokenGeneration.GenerateJwt(result.data.id,result.data.userName,result.data.email,result.data.role);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

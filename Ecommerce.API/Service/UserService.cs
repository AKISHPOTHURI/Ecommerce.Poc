using Ecommerce.Api.Authentication;
using Ecommerce.Api.IRepository;
using Ecommerce.Api.IService;
using Ecommerce.Api.ModelDTO;
using System;
using System.Threading.Tasks;
using Ecommerce.Api.Middleware;

namespace Ecommerce.Api.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenGeneration _tokenGeneration;
        public UserService(IUserRepository userRepository, ITokenGeneration tokenGeneration)
        {
            _userRepository = userRepository;
            _tokenGeneration = tokenGeneration;
        }

        public async Task<Result<Response>> Login(UserSellerLogin userSellerLogin)
        {
            
            try
            {
                var result = await _userRepository.Login(userSellerLogin);
                result.Token = "Bearer " + await _tokenGeneration.GenerateJwt(result.data.id, result.data.userName, result.data.email, result.data.role);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Result<string>> RegisterUser(UserSellerRegistration userSellerRegistration)
        {
            try
            {
                var response = await _userRepository.RegisterUser(userSellerRegistration);

                return Result.Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

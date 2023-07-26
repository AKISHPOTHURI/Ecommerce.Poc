using Ecommerce.Api.Authentication;
//using Ecommerce.Api.Model;
using Ecommerce.Api.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.IService
{
    public interface IUserService
    {
        public Task<Result<Response>> Login(UserSellerLogin userSellerLogin);

        public Task<Result<string>> RegisterUser(UserSellerRegistration userSellerRegistration);


    }
}

namespace Ecommerce.Api.IRepository
{
    using Ecommerce.Api.Authentication;
    using Ecommerce.Api.Model;
    using Ecommerce.Api.ModelDTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IUserRepository
    {
        public Task<Response> Login(UserSellerLogin userSellerLogin);
        public Task<string> RegisterUser(UserSellerRegistration userSellerRegistration);
    }
}

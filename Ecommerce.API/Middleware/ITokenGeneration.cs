namespace Ecommerce.Api.Middleware
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ITokenGeneration
    {
        public Task<string> GenerateJwt(int userId, string userName, string email, string role);
    }
}

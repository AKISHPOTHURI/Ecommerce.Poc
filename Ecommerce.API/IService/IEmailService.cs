using Ecommerce.Api.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.IService
{
    public interface IEmailService
    {
        public Task<Result> SendEmail(EmailDTO request);
    }
}

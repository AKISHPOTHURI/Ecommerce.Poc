using Ecommerce.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.IService
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO request);
    }
}

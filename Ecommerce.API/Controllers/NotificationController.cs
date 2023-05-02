namespace Ecommerce.Api.Controllers
{
    using Ecommerce.Api.IService;
    using Ecommerce.Api.Models;
    using MailKit.Net.Smtp;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using MimeKit;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public NotificationController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        public IActionResult SendEmail(EmailDTO emailDTO)
        {
            _emailService.SendEmail(emailDTO);
            return Ok();
        }
    }
}

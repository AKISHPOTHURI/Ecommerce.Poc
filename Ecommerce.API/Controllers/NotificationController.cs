using Ecommerce.Api.IService;
using Ecommerce.Api.ModelDTO;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Controllers
{
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
        public async Task<IActionResult> SendEmail(EmailDTO emailDTO)
        {
            var response = await _emailService.SendEmail(emailDTO);

            if (!response.IsSucceeded)
            {
                return BadRequest("Please check the mail");
            }
            return Ok("Email sent Successfully");
        }
    }
}

using Ecommerce.Api.IService;
using Ecommerce.Api.ModelDTO;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Ecommerce.Api.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config.GetSection("SMTPConfig");
        }

        public async Task<Result> SendEmail(EmailDTO request)
        {
            //var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            //email.To.Add(MailboxAddress.Parse(request.email));
            //email.Subject = "Order";
            //email.Body = new TextPart(TextFormat.Html) { Text = "Order is successfully placed" };

            //using var smtp = new SmtpClient();
            //smtp.Connect(_config.GetSection("EmailHost").Value, 25, SecureSocketOptions.StartTls);
            //smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            //var x = smtp.Send(email);
            //smtp.Disconnect(true);
            MailMessage mail = new MailMessage()
            {
                Subject = "Hurrah",
                Body = "Your order was placed successfully,Keep Smiling.",
                From = new MailAddress(_config.GetSection("SenderAddress").Value,_config.GetSection("SenderDisplayName").Value),
                IsBodyHtml = Convert.ToBoolean(_config.GetSection("IsBodyHTML").Value)    
            };
            NetworkCredential networkCredential = new NetworkCredential(_config.GetSection("UserName").Value, _config.GetSection("Password").Value);
            System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient
            {
                Host = _config.GetSection("Host").Value,
                Port = Convert.ToInt32(_config.GetSection("Port").Value),
                EnableSsl = Convert.ToBoolean(_config.GetSection("EnableSSL").Value),
                UseDefaultCredentials = Convert.ToBoolean(_config.GetSection("UserDefaultCredentials").Value),
                Credentials = networkCredential
            };
            try
            {
                mail.To.Add(request.email);
                await smtpClient.SendMailAsync(mail);
                return Result.Ok();
            }
            catch(Exception ex)
            {
                //Console.WriteLine("something wrong");
                return Result.Fail(ex.Message);
            }
        }
    }
}

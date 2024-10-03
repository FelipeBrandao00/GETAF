using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace GETAF.Helper
{
    public class Email : IEmail
    {

        private readonly IConfiguration _configuration;

        public Email(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //API SendGrid
        public async Task<bool> EnviarAsync(string email, string assunto, string mensagem)
        {
            try
            {
                var apiKey = _configuration.GetValue<string>("SENDGRID_API_KEY");
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(_configuration.GetValue<string>("SMTP:UserName"), _configuration.GetValue<string>("SMTP:Nome"));
                var to = new EmailAddress(email);
                var msg = MailHelper.CreateSingleEmail(from, to, assunto, mensagem, mensagem);
                var response = await client.SendEmailAsync(msg);
                int porta = _configuration.GetValue<int>("SMTP:Porta");

                return response.StatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }
    }
}

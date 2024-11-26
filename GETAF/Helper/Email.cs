using System.ComponentModel.DataAnnotations;
using System.Net;
using SendGrid;
using SendGrid.Helpers.Mail;
using DotNetEnv;

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
        public async Task<bool> EnviarAsync(string email, string assunto, string mensagem) {
            try {
                Env.Load();
                var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY").ToString();
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(_configuration.GetValue<string>("SMTP:UserName"), _configuration.GetValue<string>("SMTP:Nome"));
                var to = new EmailAddress(email);
                var msg = MailHelper.CreateSingleEmail(from, to, assunto, mensagem, mensagem);
                var response = await client.SendEmailAsync(msg);

                return response.StatusCode == HttpStatusCode.Accepted;
            }
            catch (System.Exception ex) {
                return false;
            }
        }
    }
}

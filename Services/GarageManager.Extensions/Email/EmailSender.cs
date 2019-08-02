using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using GarageManager.Common.GlobalConstant;
using System.Threading.Tasks;

namespace GarageManager.Extensions.Email
{
    public class EmailSender : IEmailSender
    {
        private SendGridOptions options;

        public EmailSender(IOptions<SendGridOptions> options)
        {
            this.options = options.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(this.options.SendGridApiKey);
            var from = new EmailAddress(AdminContants.AdminEmail, $"GarageManager.com {AdminContants.AdminUserName}");
            var to = new EmailAddress(email, email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, htmlMessage, htmlMessage);
            var response = await client.SendEmailAsync(msg);
            var body = await response.Body.ReadAsStringAsync();
            var statusCode = response.StatusCode;
        }
    }
}

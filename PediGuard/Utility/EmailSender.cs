using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PediGuard.Utility
{
    public class EmailSender : IEmailSender
    {
        public string SendGridSecret { get; set; }
        private readonly IConfiguration _conf;

        public EmailSender(IConfiguration _config)
        {
            SendGridSecret = _config.GetValue<string>("SendGrid:SecretKey");
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                var client = new SendGridClient(SendGridSecret);
                var from = new EmailAddress("nanifulchany@gmail.com", "PediGuard");
                var to = new EmailAddress(email);
                var message = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);

                var response = await client.SendEmailAsync(message);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var responseBody = await response.Body.ReadAsStringAsync();
                    Console.WriteLine($"Failed to send email. Status code: {response.StatusCode}, Response body: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email sending failed: {ex.Message}");
                throw;
            }
        }

    }
}

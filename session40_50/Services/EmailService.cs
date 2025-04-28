using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using session40_50.Interfaces;

namespace session40_50.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration; //load environment variable from appseting.json file

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            //step 1: initial email mime
            var email = new MimeMessage();

            //step 2: setup information of sender (from)
            email.From.Add(MailboxAddress.Parse(_configuration["EmailSettings:From"]));

            //step 3: setup infor receiver (to)
            email.To.Add(MailboxAddress.Parse(to));

            //step 4: setup subject information (subject)
            email.Subject = subject;

            //step 5: setup email content (body)
            var builder = new BodyBuilder
            {
                HtmlBody = body
            };

            email.Body = builder.ToMessageBody();

            //step 6: config SMTP client
            var smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync(_configuration["EmailSettings:SmtpServer"],
            int.Parse(_configuration["EmailSettings:Port"]),
            SecureSocketOptions.StartTls);

            await smtpClient.AuthenticateAsync(_configuration["EmailSettings:Username"],
            _configuration["EmailSettings:Password"]);

            //step 7: send Email
            await smtpClient.SendAsync(email);

            //step 8: close connection
            await smtpClient.DisconnectAsync(true);

        }
    }
}

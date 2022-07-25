using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using WebApi.Helpers;
using System.Net.Mail;
using SmtpClient = System.Net.Mail.SmtpClient;

namespace WebApi.Services
{
    public interface IEmailService
    {
        void Send(string to, string subject, string html, string from = null);
    }

    public class EmailService : IEmailService
    {
        private readonly AppSettings _appSettings;

        public EmailService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public void Send(string to, string subject, string html, string from = null)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from ?? _appSettings.EmailFrom));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using var smtp = new SmtpClient();

            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();

            m.From = new MailAddress(_appSettings.EmailFrom);
            m.To.Add(to);
            m.Subject = subject;
            m.Body = html;
            m.IsBodyHtml = true;
            sc.Host = _appSettings.SmtpHost;

            string str1 = "gmail.com";
            string str2 = to;
            if (str2.Contains(str1))
            {
                sc.Port = 8889;
                sc.Credentials = new System.Net.NetworkCredential(_appSettings.EmailFrom, _appSettings.SmtpPass);
                sc.EnableSsl = false;
                sc.Send(m);

            }
            else
            {
                sc.Port = 25;
                sc.Credentials = new System.Net.NetworkCredential(_appSettings.EmailFrom, _appSettings.SmtpPass);
                sc.EnableSsl = false;
                sc.Send(m);
            }

            // smtp.Connect(_appSettings.SmtpHost, _appSettings.SmtpPort, SecureSocketOptions.Auto);
            // smtp.Authenticate(_appSettings.SmtpUser, _appSettings.SmtpPass);
            // smtp.Send(email);
            // smtp.Disconnect(true);
        }
    }
}
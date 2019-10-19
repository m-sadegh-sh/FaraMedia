namespace FaraMedia.Services.Utilities {
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;

    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Services.Systematic;

    public sealed class EmailSender: IEmailSender{
        public void SendEmail(EmailAccount emailAccount, string subject, string body, string fromAddress, string fromName, string toAddress, string toName, IEnumerable<string> bcc = null, IEnumerable<string> cc = null) {
            SendEmail(emailAccount, subject, body, new MailAddress(fromAddress, fromName), new MailAddress(toAddress, toName), bcc, cc);
        }

        public void SendEmail(EmailAccount emailAccount, string subject, string body, MailAddress from, MailAddress to, IEnumerable<string> bcc = null, IEnumerable<string> cc = null) {
            var message = new MailMessage {
                From = from
            };

            message.To.Add(to);

            if (null != bcc) {
                foreach (var address in bcc.Where(bccValue => !string.IsNullOrWhiteSpace(bccValue)))
                    message.Bcc.Add(address.Trim());
            }

            if (null != cc) {
                foreach (var address in cc.Where(ccValue => !string.IsNullOrWhiteSpace(ccValue)))
                    message.CC.Add(address.Trim());
            }

            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            using (var smtpClient = new SmtpClient()) {
                smtpClient.UseDefaultCredentials = emailAccount.UseDefaultCredentials;
                smtpClient.Host = emailAccount.Host;
                smtpClient.Port = emailAccount.Port;
                smtpClient.EnableSsl = emailAccount.SslEnabled;
                smtpClient.Credentials = emailAccount.UseDefaultCredentials ? CredentialCache.DefaultNetworkCredentials : new NetworkCredential(emailAccount.UserName, emailAccount.Password);
                smtpClient.Send(message);
            }
        }
    }
}
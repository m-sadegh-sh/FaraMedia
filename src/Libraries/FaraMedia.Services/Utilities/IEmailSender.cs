namespace FaraMedia.Services.Utilities {
    using System.Collections.Generic;
    using System.Net.Mail;

    using FaraMedia.Core.Domain.Systematic;

    public interface IEmailSender{
        void SendEmail(EmailAccount emailAccount, string subject, string body, string fromAddress, string fromName, string toAddress, string toName, IEnumerable<string> bcc = null, IEnumerable<string> cc = null);
        void SendEmail(EmailAccount emailAccount, string subject, string body, MailAddress from, MailAddress to, IEnumerable<string> bcc = null, IEnumerable<string> cc = null);
    }
}
namespace FaraMedia.Services.Installation.Systematic {
    using System;
    using System.Linq;

    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;
    using NHibernate.Linq;

    public class MessageTemplateInstaller : EntityInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(MessageTemplateConstants.Fields.SystemName.Label, "نام");
                NewResource(MessageTemplateConstants.Fields.DisplayName.Label, "نام");
                NewResource(MessageTemplateConstants.Fields.Description.Label, "نام");

                NewResource(MessageTemplateConstants.Fields.BccEmailAddresses.Label, "آدرس های ایمیل (بی سی سی)");
                NewResource(MessageTemplateConstants.Fields.Subject.Label, "عنوان");
                NewResource(MessageTemplateConstants.Fields.Body.Label, "متن (بدنه)");

                NewResource(MessageTemplateConstants.Fields.EmailAccount.Label, "حساب ایمیل");

                transaction.Commit();
            }
        }

        public override void InstallEntities(IStatelessSession session) {
            var emailAccount = session.Query<EmailAccount>().FirstOrDefault();

            if (emailAccount == null)
                throw new InvalidOperationException("No EmailAccount found.");

            session.Insert(new MessageTemplate {
                SystemName = "Blog.BlogComment",
                Subject = "%Store.Name%. New blog comment.",
                Body = "<p><a href=\"%Store.URL%\">%Store.Name%</a> <br /><br />A new blog comment has been created for blog post \"%BlogComment.PostTitle%\".</p>",
                EmailAccount = emailAccount
            });
        }
    }
}
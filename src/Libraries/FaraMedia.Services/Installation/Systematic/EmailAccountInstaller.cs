namespace FaraMedia.Services.Installation.Systematic {
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public class EmailAccountInstaller : EntityInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(EmailAccountConstants.Messages.AtLeastOneEmailAccountRequired, "حداقل در سیستم باید یک حساب ایمیل باقی بماند.");

                NewResource(EmailAccountConstants.Fields.SystemName.Label, "نام");
                NewResource(EmailAccountConstants.Fields.DisplayName.Label, "نام");
                NewResource(EmailAccountConstants.Fields.Description.Label, "نام");

                NewResource(EmailAccountConstants.Fields.Email.Label, "آدرس ایمیل");
                NewResource(EmailAccountConstants.Fields.UserName.Label, "نام کاربری");
                NewResource(EmailAccountConstants.Fields.Password.Label, "کلمه عبور");
                NewResource(EmailAccountConstants.Fields.Host.Label, "آدرس میزبان");
                NewResource(EmailAccountConstants.Fields.Port.Label, "پورت");

                NewResource(EmailAccountConstants.Fields.SslEnabled.Label, "اس اس ال فعال");
                NewResource(EmailAccountConstants.Fields.UseDefaultCredentials.Label, "اعتبار نامه پیش فرض");

                NewResource(EmailAccountConstants.Fields.Templates.Label, "اس اس ال فعال");
                NewResource(EmailAccountConstants.Fields.Emails.Label, "اعتبار نامه پیش فرض");

                transaction.Commit();
            }
        }

        public override void InstallEntities(IStatelessSession session) {
            using (var transaction = session.BeginTransaction()) {
                session.Insert(new EmailAccount {
                    SystemName = "CONTACT",
                    DisplayName = "General contact",
                    Email = "info@faramedia.com",
                    Host = "smtp.faramedia.com",
                    Port = 25,
                    UserName = "123",
                    Password = "123",
                    SslEnabled = false,
                    UseDefaultCredentials = false
                });

                session.Insert(new EmailAccount {
                    SystemName = "SUPPORT",
                    DisplayName = "User support",
                    Email = "support@faramedia.com",
                    Host = "smtp.faramedia.com",
                    Port = 25,
                    UserName = "123",
                    Password = "123",
                    SslEnabled = false,
                    UseDefaultCredentials = false
                });

                session.Insert(new EmailAccount {
                    SystemName = "SALES",
                    DisplayName = "Sales representative",
                    Email = "sales@faramedia.com",
                    Host = "smtp.faramedia.com",
                    Port = 25,
                    UserName = "123",
                    Password = "123",
                    SslEnabled = false,
                    UseDefaultCredentials = false
                });

                transaction.Commit();
            }
        }
    }
}
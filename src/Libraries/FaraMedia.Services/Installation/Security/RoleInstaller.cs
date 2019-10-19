namespace FaraMedia.Services.Installation.Security {
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Knowns.Security;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public class RoleInstaller : EntityInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(RoleConstants.Messages.SystemRole, "امکان حذف نقش \"سیستمی\" وجود ندارد.");
                NewResource(RoleConstants.Messages.GuestsRoleNotFound, "نقش \"مهمان\" یافت نشد.");
                NewResource(RoleConstants.Messages.RegistetedRoleNotFound, "نقش \"ثبت شده\" یافت نشد.");

                NewResource(RoleConstants.Fields.SystemName.Label, "نام سیستمی");
                NewResource(RoleConstants.Fields.DisplayName.Label, "نام");
                NewResource(RoleConstants.Fields.Description.Label, "نام");

                NewResource(RoleConstants.Fields.IsActive.Label, "نام");

                NewResource(RoleConstants.Fields.Records.Label, "نقش سیستمی");
                NewResource(RoleConstants.Fields.Users.Label, "نقش سیستمی");

                transaction.Commit();
            }
        }

        public override void InstallEntities(IStatelessSession session) {
            using (var transaction = session.BeginTransaction()) {
                session.Insert(new Role {
                    IsSecured = true,
                    SystemName = RoleNames.Administrators,
                    DisplayName = "مدیران ارشد"
                });

                session.Insert(new Role {
                    IsSecured = true,
                    SystemName = RoleNames.Moderators,
                    DisplayName = "مدیران"
                });

                session.Insert(new Role {
                    IsSecured = true,
                    SystemName = RoleNames.ContentProviders,
                    DisplayName = "فراهم آورندگان محتوی"
                });

                session.Insert(new Role {
                    IsSecured = true,
                    SystemName = RoleNames.Companies,
                    DisplayName = "شرکت ها"
                });

                session.Insert(new Role {
                    IsSecured = true,
                    SystemName = RoleNames.Registered,
                    DisplayName = "کاربران (ثبت نام کرده)"
                });

                session.Insert(new Role {
                    IsSecured = true,
                    SystemName = RoleNames.Guests,
                    DisplayName = "کاربران (مهمان)"
                });

                transaction.Commit();
            }
        }
    }
}
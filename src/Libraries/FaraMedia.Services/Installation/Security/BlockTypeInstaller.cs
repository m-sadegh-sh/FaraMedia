namespace FaraMedia.Services.Installation.Security {
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Knowns.Security;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public class BlockTypeInstaller : EntityInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(BlockTypeConstants.Fields.SystemName.Label, "نام سیستمی");
                NewResource(BlockTypeConstants.Fields.DisplayName.Label, "نام");
                NewResource(BlockTypeConstants.Fields.Description.Label, "نام");

                NewResource(BlockTypeConstants.Fields.Users.Label, "نقش سیستمی");

                transaction.Commit();
            }
        }

        public override void InstallEntities(IStatelessSession session) {
            using (var transaction = session.BeginTransaction()) {
                session.Insert(new BlockType {
                    SystemName = BlockTypeNames.NoActivatedYet,
                    DisplayName = "عدم تائید",
                    Description = "عدم تائید"
                });

                session.Insert(new BlockType {
                    SystemName = BlockTypeNames.AdminBlocked,
                    DisplayName = "بلاک شده توسط مدیر سایت",
                    Description = "بلاک شده توسط مدیر سایت"
                });

                transaction.Commit();
            }
        }
    }
}
namespace FaraMedia.Services.Installation.Misc {
    using FaraMedia.Data.Schemas.Misc;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class RedirectorInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(RedirectorConstants.Fields.TargetUrl.Label, "آدرس هدف");
                NewResource(RedirectorConstants.Fields.ShortHash.Label, "اسلاگ");
                NewResource(RedirectorConstants.Fields.UrlName.Label, "اسلاگ");
                NewResource(RedirectorConstants.Fields.Description.Label, "توضیحات");

                NewResource(RedirectorConstants.Fields.UsageTimes.Label, "دفعات استفاده");

                NewResource(RedirectorConstants.Fields.Downloads.Label, "دفعات استفاده");
                NewResource(RedirectorConstants.Fields.Artists.Label, "دفعات استفاده");
                NewResource(RedirectorConstants.Fields.Publishers.Label, "دفعات استفاده");

                transaction.Commit();
            }
        }
    }
}
namespace FaraMedia.Services.Installation.Fundamentals {
    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class PublisherInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(PublisherConstants.Fields.Name.Label, "نام");
                NewResource(PublisherConstants.Fields.Ceo.Label, "مدیر عامل");
                NewResource(PublisherConstants.Fields.RegisterationNumber.Label, "شماره ثبت");
                NewResource(PublisherConstants.Fields.Email.Label, "ایمیل");
                NewResource(PublisherConstants.Fields.BriefHistory.Label, "تاریخچه");

                NewResource(PublisherConstants.Fields.Website.Label, "وب سایت");
                NewResource(PublisherConstants.Fields.Logo.Label, "لوگو");

                NewResource(PublisherConstants.Fields.Tracks.Label, "لوگو");

                transaction.Commit();
            }
        }
    }
}
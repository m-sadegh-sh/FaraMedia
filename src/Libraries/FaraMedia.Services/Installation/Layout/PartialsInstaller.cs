namespace FaraMedia.Services.Installation.Layout {
    using FaraMedia.Data.Schemas.Layout;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class PartialsInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(PartialsConstants.Auth.Labels.Anonymous, "مهمان");
                NewResource(PartialsConstants.Auth.Messages.Anonymous, "کاربر مهمان خوش آمدید!");
                NewResource(PartialsConstants.Auth.Messages.SignedInAs, "{0} عزیز، خوش آمدید!");

                NewResource(PartialsConstants.Version.Messages.AppVersion, "فرامدیا نسخه: {0}");

                NewResource(PartialsConstants.Footer.Messages.Copyright, " {0} © فرامدیا - تمامی حقوق برای فرامدیا محفوظ است.");

                transaction.Commit();
            }
        }
    }
}
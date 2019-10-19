namespace FaraMedia.Services.Installation.Systematic {
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public class NewsletterSubscriptionInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(NewsletterSubscriptionConstants.Fields.Email.Label, "ارسال به");

                NewResource(NewsletterSubscriptionConstants.Fields.Guid.Label, "ارسال به");

                transaction.Commit();
            }
        }
    }
}
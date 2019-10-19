namespace FaraMedia.Services.Installation.Systematic {
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class ActivityInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(ActivityConstants.Fields.Activator.Label, "توسط");
                NewResource(ActivityConstants.Fields.Type.Label, "نوع فعالیت");

                NewResource(ActivityConstants.Fields.Comment.Label, "توضیحات");

                NewResource(ActivityConstants.Fields.ActivationDateUtc.Label, "نوع فعالیت");

                transaction.Commit();
            }
        }
    }
}
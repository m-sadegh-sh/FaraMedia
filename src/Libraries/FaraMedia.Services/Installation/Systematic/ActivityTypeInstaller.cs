namespace FaraMedia.Services.Installation.Systematic {
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class ActivityTypeInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(ActivityTypeConstants.Fields.SystemName.Label, "کلمه کلیدی سیستمی");
                NewResource(ActivityTypeConstants.Fields.DisplayName.Label, "نام");
                NewResource(ActivityTypeConstants.Fields.Description.Label, "نام");

                NewResource(ActivityTypeConstants.Fields.Activities.Label, "نام");

                transaction.Commit();
            }
        }
    }
}
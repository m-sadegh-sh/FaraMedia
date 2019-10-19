namespace FaraMedia.Services.Installation.ContentManagement {
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public class PollChoiceItemInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(PollChoiceItemConstants.Fields.Text.Label, "متن");

                NewResource(PollChoiceItemConstants.Fields.Choice.Label, "متن");

                NewResource(PollChoiceItemConstants.Fields.VotingRecords.Label, "متن");

                transaction.Commit();
            }
        }
    }
}
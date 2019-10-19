namespace FaraMedia.Services.Installation.ContentManagement {
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public class PollChoiceInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(PollChoiceConstants.Fields.Title.Label, "متن");
                NewResource(PollChoiceConstants.Fields.Description.Label, "متن");

                NewResource(PollChoiceConstants.Fields.IsMultiSelection.Label, "متن");

                NewResource(PollChoiceConstants.Fields.Poll.Label, "متن");

                NewResource(PollChoiceConstants.Fields.Items.Label, "متن");

                transaction.Commit();
            }
        }
    }
}
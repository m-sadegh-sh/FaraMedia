namespace FaraMedia.Services.Installation.ContentManagement {
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public class PollVotingRecordInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(PollVotingRecordConstants.Messages.AlreadyVoted, "شما قبلا در این نظرسنجی شرکت کرده اید!");

                NewResource(PollVotingRecordConstants.Fields.Voter.Label, "گزینه");
                NewResource(PollVotingRecordConstants.Fields.VoterIp.Label, "گزینه");

                NewResource(PollVotingRecordConstants.Fields.VoteDateUtc.Label, "گزینه");

                NewResource(PollVotingRecordConstants.Fields.SelectedItem.Label, "گزینه");

                transaction.Commit();
            }
        }
    }
}
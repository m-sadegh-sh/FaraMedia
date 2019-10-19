namespace FaraMedia.Services.Installation.Security {
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public class FriendRequestInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(FriendRequestConstants.Fields.From.Label, "از طرف");
                NewResource(FriendRequestConstants.Fields.To.Label, "به");

                NewResource(FriendRequestConstants.Fields.SentDateUtc.Label, "تائید شده");

                NewResource(FriendRequestConstants.Fields.Accepted.Label, "تائید شده");
                NewResource(FriendRequestConstants.Fields.AcceptanceDateUtc.Label, "تائید شده");

                NewResource(FriendRequestConstants.Fields.BlockSubsequentRequests.Label, "تائید شده");

                transaction.Commit();
            }
        }
    }
}
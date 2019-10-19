namespace FaraMedia.Services.Installation.Shared {
    using FaraMedia.Data.Schemas.Shared;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class CommentInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            using (var transaction = session.BeginTransaction()) {
                NewResource(CommentConstants.Fields.OwnerId.Label, "کلید");

                NewResource(CommentConstants.Fields.Email.Label, "کلید");
                NewResource(CommentConstants.Fields.Title.Label, "مقدار");
                NewResource(CommentConstants.Fields.Body.Label, "کلید");

                NewResource(CommentConstants.Fields.InReplyTo.Label, "مقدار");

                NewResource(CommentConstants.Fields.Replies.Label, "مقدار");

                transaction.Commit();
            }
        }
    }
}
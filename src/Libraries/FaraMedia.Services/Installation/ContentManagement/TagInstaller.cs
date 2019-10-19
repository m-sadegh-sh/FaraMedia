namespace FaraMedia.Services.Installation.ContentManagement {
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class TagInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(TagConstants.Fields.Title.Label, "متن");
                NewResource(TagConstants.Fields.Description.Label, "متن");

                NewResource(TagConstants.Fields.Blog.Label, "متن");

                NewResource(TagConstants.Fields.Posts.Label, "متن");

                transaction.Commit();
            }
        }
    }
}
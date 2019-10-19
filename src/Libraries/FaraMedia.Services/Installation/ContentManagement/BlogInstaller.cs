namespace FaraMedia.Services.Installation.ContentManagement {
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class BlogInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(BlogConstants.Fields.Title.Label, "نام");
                NewResource(BlogConstants.Fields.Description.Label, "نویسنده");

                NewResource(BlogConstants.Fields.Author.Label, "نام");

                NewResource(BlogConstants.Fields.Tags.Label, "نویسنده");
                NewResource(BlogConstants.Fields.Posts.Label, "نویسنده");

                transaction.Commit();
            }
        }
    }
}
namespace FaraMedia.Services.Installation.ContentManagement {
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class PostInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(PostConstants.Fields.Title.Label, "عنوان");
                NewResource(PostConstants.Fields.Body.Label, "متن کامل");

                NewResource(PostConstants.Fields.Blog.Label, "متن کامل");

                NewResource(PostConstants.Fields.Tags.Label, "تگ ها");

                transaction.Commit();
            }
        }
    }
}
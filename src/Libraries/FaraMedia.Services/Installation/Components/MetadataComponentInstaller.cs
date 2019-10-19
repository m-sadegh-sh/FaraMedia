namespace FaraMedia.Services.Installation.Components {
    using FaraMedia.Data.Schemas.Components;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class MetadataComponentInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(MetadataComponentConstants.Fields.Title.Label, "عنوان");
                NewResource(MetadataComponentConstants.Fields.Slug.Label, "اسلاگ");
                NewResource(MetadataComponentConstants.Fields.Keywords.Label, "کلمات کلیدی");
                NewResource(MetadataComponentConstants.Fields.Description.Label, "توضیحات");

                transaction.Commit();
            }
        }
    }
}
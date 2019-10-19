namespace FaraMedia.Services.Installation.Layout {
    using FaraMedia.Data.Schemas.Layout;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class ComponentModelsInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(ComponentModelConstants.MetadataComponentModel.Metadata.Title, "متادیتا");
                NewResource(ComponentModelConstants.MetadataComponentModel.Metadata.Description, "در صورت لزوم با مقداردهی فیلد های ذیل، امکان شناسایی سریعتر مطلب مورد نظر توسط موتور های جستجو را فراهم سازید. توجه کنید که هرگونه تفریط در بکارگیری کلمات غیر متعارف/غیر مرتبط ممکن است نتیجه برعکس را در پی داشته باشد!");

                transaction.Commit();
            }
        }
    }
}
namespace FaraMedia.Services.Installation.ContentManagement {
    using FaraMedia.Core.Domain.Components;
    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class CategoryInstaller : EntityInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(CategoryConstants.Fields.Title.Label, "عنوان");
                NewResource(CategoryConstants.Fields.Description.Label, "والد");

                NewResource(CategoryConstants.Fields.Parent.Label, "عنوان");

                NewResource(CategoryConstants.Fields.Children.Label, "والد");
                NewResource(CategoryConstants.Fields.News.Label, "عنوان");

                transaction.Commit();
            }
        }

        public override void InstallEntities(IStatelessSession session) {
            using (var transaction = session.BeginTransaction()) {
                session.Insert(new Category {
                    Title = "به زودی...",
                    Metadata = new MetadataComponent {
                        Slug = "coming-soon"
                    }
                });

                transaction.Commit();
            }
        }
    }
}
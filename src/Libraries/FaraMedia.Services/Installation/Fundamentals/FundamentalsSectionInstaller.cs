namespace FaraMedia.Services.Installation.Fundamentals {
    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class FundamentalsSectionInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(FundamentalsSectionConstants.Metadata.Title, "بخش آلبوم ها");
                NewResource(FundamentalsSectionConstants.Metadata.Description, ResourceTemplates.SectionDescription("آلبوم ها"));

                NewResource(FundamentalsSectionConstants.GenresController.List.Metadata.Title, "سبک ها");
                NewResource(FundamentalsSectionConstants.GenresController.List.Metadata.Description, ResourceTemplates.ListDescription("سبک ها", "سبک"));
                NewResource(FundamentalsSectionConstants.GenresController.New.Metadata.Title, ResourceTemplates.NewTitle("سبک"));
                NewResource(FundamentalsSectionConstants.GenresController.New.Metadata.Description, ResourceTemplates.NewDescription("سبک"));
                NewResource(FundamentalsSectionConstants.GenresController.Edit.Metadata.Title, ResourceTemplates.EditTitle("سبک"));
                NewResource(FundamentalsSectionConstants.GenresController.Edit.Metadata.Description, ResourceTemplates.EditDescription("سبک"));

                NewResource(FundamentalsSectionConstants.PublishersController.List.Metadata.Title, "ناشران");
                NewResource(FundamentalsSectionConstants.PublishersController.List.Metadata.Description, ResourceTemplates.ListDescription("ناشران", "ناشر"));
                NewResource(FundamentalsSectionConstants.PublishersController.New.Metadata.Title, ResourceTemplates.NewTitle("ناشر"));
                NewResource(FundamentalsSectionConstants.PublishersController.New.Metadata.Description, ResourceTemplates.NewDescription("ناشر"));
                NewResource(FundamentalsSectionConstants.PublishersController.Edit.Metadata.Title, ResourceTemplates.EditTitle("ناشر"));
                NewResource(FundamentalsSectionConstants.PublishersController.Edit.Metadata.Description, ResourceTemplates.EditDescription("ناشر"));

                NewResource(FundamentalsSectionConstants.ArtistsController.List.Metadata.Title, "هنرمندان");
                NewResource(FundamentalsSectionConstants.ArtistsController.List.Metadata.Description, ResourceTemplates.ListDescription("هنرمندان", "هنرمند"));
                NewResource(FundamentalsSectionConstants.ArtistsController.New.Metadata.Title, ResourceTemplates.NewTitle("هنرمند"));
                NewResource(FundamentalsSectionConstants.ArtistsController.New.Metadata.Description, ResourceTemplates.NewDescription("هنرمند"));
                NewResource(FundamentalsSectionConstants.ArtistsController.Edit.Metadata.Title, ResourceTemplates.EditTitle("هنرمند"));
                NewResource(FundamentalsSectionConstants.ArtistsController.Edit.Metadata.Description, ResourceTemplates.EditDescription("هنرمند"));

                NewResource(FundamentalsSectionConstants.PhotoAlbumsController.List.Metadata.Title, "گالری تصاویر: {0}");
                NewResource(FundamentalsSectionConstants.PhotoAlbumsController.List.Metadata.Description, ResourceTemplates.ListDescription("گالری تصاویر", "گالری تصویر"));
                NewResource(FundamentalsSectionConstants.PhotoAlbumsController.New.Metadata.Title, ResourceTemplates.NewTitle("گالری تصویر"));
                NewResource(FundamentalsSectionConstants.PhotoAlbumsController.New.Metadata.Description, ResourceTemplates.NewDescription("گالری تصویر"));
                NewResource(FundamentalsSectionConstants.PhotoAlbumsController.Edit.Metadata.Title, ResourceTemplates.EditTitle("گالری تصویر"));
                NewResource(FundamentalsSectionConstants.PhotoAlbumsController.Edit.Metadata.Description, ResourceTemplates.EditDescription("گالری تصویر"));

                NewResource(FundamentalsSectionConstants.PhotosController.List.Metadata.Title, "تصاویر: {0}");
                NewResource(FundamentalsSectionConstants.PhotosController.List.Metadata.Description, ResourceTemplates.ListDescription("تصاویر", "تصویر"));
                NewResource(FundamentalsSectionConstants.PhotosController.New.Metadata.Title, ResourceTemplates.NewTitle("تصویر"));
                NewResource(FundamentalsSectionConstants.PhotosController.New.Metadata.Description, ResourceTemplates.NewDescription("تصویر"));
                NewResource(FundamentalsSectionConstants.PhotosController.Edit.Metadata.Title, ResourceTemplates.EditTitle("تصویر"));
                NewResource(FundamentalsSectionConstants.PhotosController.Edit.Metadata.Description, ResourceTemplates.EditDescription("تصویر"));

                NewResource(FundamentalsSectionConstants.AlbumsController.List.Metadata.Title, "آلبوم ها");
                NewResource(FundamentalsSectionConstants.AlbumsController.List.Metadata.Description, ResourceTemplates.ListDescription("آلبوم ها", "آلبوم"));
                NewResource(FundamentalsSectionConstants.AlbumsController.New.Metadata.Title, ResourceTemplates.NewTitle("آلبوم"));
                NewResource(FundamentalsSectionConstants.AlbumsController.New.Metadata.Description, ResourceTemplates.NewDescription("آلبوم"));
                NewResource(FundamentalsSectionConstants.AlbumsController.Edit.Metadata.Title, ResourceTemplates.EditTitle("آلبوم"));
                NewResource(FundamentalsSectionConstants.AlbumsController.Edit.Metadata.Description, ResourceTemplates.EditDescription("آلبوم"));

                NewResource(FundamentalsSectionConstants.TracksController.List.Metadata.Title, "قطعات");
                NewResource(FundamentalsSectionConstants.TracksController.List.Metadata.Description, ResourceTemplates.ListDescription("قطعات", "قطعه"));
                NewResource(FundamentalsSectionConstants.TracksController.New.Metadata.Title, ResourceTemplates.NewTitle("قطعه"));
                NewResource(FundamentalsSectionConstants.TracksController.New.Metadata.Description, ResourceTemplates.NewDescription("قطعه"));
                NewResource(FundamentalsSectionConstants.TracksController.Edit.Metadata.Title, ResourceTemplates.EditTitle("قطعه"));
                NewResource(FundamentalsSectionConstants.TracksController.Edit.Metadata.Description, ResourceTemplates.EditDescription("قطعه"));

                transaction.Commit();
            }
        }
    }
}
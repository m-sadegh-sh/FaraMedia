namespace FaraMedia.Services.Installation.ContentManagement {
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class ContentManagementSectionInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(ContentManagementSectionConstants.Metadata.Title, "بخش بلاگ");
                NewResource(ContentManagementSectionConstants.Metadata.Description, ResourceTemplates.SectionDescription("برچسب ها و پست ها"));

                NewResource(ContentManagementSectionConstants.BlogsController.List.Metadata.Title, "بلاگ ها");
                NewResource(ContentManagementSectionConstants.BlogsController.List.Metadata.Description, ResourceTemplates.ListDescription("بلاگ ها", "بلاگ"));
                NewResource(ContentManagementSectionConstants.BlogsController.New.Metadata.Title, ResourceTemplates.NewTitle("بلاگ"));
                NewResource(ContentManagementSectionConstants.BlogsController.New.Metadata.Description, ResourceTemplates.NewDescription("بلاگ"));
                NewResource(ContentManagementSectionConstants.BlogsController.Edit.Metadata.Title, ResourceTemplates.EditTitle("بلاگ"));
                NewResource(ContentManagementSectionConstants.BlogsController.Edit.Metadata.Description, ResourceTemplates.EditDescription("بلاگ"));

                NewResource(ContentManagementSectionConstants.TagsController.List.Metadata.Title, "برچسب ها");
                NewResource(ContentManagementSectionConstants.TagsController.List.Metadata.Description, ResourceTemplates.ListDescription("برچسب ها", "برچسب"));
                NewResource(ContentManagementSectionConstants.TagsController.New.Metadata.Title, ResourceTemplates.NewTitle("برچسب"));
                NewResource(ContentManagementSectionConstants.TagsController.New.Metadata.Description, ResourceTemplates.NewDescription("برچسب"));
                NewResource(ContentManagementSectionConstants.TagsController.Edit.Metadata.Title, ResourceTemplates.EditTitle("برچسب"));
                NewResource(ContentManagementSectionConstants.TagsController.Edit.Metadata.Description, ResourceTemplates.EditDescription("برچسب"));

                NewResource(ContentManagementSectionConstants.PostsController.List.Metadata.Title, "پست ها");
                NewResource(ContentManagementSectionConstants.PostsController.List.Metadata.Description, ResourceTemplates.ListDescription("پست ها", "پست"));
                NewResource(ContentManagementSectionConstants.PostsController.New.Metadata.Title, ResourceTemplates.NewTitle("پست"));
                NewResource(ContentManagementSectionConstants.PostsController.New.Metadata.Description, ResourceTemplates.NewDescription("پست"));
                NewResource(ContentManagementSectionConstants.PostsController.Edit.Metadata.Title, ResourceTemplates.EditTitle("پست"));
                NewResource(ContentManagementSectionConstants.PostsController.Edit.Metadata.Description, ResourceTemplates.EditDescription("پست"));

                NewResource(ContentManagementSectionConstants.CategoriesController.List.Metadata.Title, "گروه ها");
                NewResource(ContentManagementSectionConstants.CategoriesController.List.Metadata.Description, ResourceTemplates.ListDescription("گروه ها", "گروه"));
                NewResource(ContentManagementSectionConstants.CategoriesController.New.Metadata.Title, ResourceTemplates.NewTitle("گروه"));
                NewResource(ContentManagementSectionConstants.CategoriesController.New.Metadata.Description, ResourceTemplates.NewDescription("گروه"));
                NewResource(ContentManagementSectionConstants.CategoriesController.Edit.Metadata.Title, ResourceTemplates.EditTitle("گروه"));
                NewResource(ContentManagementSectionConstants.CategoriesController.Edit.Metadata.Description, ResourceTemplates.EditDescription("گروه"));

                NewResource(ContentManagementSectionConstants.NewsController.List.Metadata.Title, "اخبار");
                NewResource(ContentManagementSectionConstants.NewsController.List.Metadata.Description, ResourceTemplates.ListDescription("اخبار", "خبر"));
                NewResource(ContentManagementSectionConstants.NewsController.New.Metadata.Title, ResourceTemplates.NewTitle("خبر"));
                NewResource(ContentManagementSectionConstants.NewsController.New.Metadata.Description, ResourceTemplates.NewDescription("خبر"));
                NewResource(ContentManagementSectionConstants.NewsController.Edit.Metadata.Title, ResourceTemplates.EditTitle("خبر"));
                NewResource(ContentManagementSectionConstants.NewsController.Edit.Metadata.Description, ResourceTemplates.EditDescription("خبر"));

                NewResource(ContentManagementSectionConstants.GroupsController.List.Metadata.Title, "گروه ها");
                NewResource(ContentManagementSectionConstants.GroupsController.List.Metadata.Description, ResourceTemplates.ListDescription("گروه ها", "گروه"));
                NewResource(ContentManagementSectionConstants.GroupsController.New.Metadata.Title, ResourceTemplates.NewTitle("گروه"));
                NewResource(ContentManagementSectionConstants.GroupsController.New.Metadata.Description, ResourceTemplates.NewDescription("گروه"));
                NewResource(ContentManagementSectionConstants.GroupsController.Edit.Metadata.Title, ResourceTemplates.EditTitle("گروه"));
                NewResource(ContentManagementSectionConstants.GroupsController.Edit.Metadata.Description, ResourceTemplates.EditDescription("گروه"));

                NewResource(ContentManagementSectionConstants.PagesController.List.Metadata.Title, "صفحات");
                NewResource(ContentManagementSectionConstants.PagesController.List.Metadata.Description, ResourceTemplates.ListDescription("صفحات", "صفحه"));
                NewResource(ContentManagementSectionConstants.PagesController.New.Metadata.Title, ResourceTemplates.NewTitle("صفحه"));
                NewResource(ContentManagementSectionConstants.PagesController.New.Metadata.Description, ResourceTemplates.NewDescription("صفحه"));
                NewResource(ContentManagementSectionConstants.PagesController.Edit.Metadata.Title, ResourceTemplates.EditTitle("صفحه"));
                NewResource(ContentManagementSectionConstants.PagesController.Edit.Metadata.Description, ResourceTemplates.EditDescription("صفحه"));

                NewResource(ContentManagementSectionConstants.PollsController.List.Metadata.Title, "نظرسنجی ها");
                NewResource(ContentManagementSectionConstants.PollsController.List.Metadata.Description, ResourceTemplates.ListDescription("نظرسنجی ها", "نظرسنجی"));
                NewResource(ContentManagementSectionConstants.PollsController.New.Metadata.Title, ResourceTemplates.NewTitle("نظرسنجی"));
                NewResource(ContentManagementSectionConstants.PollsController.New.Metadata.Description, ResourceTemplates.NewDescription("نظرسنجی"));
                NewResource(ContentManagementSectionConstants.PollsController.Edit.Metadata.Title, ResourceTemplates.EditTitle("نظرسنجی"));
                NewResource(ContentManagementSectionConstants.PollsController.Edit.Metadata.Description, ResourceTemplates.EditDescription("نظرسنجی"));

                NewResource(ContentManagementSectionConstants.PollChoicesController.List.Metadata.Title, "نظرسنجی ها");
                NewResource(ContentManagementSectionConstants.PollChoicesController.List.Metadata.Description, ResourceTemplates.ListDescription("نظرسنجی ها", "نظرسنجی"));
                NewResource(ContentManagementSectionConstants.PollChoicesController.New.Metadata.Title, ResourceTemplates.NewTitle("نظرسنجی"));
                NewResource(ContentManagementSectionConstants.PollChoicesController.New.Metadata.Description, ResourceTemplates.NewDescription("نظرسنجی"));
                NewResource(ContentManagementSectionConstants.PollChoicesController.Edit.Metadata.Title, ResourceTemplates.EditTitle("نظرسنجی"));
                NewResource(ContentManagementSectionConstants.PollChoicesController.Edit.Metadata.Description, ResourceTemplates.EditDescription("نظرسنجی"));

                NewResource(ContentManagementSectionConstants.PollChoiceItemsController.List.Metadata.Title, "نظرسنجی ها");
                NewResource(ContentManagementSectionConstants.PollChoiceItemsController.List.Metadata.Description, ResourceTemplates.ListDescription("نظرسنجی ها", "نظرسنجی"));
                NewResource(ContentManagementSectionConstants.PollChoiceItemsController.New.Metadata.Title, ResourceTemplates.NewTitle("نظرسنجی"));
                NewResource(ContentManagementSectionConstants.PollChoiceItemsController.New.Metadata.Description, ResourceTemplates.NewDescription("نظرسنجی"));
                NewResource(ContentManagementSectionConstants.PollChoiceItemsController.Edit.Metadata.Title, ResourceTemplates.EditTitle("نظرسنجی"));
                NewResource(ContentManagementSectionConstants.PollChoiceItemsController.Edit.Metadata.Description, ResourceTemplates.EditDescription("نظرسنجی"));

                NewResource(ContentManagementSectionConstants.PollVotingRecordsController.List.Metadata.Title, "نظرسنجی ها");
                NewResource(ContentManagementSectionConstants.PollVotingRecordsController.List.Metadata.Description, ResourceTemplates.ListDescription("نظرسنجی ها", "نظرسنجی"));

                transaction.Commit();
            }
        }
    }
}
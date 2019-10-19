namespace FaraMedia.FrontEnd.Administration.Controllers {
    using System;
    using System.Linq;

    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.FrontEnd.Administration.Controllers.Abstracts;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.FrontEnd.Administration.Models.ContentManagement;
    using FaraMedia.FrontEnd.Administration.Models.ContentManagement.Editable;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.ContentManagement;
    using FaraMedia.Services.Security;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.UI;

    [SectionName(NewsSectionConstants.SectionName)]
    public class NewsController : AbstractFullCrudControllerBase<News, NewsModel, EditableNewsModel> {
        private readonly ICategoryService _categoryService;
        private readonly INewsService _newsService;

        public NewsController(ICategoryService categoryService, INewsService newsService) {
            _categoryService = categoryService;
            _newsService = newsService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageNews; }
        }

        protected override Func<EditableNewsModel> GetInitialEditableModelInstance {
            get {
                return () => new EditableNewsModel {
                    IsPublished = true
                };
            }
        }

        protected override void InjectModelDependencies(EditableNewsModel editableNewsModel) {
            if (editableNewsModel.Metadata == null)
                editableNewsModel.Metadata = new EditableMetadataComponentModel();

            editableNewsModel.AvailableCategories = _categoryService.GetAllCategories().ToSelectList(c => c.Id, c => c.Title, editableNewsModel.CategoryId);
        }

        protected override Func<News> GetEntityById(long id) {
            return () => _newsService.GetNewsById(id);
        }

        protected override Func<News> LoadEntityById(long id) {
            return () => _newsService.LoadNewsById(id);
        }

        protected override Func<IQueryable<News>> GetAllEntities {
            get { return () => _newsService.GetAllNews(null, null); }
        }

        protected override Func<ServiceOperationResult> InsertEntityAndReturnOperationResult(News news) {
            return () => _newsService.InsertNews(news);
        }

        protected override Func<ServiceOperationResult> UpdateEntityAndReturnOperationResult(News news) {
            return () => _newsService.UpdateNews(news);
        }

        protected override Func<ServiceOperationResult> DeleteEntityAndReturnOperationResult(News news, bool onlyChangeFlag = true) {
            return () => _newsService.DeleteNews(news, onlyChangeFlag);
        }
    }
}
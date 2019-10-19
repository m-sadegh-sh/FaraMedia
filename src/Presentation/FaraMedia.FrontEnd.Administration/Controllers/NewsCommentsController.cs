namespace FaraMedia.FrontEnd.Administration.Controllers {
    using System;
    using System.Linq;

    using FaraMedia.Core.Domain.News;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Domain.Settings;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.News;
    using FaraMedia.Services.Security;
    using FaraMedia.Web.Framework.Mvc.UI;

    public class NewsCommentsController : AdminAreaControllerBase<NewsComment, NewsCommentModel, EditableNewsCommentModel> {
        private readonly ICategoryService _categoryService;
        private readonly INewsCommentService _newsCommentService;

        public NewsCommentsController(ICategoryService categoryService, INewsCommentService newsCommentService, AdminAreaSettings adminAreaSettings) : base(adminAreaSettings) {
            _categoryService = categoryService;
            _newsCommentService = newsCommentService;
        }

        protected override Func<PermissionRecord> AuthorizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageNews; }
        }

        protected override Func<EditableNewsCommentModel> GetInitialEditableModelInstance {
            get {
                return () => new EditableNewsCommentModel {
                    IsPublished = true
                };
            }
        }

        protected override void InjectModelDependencies(EditableNewsCommentsModel editableNewsCommentsModel) {
            if (editableNewsCommentsModel.Metadata == null)
                editableNewsCommentsModel.Metadata = new EditableMetadataComponentModel();

            editableNewsCommentsModel.AvailableCategories = _categoryService.GetAllCategories().ToSelectList(c => c.Id, c => c.Title, editableNewsCommentsModel.CategoryId);
        }

        protected override Func<NewsComments> GetEntityById(long id) {
            return () => _newsCommentService.GetNewsCommentsById(id);
        }

        protected override Func<IQueryable<NewsComments>> GetAllEntities {
            get { return () => _newsCommentService.GetAllNewsComments(null, null); }
        }

        protected override Func<ServiceOperationResult> InsertEntityAndReturnOperationResult(NewsComments news) {
            return () => _newsCommentService.InsertNewsComment(news);
        }

        protected override Func<ServiceOperationResult> UpdateEntityAndReturnOperationResult(NewsComments news) {
            return () => _newsCommentService.UpdateNewsComment(news);
        }

        protected override Func<ServiceOperationResult> DeleteEntityAndReturnOperationResult(NewsComments news, bool onlyChangeFlag = true) {
            return () => _newsCommentService.DeleteNewsComment(news, onlyChangeFlag);
        }
    }
}
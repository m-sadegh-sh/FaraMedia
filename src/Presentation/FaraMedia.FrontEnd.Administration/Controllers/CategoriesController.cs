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
    public class CategoriesController : AbstractFullCrudControllerBase<Category, CategoryModel, EditableCategoryModel> {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService) {
            _categoryService = categoryService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageCategories; }
        }

        protected override Func<EditableCategoryModel> GetInitialEditableModelInstance {
            get {
                return () => new EditableCategoryModel {
                    IsPublished = true
                };
            }
        }

        protected override void InjectModelDependencies(EditableCategoryModel editableCategoryModel) {
            if (editableCategoryModel.Metadata == null)
                editableCategoryModel.Metadata = new EditableMetadataComponentModel();

            var parents = _categoryService.GetAllCategories();
            if (editableCategoryModel.Id > 0)
                parents = parents.Where(c => c.Id != editableCategoryModel.Id && (c.Parent == null || c.Parent.Id != editableCategoryModel.Id));

            editableCategoryModel.AllParents = parents.ToSelectList(c => c.Id, c => c.Title, editableCategoryModel.ParentId);
        }

        protected override Func<Category> GetEntityById(long id) {
            return () => _categoryService.GetCategoryById(id);
        }

        protected override Func<Category> LoadEntityById(long id) {
            return () => _categoryService.LoadCategoryById(id);
        }

        protected override Func<IQueryable<Category>> GetAllEntities {
            get { return () => _categoryService.GetAllCategories(); }
        }

        protected override Func<ServiceOperationResult> InsertEntityAndReturnOperationResult(Category category) {
            return () => _categoryService.InsertCategory(category);
        }

        protected override Func<ServiceOperationResult> UpdateEntityAndReturnOperationResult(Category category) {
            return () => _categoryService.UpdateCategory(category);
        }

        protected override Func<ServiceOperationResult> DeleteEntityAndReturnOperationResult(Category category, bool onlyChangeFlag = true) {
            return () => _categoryService.DeleteCategory(category, onlyChangeFlag);
        }
    }
}
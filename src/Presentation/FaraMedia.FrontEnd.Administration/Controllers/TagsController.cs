namespace FaraMedia.FrontEnd.Administration.Controllers {
    using System;
    using System.Linq;

    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.FrontEnd.Administration.Controllers.Abstracts;
    using FaraMedia.FrontEnd.Administration.Models.Blogs;
    using FaraMedia.FrontEnd.Administration.Models.Blogs.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.FrontEnd.Administration.Models.ContentManagement;
    using FaraMedia.FrontEnd.Administration.Models.ContentManagement.Editable;
    using FaraMedia.Services.ContentManagement;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.ContentManagement;
    using FaraMedia.Services.Security;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.UI;

    [SectionName(BloggingSectionConstants.SectionName)]
    public class TagsController : AbstractFullCrudControllerBase<Tag, TagModel, EditableTagModel> {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService) {
            _tagService = tagService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageTags; }
        }

        protected override Func<EditableTagModel> GetInitialEditableModelInstance {
            get {
                return () => new EditableTagModel {
                    IsPublished = true
                };
            }
        }

        protected override void InjectModelDependencies(EditableTagModel editableTagModel) {
            if (editableTagModel.Metadata == null)
                editableTagModel.Metadata = new EditableMetadataComponentModel();
        }

        protected override Func<Tag> GetEntityById(long id) {
            return () => _tagService.GetTagById(id);
        }

        protected override Func<Tag> LoadEntityById(long id) {
            return () => _tagService.LoadTagById(id);
        }

        protected override Func<IQueryable<Tag>> GetAllEntities {
            get { return () => _tagService.GetAllTags(); }
        }

        protected override Func<ServiceOperationResult> InsertEntityAndReturnOperationResult(Tag tag) {
            return () => _tagService.InsertTag(tag);
        }

        protected override Func<ServiceOperationResult> UpdateEntityAndReturnOperationResult(Tag tag) {
            return () => _tagService.UpdateTag(tag);
        }

        protected override Func<ServiceOperationResult> DeleteEntityAndReturnOperationResult(Tag tag, bool onlyChangeFlag = true) {
            return () => _tagService.DeleteTag(tag, onlyChangeFlag);
        }
    }
}
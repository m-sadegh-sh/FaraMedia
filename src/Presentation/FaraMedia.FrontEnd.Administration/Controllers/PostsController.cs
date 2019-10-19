namespace FaraMedia.FrontEnd.Administration.Controllers {
    using System;
    using System.Linq;

    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.FrontEnd.Administration.Controllers.Abstracts;
    using FaraMedia.FrontEnd.Administration.Models.Blogs;
    using FaraMedia.FrontEnd.Administration.Models.Blogs.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.Services.ContentManagement;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.Security;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.UI;

    [SectionName(BloggingSectionConstants.SectionName)]
    public class PostsController : AbstractFullCrudControllerBase<Post, PostModel, EditablePostModel> {
        private readonly ITagService _tagService;
        private readonly IPostService _postService;

        public PostsController(ITagService tagService, IPostService postService) {
            _tagService = tagService;
            _postService = postService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManagePosts; }
        }

        protected override Func<EditablePostModel> GetInitialEditableModelInstance {
            get {
                return () => new EditablePostModel {
                    IsPublished = true
                };
            }
        }

        protected override void InjectModelDependencies(EditablePostModel editablePostModel) {
            if (editablePostModel.Metadata == null)
                editablePostModel.Metadata = new EditableMetadataComponentModel();

            editablePostModel.AvailableTags = _tagService.GetAllTags().ToSelectList(t => t.Id, t => t.Text, editablePostModel.Tags);
        }

        protected override Func<Post> GetEntityById(long id) {
            return () => _postService.GetPostById(id);
        }

        protected override Func<Post> LoadEntityById(long id) {
            return () => _postService.LoadPostById(id);
        }

        protected override Func<IQueryable<Post>> GetAllEntities {
            get { return () => _postService.GetAllPosts(); }
        }

        protected override Func<ServiceOperationResult> InsertEntityAndReturnOperationResult(Post post) {
            return () => _postService.InsertPost(post);
        }

        protected override Func<ServiceOperationResult> UpdateEntityAndReturnOperationResult(Post post) {
            return () => _postService.UpdatePost(post);
        }

        protected override Func<ServiceOperationResult> DeleteEntityAndReturnOperationResult(Post post, bool onlyChangeFlag = true) {
            return () => _postService.DeletePost(post, onlyChangeFlag);
        }
    }
}
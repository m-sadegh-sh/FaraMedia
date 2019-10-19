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
    using FaraMedia.Services.Security;
    using FaraMedia.Services.ContentManagement;
    using FaraMedia.Services.Security;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.UI;

    [SectionName(BloggingSectionConstants.SectionName)]
    public class BlogsController : AbstractFullCrudControllerBase<Blog, BlogModel, EditableBlogModel> {
        private readonly IUserService _userService;
        private readonly IBlogService _blogService;

        public BlogsController(IUserService userService,IBlogService blogService) {
            _userService = userService;
            _blogService = blogService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageBlogs; }
        }

        protected override Func<EditableBlogModel> GetInitialEditableModelInstance {
            get {
                return () => new EditableBlogModel {
                    IsPublished = true
                };
            }
        }

        protected override void InjectModelDependencies(EditableBlogModel editableBlogModel) {
            if (editableBlogModel.Metadata == null)
                editableBlogModel.Metadata = new EditableMetadataComponentModel();

            editableBlogModel.AvailableUsers = _userService.GetAllUsers().ToSelectList(u => u.Id, u => u.UserName, editableBlogModel.UserId);
        }

        protected override Func<Blog> GetEntityById(long id) {
            return () => _blogService.GetBlogById(id);
        }

        protected override Func<Blog> LoadEntityById(long id) {
            return () => _blogService.LoadBlogById(id);
        }

        protected override Func<IQueryable<Blog>> GetAllEntities {
            get { return () => _blogService.GetAllBlogs(); }
        }

        protected override Func<ServiceOperationResult> InsertEntityAndReturnOperationResult(Blog blog) {
            return () => _blogService.InsertBlog(blog);
        }

        protected override Func<ServiceOperationResult> UpdateEntityAndReturnOperationResult(Blog blog) {
            return () => _blogService.UpdateBlog(blog);
        }

        protected override Func<ServiceOperationResult> DeleteEntityAndReturnOperationResult(Blog blog, bool onlyChangeFlag = true) {
            return () => _blogService.DeleteBlog(blog, onlyChangeFlag);
        }
    }
}
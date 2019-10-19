namespace FaraMedia.FrontEnd.Administration.GridModels.ContentManagement {
    using System.Web.Mvc;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Blogs;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class BlogModelGrid : EntityModelGridBase<BlogModel> {
        public BlogModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool isActive = true, bool name = true, bool author = true, bool tags = true, bool posts = true)
            : base(htmlHelper, isSelected, edit, ContentManagementSectionConstants.BlogsController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (isActive)
                Column.For(bm => bm.IsActive).Named(htmlHelper.T(BlogConstants.Fields.IsActive.Label));

            if (name)
                Column.For(bm => bm.Name).Named(htmlHelper.T(BlogConstants.Fields.Name.Label));

            if (author) {
                Column.For(bm => htmlHelper.LocalizedRouteLinkWithId(bm.UserFullName, SecuritySectionConstants.UsersController.Edit.RouteName, bm.UserId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(BlogConstants.Fields.User.Label));
            }

            if (tags) {
                Column.For(bm => htmlHelper.LocalizedRouteLink(bm.TagsCount.ToString(), ContentManagementSectionConstants.TagsController.ListByBlogId.RouteName, RouteParameter.Add(KnownParameterNames.BlogId, bm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(BlogConstants.Fields.Tags.Label));
            }

            if (posts) {
                Column.For(bm => htmlHelper.LocalizedRouteLink(bm.PostsCount.ToString(), ContentManagementSectionConstants.PostsController.ListByBlogId.RouteName, RouteParameter.Add(KnownParameterNames.BlogId, bm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(BlogConstants.Fields.Posts.Label));
            }
        }
    }
}
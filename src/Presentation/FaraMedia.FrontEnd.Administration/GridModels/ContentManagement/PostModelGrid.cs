namespace FaraMedia.FrontEnd.Administration.GridModels.ContentManagement {
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Blogs;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class PostModelGrid : CommentableModelGridBase<PostModel> {
        public PostModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool ipAddress = true, bool creator = true, bool allowComments = true, bool comments = true, bool likes = true, bool shares = true, bool title = true, bool body = true, bool metadata = true, bool blog = true, bool tags = true) : base(htmlHelper, isSelected, edit, ContentManagementSectionConstants.PostsController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn, ipAddress, creator, allowComments, commentsCount, likesCount, shares) {
            if (title)
                Column.For(pm => pm.Title).Named(htmlHelper.T(PostConstants.Fields.Title.Label));

            if (body)
                Column.For(pm => pm.Body).Named(htmlHelper.T(PostConstants.Fields.Body.Label));

            if (metadata)
                Column.For(pm => GenericHtmlHelper.EditorFor(trap => pm.Metadata)).Named(htmlHelper.T(CommonConstants.Fields.Metadata.Label));

            if (blog) {
                Column.For(pm => htmlHelper.LocalizedRouteLinkWithId(pm.BlogName, ContentManagementSectionConstants.BlogsController.Edit.RouteName, pm.BlogId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(PostConstants.Fields.Blog.Label));
            }

            if (tags) {
                Column.For(pm => htmlHelper.SmartRouteLink(pm.TagsCount.ToString(), ContentManagementSectionConstants.TagsController.ListByPostId.RouteName, RouteParameter.Add(KnownParameterNames.PostId, pm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(PostConstants.Fields.Tags.Label));
            }
        }
    }
}
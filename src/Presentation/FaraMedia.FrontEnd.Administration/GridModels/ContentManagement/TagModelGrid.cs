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

    public sealed class TagModelGrid : EntityModelGridBase<TagModel> {
        public TagModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true,bool text=true,bool metadata=true,bool blog=true,bool postsCount=true)
            : base(htmlHelper, isSelected,edit,ContentManagementSectionConstants.TagsController.Edit.RouteName,id,isPublished,isDeleted,displayOrder,createdOn,lastModifiedOn)
        {
            if(text)
            Column.For(tm => tm.Text).Named(htmlHelper.T(TagConstants.Fields.Text.Label));

            if (metadata)
                Column.For(tm => GenericHtmlHelper.EditorFor(trap => tm.Metadata)).Named(htmlHelper.T(CommonConstants.Fields.Metadata.Label));

            if (blog) {
                Column.For(tm => htmlHelper.LocalizedRouteLinkWithId(tm.BlogName, ContentManagementSectionConstants.BlogsController.Edit.RouteName, tm.BlogId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(TagConstants.Fields.Blog.Label));
            }

            if (posts) {
                Column.For(tm => htmlHelper.SmartRouteLink(tm.PostsCount.ToString(), ContentManagementSectionConstants.PostsController.ListByTagId.RouteName, RouteParameter.Add(KnownParameterNames.TagId, tm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(TagConstants.Fields.Posts.Label));
            }
        }
    }
}
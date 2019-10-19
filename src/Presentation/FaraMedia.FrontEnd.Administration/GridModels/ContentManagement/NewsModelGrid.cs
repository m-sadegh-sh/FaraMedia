namespace FaraMedia.FrontEnd.Administration.GridModels.ContentManagement {
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.ContentManagement;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class NewsModelGrid : CommentableModelGridBase<NewsModel> {
        public NewsModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool ipAddress = true, bool creator = true, bool allowComments = true, bool comments = true, bool likes = true, bool shares = true, bool title = true, bool @short = true, bool full = true, bool metadata = true, bool category = true) : base(htmlHelper, isSelected, edit, ContentManagementSectionConstants.ContentManagementController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn, ipAddress, creator, allowComments, commentsCount, likesCount, shares) {
            if (title)
                Column.For(nm => nm.Title).Named(htmlHelper.T(NewsConstants.Fields.Title.Label));

            if (@short)
                Column.For(nm => nm.Short).Named(htmlHelper.T(NewsConstants.Fields.Short.Label));

            if (full)
                Column.For(nm => nm.Full).Named(htmlHelper.T(NewsConstants.Fields.Full.Label));

            if (metadata)
                Column.For(nm => GenericHtmlHelper.EditorFor(trap => nm.Metadata)).Named(htmlHelper.T(CommonConstants.Fields.Metadata.Label));

            if (category) {
                Column.For(nm => htmlHelper.LocalizedRouteLinkWithId(nm.CategoryTitle, ContentManagementSectionConstants.CategoriesController.Edit.RouteName, nm.CategoryId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(NewsConstants.Fields.Category.Label));
            }
        }
    }
}
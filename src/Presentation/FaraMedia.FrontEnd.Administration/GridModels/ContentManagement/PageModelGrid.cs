namespace FaraMedia.FrontEnd.Administration.GridModels.Page {
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.ContentManagement;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class PageModelGrid : EntityModelGridBase<PageModel> {
        public PageModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool title = true, bool body = true, bool metadata = true, bool group = true) : base(htmlHelper, isSelected, edit, ContentManagementSectionConstants.ContentManagementController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (title)
                Column.For(pm => pm.Title).Named(htmlHelper.T(PageConstants.Fields.Title.Label));

            if (body)
                Column.For(pm => pm.Body).Named(htmlHelper.T(PageConstants.Fields.Body.Label));

            if (metadata)
                Column.For(pm => GenericHtmlHelper.EditorFor(trap => pm.Metadata)).Named(htmlHelper.T(CommonConstants.Fields.Metadata.Label));

            if (group) {
                Column.For(pm => htmlHelper.LocalizedRouteLinkWithId(pm.GroupTitle, ContentManagementSectionConstants.CategoriesController.Edit.RouteName, pm.GroupId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(PageConstants.Fields.Group.Label));
            }
        }
    }
}
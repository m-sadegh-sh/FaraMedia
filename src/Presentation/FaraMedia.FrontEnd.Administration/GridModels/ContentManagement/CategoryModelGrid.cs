namespace FaraMedia.FrontEnd.Administration.GridModels.ContentManagement {
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.ContentManagement;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class CategoryModelGrid : EntityModelGridBase<CategoryModel> {
        public CategoryModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool title = true, bool metadata = true, bool parent = true, bool childs = true, bool news = true) : base(htmlHelper, isSelected, edit, ContentManagementSectionConstants.CategoriesController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (title)
                Column.For(cm => cm.Title).Named(htmlHelper.T(CategoryConstants.Fields.Title.Label));

            if (metadata)
                Column.For(nm => GenericHtmlHelper.EditorFor(trap => nm.Metadata)).Named(htmlHelper.T(CommonConstants.Fields.Metadata.Label));

            if (parent)
                Column.For(cm => cm.ParentTitle).Named(htmlHelper.T(CategoryConstants.Fields.Parent.Label));

            if (childs) {
                Column.For(cm => htmlHelper.LocalizedRouteLink(cm.ChildsCount.ToString(), ContentManagementSectionConstants.CategoriesController.ListByParentId.RouteName, RouteParameter.Add(KnownParameterNames.ParentId, cm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(CategoryConstants.Fields.Childs.Label));
            }

            if (news) {
                Column.For(cm => htmlHelper.LocalizedRouteLink(cm.ContentManagementCount.ToString(), ContentManagementSectionConstants.ContentManagementController.ListByCategoryId.RouteName, RouteParameter.Add(KnownParameterNames.CategoryId, cm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(CategoryConstants.Fields.ContentManagement.Label));
            }
        }
    }
}
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

    public sealed class GroupModelGrid : EntityModelGridBase<GroupModel> {
        public GroupModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool title = true, bool metadata = true, bool parent = true, bool childs = true, bool pages = true)
            : base(htmlHelper, isSelected, edit, ContentManagementSectionConstants.GroupsController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (title)
                Column.For(gm => gm.Title).Named(htmlHelper.T(GroupConstants.Fields.Title.Label));

            if (metadata)
                Column.For(gm => GenericHtmlHelper.EditorFor(trap => gm.Metadata)).Named(htmlHelper.T(CommonConstants.Fields.Metadata.Label));

            if (parent) {
                Column.For(gm => htmlHelper.LocalizedRouteLinkWithId(gm.ParentTitle, ContentManagementSectionConstants.GroupsController.Edit.RouteName, gm.ParentId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(GroupConstants.Fields.Parent.Label));
            }

            if (childs) {
                Column.For(cm => htmlHelper.LocalizedRouteLink(cm.ChildsCount.ToString(), ContentManagementSectionConstants.CategoriesController.ListByParentId.RouteName, RouteParameter.Add(KnownParameterNames.ParentId, cm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(GroupConstants.Fields.Childs.Label));
            }

            if (pages) {
                Column.For(cm => htmlHelper.LocalizedRouteLink(cm.ContentManagementCount.ToString(), ContentManagementSectionConstants.ContentManagementController.ListByGroupId.RouteName, RouteParameter.Add(KnownParameterNames.GroupId, cm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(GroupConstants.Fields.ContentManagement.Label));
            }
        }
    }
}
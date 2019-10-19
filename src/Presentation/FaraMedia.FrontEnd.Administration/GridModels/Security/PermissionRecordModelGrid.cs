namespace FaraMedia.FrontEnd.Administration.GridModels.Miscellaneous {
    using System.Web.Mvc;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Security;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class PermissionRecordModelGrid : EntityModelGridBase<PermissionRecordModel> {
        public PermissionRecordModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool systemName = true, bool name = true, bool category = true, bool roles = true)
            : base(htmlHelper, isSelected, edit, SecuritySectionConstants.PermissionRecordsController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (systemName)
                Column.For(prm => prm.SystematicName).Named(htmlHelper.T(PermissionRecordConstants.Fields.SystematicName.Label));

            if (name)
                Column.For(prm => prm.Name).Named(htmlHelper.T(PermissionRecordConstants.Fields.Name.Label));

            if (category)
                Column.For(prm => prm.Category).Named(htmlHelper.T(PermissionRecordConstants.Fields.Category.Label));

            if (roles) {
                Column.For(prm => htmlHelper.LocalizedRouteLink(prm.RolesCount.ToString(), SecuritySectionConstants.RolesController.ListByPermissionRecordId.RouteName, RouteParameter.Add(KnownParameterNames.PermissionRecordId, prm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(PermissionRecordConstants.Fields.Roles.Label));
            }
        }
    }
}
namespace FaraMedia.FrontEnd.Administration.GridModels.Miscellaneous {
    using System.Web.Mvc;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Security;
    using FaraMedia.FrontEnd.Administration.Models.Security;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class RoleModelGrid : EntityModelGridBase<RoleModel> {
        public RoleModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool isSystemRole = true, bool systemName = true, bool name = true, bool permissionRecords = true, bool users = true)
            : base(htmlHelper, isSelected, edit, SecuritySectionConstants.RolesController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (isSystemRole)
                Column.For(rm => rm.IsSystemRole).Named(htmlHelper.T(RoleConstants.Fields.IsSystemRole.Label));
            
            if (systemName)
                Column.For(rm => rm.SystematicName).Named(htmlHelper.T(RoleConstants.Fields.SystematicName.Label));

            if (name)
                Column.For(rm => rm.Name).Named(htmlHelper.T(RoleConstants.Fields.Name.Label));

            if (permissionRecords) {
                Column.For(rm => htmlHelper.LocalizedRouteLink(rm.PermissionRecordsCount.ToString(), SecuritySectionConstants.PermissionRecordsController.ListByRoleId.RouteName, RouteParameter.Add(KnownParameterNames.RoleId, rm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(RoleConstants.Fields.Records.Label));
            }

            if (users) {
                Column.For(rm => htmlHelper.LocalizedRouteLink(rm.PermissionRecordsCount.ToString(), SecuritySectionConstants.UsersController.ListByRoleId.RouteName, RouteParameter.Add(KnownParameterNames.RoleId, rm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(RoleConstants.Fields.Records.Label));
            }
        }
    }
}
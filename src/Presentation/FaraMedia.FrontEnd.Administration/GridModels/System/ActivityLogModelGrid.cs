namespace FaraMedia.FrontEnd.Administration.GridModels.Miscellaneous {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Systematic;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class ActivityModelGrid : EntityModelGridBase<ActivityModel> {
        public ActivityModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool comment = true, bool activityType = true, bool user = true)
            : base(htmlHelper, isSelected, false, null, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (comment)
                Column.For(alm => alm.Comment).Named(htmlHelper.T(ActivityConstants.Fields.Comment.Label));

            if (activityType) {
                Column.For(alm => htmlHelper.LocalizedRouteLinkWithId(alm.ActivityTypeName, SystematicSectionConstants.ActivityTypesController.Edit.RouteName, alm.ActivityTypeId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(ActivityConstants.Fields.Type.Label));
            }

            if (user) {
                Column.For(alm => htmlHelper.LocalizedRouteLinkWithId(alm.UserFullName, SecuritySectionConstants.UsersController.Edit.RouteName, alm.UserId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(ActivityConstants.Fields.Activator.Label));
            }
        }
    }
}
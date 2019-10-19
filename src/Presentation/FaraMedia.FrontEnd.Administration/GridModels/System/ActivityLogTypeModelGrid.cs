namespace FaraMedia.FrontEnd.Administration.GridModels.Miscellaneous {
    using System.Web.Mvc;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Systematic;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class ActivityTypeModelGrid : EntityModelGridBase<ActivityTypeModel> {
        public ActivityTypeModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool systemKeyword = true, bool name = true, bool activities = true)
            : base(htmlHelper, isSelected, false, null, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (systemKeyword)
                Column.For(altm => altm.SystematicKeyword).Named(htmlHelper.T(ActivityTypeConstants.Fields.SystematicKeyword.Label));

            if (name)
                Column.For(altm => altm.Name).Named(htmlHelper.T(ActivityTypeConstants.Fields.Name.Label));

            if (activities) {
                Column.For(altm => htmlHelper.LocalizedRouteLink(altm.ActivitiesCount.ToString(), SystematicSectionConstants.ActivitiesController.ListByActivityTypeId.RouteName, RouteParameter.Add(KnownParameterNames.ActivityTypeId, altm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(ActivityTypeConstants.Fields.Activities.Label));
            }
        }
    }
}
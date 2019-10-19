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

    public sealed class LanguageModelGrid : EntityModelGridBase<LanguageModel> {
        public LanguageModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool isRightToLeft = true, bool name = true, bool isoCode = true, bool stringResources = true)
            : base(htmlHelper, isSelected, false, null, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (isRightToLeft)
                Column.For(lm => lm.IsRightToLeft).Named(htmlHelper.T(LanguageConstants.Fields.IsRightToLeft.Label));

            if (name)
                Column.For(lm => lm.Name).Named(htmlHelper.T(LanguageConstants.Fields.Name.Label));

            if (isoCode)
                Column.For(lm => lm.IsoCode).Named(htmlHelper.T(LanguageConstants.Fields.IsoCode.Label));

            if (stringResources) {
                Column.For(lm => htmlHelper.LocalizedRouteLink(lm.StringResourcesCount.ToString(), SystematicSectionConstants.StringResourcesController.ListByLanguageId.RouteName, RouteParameter.Add(KnownParameterNames.LanguageId, lm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(LanguageConstants.Fields.Resources.Label));
            }
        }
    }
}
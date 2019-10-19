namespace FaraMedia.FrontEnd.Administration.GridModels.Miscellaneous {
    using System.Web.Mvc;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Miscellaneous;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Miscellaneous;
    using FaraMedia.Web.Framework.Mvc.Extensions;

    public sealed class RedirectorModelGrid : EntityModelGridBase<RedirectorModel> {
        public RedirectorModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool usageTimes = true, bool targetUrl = true, bool slug = true, bool description = true)
            : base(htmlHelper, isSelected, edit, MiscellaneousSectionConstants.RedirectorsController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (usageTimes)
                Column.For(rm => rm.UsageTimes).Named(htmlHelper.T(RedirectorConstants.Fields.UsageTimes.Label));

            if (targetUrl) {
                Column.For(rm => rm.TargetUrl).Named(htmlHelper.T(RedirectorConstants.Fields.TargetUrl.Label)).Attributes(grvd => RouteValueDictionaryHelpers.Convert(new {
                    @class = "left"
                }));
            }

            if (slug)
                Column.For(rm => rm.Slug).Named(htmlHelper.T(RedirectorConstants.Fields.Slug.Label));

            if (description)
                Column.For(rm => rm.Description).Named(htmlHelper.T(RedirectorConstants.Fields.Description.Label));
        }
    }
}
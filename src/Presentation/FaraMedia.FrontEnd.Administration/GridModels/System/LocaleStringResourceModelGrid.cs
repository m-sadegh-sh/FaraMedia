namespace FaraMedia.FrontEnd.Administration.GridModels.Miscellaneous {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Systematic;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class StringResourceModelGrid : EntityModelGridBase<StringResourceModel> {
        public StringResourceModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool key = true, bool value = true, bool language = true)
            : base(htmlHelper, isSelected, false, null, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (key)
                Column.For(lsrm => lsrm.Key).Named(htmlHelper.T(StringResourceConstants.Fields.Key.Label));

            if (value)
                Column.For(lsrm => lsrm.Value).Named(htmlHelper.T(StringResourceConstants.Fields.Value.Label));

            if (language) {
                Column.For(lsrm => htmlHelper.LocalizedRouteLinkWithId(lsrm.LanguageName, SystematicSectionConstants.LanguagesController.Edit.RouteName, lsrm.LanguageId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(StringResourceConstants.Fields.Language.Label));
            }
        }
    }
}
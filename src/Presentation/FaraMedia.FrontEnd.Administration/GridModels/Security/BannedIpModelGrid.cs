namespace FaraMedia.FrontEnd.Administration.GridModels.Miscellaneous {
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Security;
    using FaraMedia.Web.Framework.Mvc.Extensions;

    public sealed class BannedIpModelGrid : EntityModelGridBase<BannedIpModel> {
        public BannedIpModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, string editRouteName = null, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool expiresOn = true, bool ipAdrress = true, bool reason = true)
            : base(htmlHelper, isSelected, edit, SecuritySectionConstants.BannedIpsController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (expiresOn)
                Column.For(bim => GenericHtmlHelper.EditorFor(trap => bim.ExpireDate)).Named(htmlHelper.T(BannedIpConstants.Fields.ExpireDateUtc.Label));

            if (ipAdrress)
                Column.For(bim => bim.IpAdrress).Named(htmlHelper.T(BannedIpConstants.Fields.IpAdrress.Label));

            if (reason)
                Column.For(bim => bim.Reason).Named(htmlHelper.T(BannedIpConstants.Fields.Reason.Label));
        }
    }
}
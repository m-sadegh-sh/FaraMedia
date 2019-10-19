namespace FaraMedia.FrontEnd.Administration.GridModels.Common {
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.FrontEnd.Administration.Models.Common;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class ShareModelGrid : UserContentModelGridBase<ShareModel> {
        public ShareModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool ipAddress = true, bool creator = true, bool ownerId = true, bool sharedOn = true, bool sharer = true) : base(htmlHelper, isSelected, edit, CommonSectionConstants.SharesController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn, ipAddress, creator) {
            if (ownerId)
                Column.For(sm => sm.OwnerId).Named(htmlHelper.T(ShareConstants.Fields.OwnerId.Label));

            if (sharedOn)
                Column.For(sm => GenericHtmlHelper.EditorFor(trap => sm.ShareDate)).Named(htmlHelper.T(ShareConstants.Fields.ShareDateUtc.Label));

            if (sharer) {
                Column.For(sm => htmlHelper.RouteLinkWithId(sm.UserFullName, SecuritySectionConstants.UsersController.Edit.RouteName, sm.UserId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(ShareConstants.Fields.User.Label));
            }
        }
    }
}
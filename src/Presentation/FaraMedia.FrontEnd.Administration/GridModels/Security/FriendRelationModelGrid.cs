namespace FaraMedia.FrontEnd.Administration.GridModels.Miscellaneous {
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Security;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class FriendRequestModelGrid : EntityModelGridBase<FriendRequestModel> {
        public FriendRequestModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool isAccepted = true, bool beignFriendOn = true, bool message = true, bool @from = true, bool to = true)
            : base(htmlHelper, isSelected, false, null, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (isAccepted)
                Column.For(frm => frm.IsAccepted).Named(htmlHelper.T(FriendRequestConstants.Fields.IsAccepted.Label));

            if (beignFriendOn)
                Column.For(frm => GenericHtmlHelper.EditorFor(trap => frm.BeignFriendOn)).Named(htmlHelper.T(FriendRequestConstants.Fields.BeignFriendOnUtc.Label));

            if (message)
                Column.For(frm => frm.Message).Named(htmlHelper.T(FriendRequestConstants.Fields.Message.Label));

            if (@from) {
                Column.For(frm => htmlHelper.LocalizedRouteLinkWithId(frm.FromFullName, SecuritySectionConstants.UsersController.Edit.RouteName, frm.FromId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(FriendRequestConstants.Fields.From.Label));
            }

            if (to) {
                Column.For(frm => htmlHelper.LocalizedRouteLinkWithId(frm.ToFullName, SecuritySectionConstants.UsersController.Edit.RouteName, frm.ToId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(FriendRequestConstants.Fields.To.Label));
            }
        }
    }
}
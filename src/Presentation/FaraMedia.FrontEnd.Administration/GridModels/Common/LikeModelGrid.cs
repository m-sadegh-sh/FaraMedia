namespace FaraMedia.FrontEnd.Administration.GridModels.Common {
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.FrontEnd.Administration.Models.Common;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class LikeModelGrid : UserContentModelGridBase<LikeModel> {
        public LikeModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool ipAddress = true, bool creator = true, bool ownerId = true, bool likedOn = true, bool liker = true) : base(htmlHelper, isSelected, edit, CommonSectionConstants.LikesController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn, ipAddress, creator) {
            if (ownerId)
                Column.For(lm => lm.OwnerId).Named(htmlHelper.T(LikeConstants.Fields.OwnerId.Label));

            if (likedOn)
                Column.For(lm => GenericHtmlHelper.EditorFor(trap => lm.LikeDate)).Named(htmlHelper.T(LikeConstants.Fields.LikeDateUtc.Label));

            if (liker) {
                Column.For(lm => htmlHelper.RouteLinkWithId(lm.UserFullName, SecuritySectionConstants.UsersController.Edit.RouteName, lm.UserId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(LikeConstants.Fields.User.Label));
            }
        }
    }
}
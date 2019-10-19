namespace FaraMedia.FrontEnd.Administration.GridModels.Miscellaneous {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Systematic;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class LogModelGrid : EntityModelGridBase<LogModel> {
        public LogModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool logLevel = true, bool shortMessage = true, bool fullMessage = true, bool ipAddress = true, bool requestUrl = true, bool referrerUrl = true, bool user = true)
            : base(htmlHelper, isSelected, false, null, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (logLevel)
                Column.For(lm => lm.LogLevel).Named(htmlHelper.T(LogConstants.Fields.LogLevel.Label));

            if (shortMessage)
                Column.For(lm => lm.ShortMessage).Named(htmlHelper.T(LogConstants.Fields.ShortMessage.Label));

            if (fullMessage)
                Column.For(lm => lm.FullMessage).Named(htmlHelper.T(LogConstants.Fields.FullMessage.Label));

            if (ipAddress)
                Column.For(lm => lm.IpAddress).Named(htmlHelper.T(LogConstants.Fields.IpAddress.Label));

            if (requestUrl)
                Column.For(lm => lm.RequestedUrl).Named(htmlHelper.T(LogConstants.Fields.RequestedUrl.Label));

            if (referrerUrl)
                Column.For(lm => lm.ReferrerUrl).Named(htmlHelper.T(LogConstants.Fields.ReferrerUrl.Label));

            if (user) {
                Column.For(lm => htmlHelper.LocalizedRouteLinkWithId(lm.UserFullName, SecuritySectionConstants.UsersController.Edit.RouteName, lm.UserId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(LogConstants.Fields.User.Label));
            }
        }
    }
}
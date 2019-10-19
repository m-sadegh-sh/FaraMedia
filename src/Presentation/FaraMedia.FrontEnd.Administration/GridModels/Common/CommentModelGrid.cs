namespace FaraMedia.FrontEnd.Administration.GridModels.Common {
    using System.Web.Mvc;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.FrontEnd.Administration.Models.Common;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class CommentModelGrid : UserContentModelGridBase<CommentModel> {
        public CommentModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool ipAddress = true, bool creator = true, bool ownerId = true, bool title = true, bool body = true, bool repliedTo = true, bool replies = true) : base(htmlHelper, isSelected,edit,CommonSectionConstants.CommentsController.Edit.RouteName,id,isPublished,isDeleted,displayOrder,createdOn,lastModifiedOn,ipAddress,creator) {
            if (ownerId)
                Column.For(cm => cm.OwnerId).Named(htmlHelper.T(CommentConstants.Fields.OwnerId.Label));

            if (title)
                Column.For(cm => cm.Title).Named(htmlHelper.T(CommentConstants.Fields.Title.Label));

            if (body)
                Column.For(cm => cm.Body).Named(htmlHelper.T(CommentConstants.Fields.Body.Label));

            if (repliedTo) {
                Column.For(cm => htmlHelper.RouteLinkWithId(cm.InReplyToTitle, CommonSectionConstants.CommentsController.Edit.RouteName, cm.InReplyToId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(CommentConstants.Fields.InReplyTo.Label));
            }

            if (replies) {
                Column.For(cm => htmlHelper.SmartRouteLink(cm.RepliesCount.ToString(), CommonSectionConstants.CommentsController.ListByParentId.RouteName, RouteParameter.Add(KnownParameterNames.ParentId, cm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(CommentConstants.Fields.Replies.Label));
            }
        }
    }
}
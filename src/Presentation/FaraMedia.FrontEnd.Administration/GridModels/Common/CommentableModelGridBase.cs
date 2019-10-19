namespace FaraMedia.FrontEnd.Administration.GridModels.Common {
    using System.Web.Mvc;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.FrontEnd.Administration.Models.Common;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public abstract class CommentableModelGridBase<TModel> : UserContentModelGridBase<TModel> where TModel : CommentableModelBase {
        protected CommentableModelGridBase(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, string editRouteName = null, bool id = true, bool ipAddress = true, bool creator = true,bool isPublished = true, bool isDeleted = true,  bool allowComments = true, bool displayOrder = true,bool comments = true, bool likes = true, bool shares = true) : base(htmlHelper, isSelected, edit, editRouteName, id, ipAddress, creator) {
            if (isPublished)
                Column.For(cm => cm.IsPublished).Named(htmlHelper.T(CommentableConstants.Fields.IsPublished.Label));

            if (isDeleted)
                Column.For(cm => cm.IsDeleted).Named(htmlHelper.T(CommentableConstants.Fields.IsDeleted.Label));

            if (allowComments)
                Column.For(cm => cm.AllowComments).Named(htmlHelper.T(CommentableConstants.Fields.AllowComments.Label));

            if (displayOrder)
                Column.For(cm => cm.DisplayOrder).Named(htmlHelper.T(CommentableConstants.Fields.DisplayOrder.Label));

            if (comments) {
                Column.For(cm => htmlHelper.SmartRouteLink(cm.CommentsCount.ToString(), CommonSectionConstants.CommentsController.ListByOwnerId.RouteName, RouteParameter.Add(KnownParameterNames.OwnerId, cm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(CommentableConstants.Fields.CommentsCount.Label));
            }

            if (likes) {
                Column.For(cm => htmlHelper.SmartRouteLink(cm.LikesCount.ToString(), CommonSectionConstants.LikesController.ListByOwnerId.RouteName, RouteParameter.Add(KnownParameterNames.OwnerId, cm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(CommentableConstants.Fields.LikesCount.Label));
            }

            if (shares) {
                Column.For(cm => htmlHelper.SmartRouteLink(cm.SharesCount.ToString(), CommonSectionConstants.SharesController.ListByOwnerId.RouteName, RouteParameter.Add(KnownParameterNames.OwnerId, cm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(CommentableConstants.Fields.SharesCount.Label));
            }
        }
    }
}
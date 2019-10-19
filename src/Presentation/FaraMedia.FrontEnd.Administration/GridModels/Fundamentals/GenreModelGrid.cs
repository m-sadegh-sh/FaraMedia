namespace FaraMedia.FrontEnd.Administration.GridModels.Fundamentals {
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Fundamentals;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class GenreModelGrid : CommentableModelGridBase<GenreModel> {
        public GenreModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool ipAddress = true, bool creator = true, bool allowComments = true, bool comments = true, bool likes = true, bool shares = true, bool title = true, bool description = true, bool metadata = true, bool tracks = true)
            : base(htmlHelper, isSelected, edit, FundamentalsSecctionConstants.FundamentalsController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn, ipAddress, creator, allowComments, commentsCount, likesCount, shares) {
            if (title)
                Column.For(gm => gm.Title).Named(htmlHelper.T(GenreConstants.Fields.Title.Label));

            if (description)
                Column.For(gm => gm.Description).Named(htmlHelper.T(GenreConstants.Fields.Description.Label));

            if (metadata)
                Column.For(gm => GenericHtmlHelper.EditorFor(trap => gm.Metadata)).Named(htmlHelper.T(CommonConstants.Fields.Metadata.Label));

            if (tracks) {
                Column.For(gm => htmlHelper.LocalizedRouteLink(gm.FundamentalsCount.ToString(), FundamentalsSecctionConstants.FundamentalsController.ListByGenreId.RouteName, RouteParameter.Add(KnownParameterNames.GenreId, gm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(GenreConstants.Fields.Fundamentals.Label));
            }
        }
    }
}
namespace FaraMedia.FrontEnd.Administration.GridModels.Fundamentals {
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Fundamentals;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class AlbumModelGrid : CommentableModelGridBase<AlbumModel> {
        public AlbumModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool ipAddress = true, bool creator = true, bool allowComments = true, bool comments = true, bool likes = true, bool shares = true, bool releasedOn = true, bool title = true, bool description = true, bool metadata = true, bool tracks = true)
            : base(htmlHelper, isSelected, edit, FundamentalsSecctionConstants.FundamentalsController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn, ipAddress, creator, allowComments, commentsCount, likesCount, shares) {
            if (releasedOn)
                Column.For(am => GenericHtmlHelper.EditorFor(trap => am.ReleaseDate)).Named(htmlHelper.T(AlbumConstants.Fields.ReleaseDateUtc.Label));

            if (title)
                Column.For(am => am.Title).Named(htmlHelper.T(AlbumConstants.Fields.Title.Label));

            if (description)
                Column.For(am => am.Description).Named(htmlHelper.T(AlbumConstants.Fields.Description.Label));

            if (metadata)
                Column.For(am => GenericHtmlHelper.EditorFor(trap => am.Metadata)).Named(htmlHelper.T(CommonConstants.Fields.Metadata.Label));

            if (tracks) {
                Column.For(am => htmlHelper.LocalizedRouteLink(am.FundamentalsCount.ToString(), FundamentalsSecctionConstants.FundamentalsController.ListByAlbumId.RouteName, RouteParameter.Add(KnownParameterNames.AlbumId, am.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(AlbumConstants.Fields.Fundamentals.Label));
            }
        }
    }
}
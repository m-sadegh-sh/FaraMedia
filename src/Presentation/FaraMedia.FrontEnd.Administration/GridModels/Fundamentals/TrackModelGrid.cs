namespace FaraMedia.FrontEnd.Administration.GridModels.Fundamentals {
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Data.Schemas.FileManagement;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Fundamentals;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class TrackModelGrid : CommentableModelGridBase<TrackModel> {
        public TrackModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool ipAddress = true, bool creator = true, bool allowComments = true, bool comments = true, bool likes = true, bool shares = true, bool isVideo = true, bool trackNumber = true, bool releasedOn = true, bool title = true, bool description = true, bool metadata = true, bool genre = true, bool publisher = true, bool album = true, bool singers = true,
                              bool composers = true, bool arrangementers = true, bool songwriters = true, bool covers = true, bool downloads = true) :
                                  base(htmlHelper, isSelected, edit, FundamentalsSecctionConstants.FundamentalsController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn, ipAddress, creator, allowComments, commentsCount, likesCount, shares) {
            if (isVideo)
                Column.For(tm => tm.IsVideo).Named(htmlHelper.T(TrackConstants.Fields.IsVideo.Label));

            if (trackNumber)
                Column.For(tm => tm.TrackNumber).Named(htmlHelper.T(TrackConstants.Fields.TrackNumber.Label));

            if (releasedOn)
                Column.For(tm => GenericHtmlHelper.EditorFor(trap => tm.ReleaseDate)).Named(htmlHelper.T(TrackConstants.Fields.ReleaseDateUtc.Label));

            if (title)
                Column.For(tm => tm.Title).Named(htmlHelper.T(TrackConstants.Fields.Title.Label));

            if (description)
                Column.For(tm => tm.Description).Named(htmlHelper.T(TrackConstants.Fields.Description.Label));

            if (metadata)
                Column.For(tm => GenericHtmlHelper.EditorFor(trap => tm.Metadata)).Named(htmlHelper.T(CommonConstants.Fields.Metadata.Label));

            if (singers) {
                Column.For(tm => htmlHelper.LocalizedRouteLink(tm.SingersCount.ToString(), FundamentalsSecctionConstants.FundamentalsController.ListByTrackId.RouteName, RouteParameter.Add(KnownParameterNames.TrackId, tm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(TrackConstants.Fields.Singers.Label));
            }

            if (composers) {
                Column.For(tm => htmlHelper.LocalizedRouteLink(tm.ComposersCount.ToString(), FundamentalsSecctionConstants.FundamentalsController.ListByTrackId.RouteName, RouteParameter.Add(KnownParameterNames.TrackId, tm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(TrackConstants.Fields.Composers.Label));
            }

            if (arrangementers) {
                Column.For(tm => htmlHelper.LocalizedRouteLink(tm.ArrangementersCount.ToString(), FundamentalsSecctionConstants.FundamentalsController.ListByTrackId.RouteName, RouteParameter.Add(KnownParameterNames.TrackId, tm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(TrackConstants.Fields.Arrangementers.Label));
            }

            if (songwriters) {
                Column.For(tm => htmlHelper.LocalizedRouteLink(tm.SongwritersCount.ToString(), FundamentalsSecctionConstants.FundamentalsController.ListByTrackId.RouteName, RouteParameter.Add(KnownParameterNames.TrackId, tm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(TrackConstants.Fields.Songwriters.Label));
            }

            if (covers) {
                Column.For(tm => htmlHelper.LocalizedRouteLink(tm.CoversCount.ToString(), FileManagementSectionConstants.PicturesController.ListByTrackId.RouteName, RouteParameter.Add(KnownParameterNames.TrackId, tm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(TrackConstants.Fields.Covers.Label));
            }

            if (downloads) {
                Column.For(tm => htmlHelper.LocalizedRouteLink(tm.DownloadsCount.ToString(), FileManagementSectionConstants.DownloadsController.ListByTrackId.RouteName, RouteParameter.Add(KnownParameterNames.TrackId, tm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(TrackConstants.Fields.Downloads.Label));
            }
        }
    }
}
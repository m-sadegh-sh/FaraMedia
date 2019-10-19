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

    public sealed class ArtistModelGrid : CommentableModelGridBase<ArtistModel> {
        public ArtistModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool ipAddress = true, bool creator = true, bool allowComments = true, bool comments = true, bool likes = true, bool shares = true, bool birthDateOn = true, bool fullName = true, bool alternativeName = true, bool homeTown = true, bool biography = true, bool metadata = true, bool facebookTargetUrl = true,
                               bool avatar = true, bool photoAlbums = true, bool singedTracks = true, bool composedTracks = true, bool arrangedTracks = true, bool songwrittenTracks = true) :
                                   base(htmlHelper, isSelected, edit, FundamentalsSecctionConstants.FundamentalsController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn, ipAddress, creator, allowComments, commentsCount, likesCount, shares) {
            if (birthDateOn)
                Column.For(am => GenericHtmlHelper.EditorFor(trap => am.BirthDate)).Named(htmlHelper.T(ArtistConstants.Fields.BirthDateUtc.Label));

            if (fullName)
                Column.For(am => am.FullName).Named(htmlHelper.T(ArtistConstants.Fields.FullName.Label));

            if (alternativeName)
                Column.For(am => am.AlternativeName).Named(htmlHelper.T(ArtistConstants.Fields.AlternativeName.Label));

            if (homeTown)
                Column.For(am => am.HomeTown).Named(htmlHelper.T(ArtistConstants.Fields.HomeTown.Label));

            if (biography)
                Column.For(am => am.Biography).Named(htmlHelper.T(ArtistConstants.Fields.Biography.Label));

            if (metadata)
                Column.For(am => GenericHtmlHelper.EditorFor(trap => am.Metadata)).Named(htmlHelper.T(CommonConstants.Fields.Metadata.Label));

            if (photoAlbums) {
                Column.For(am => htmlHelper.LocalizedRouteLink(am.PhotoAlbumsCount.ToString(), FundamentalsSecctionConstants.PhotoAlbumsController.ListByArtistId.RouteName, RouteParameter.Add(KnownParameterNames.ArtistId, am.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(ArtistConstants.Fields.Albums.Label));
            }

            if (singedTracks) {
                Column.For(am => htmlHelper.LocalizedRouteLink(am.SingedTracksCount.ToString(), FundamentalsSecctionConstants.FundamentalsController.ListByArtistId.RouteName, RouteParameter.Add(KnownParameterNames.ArtistId, am.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(ArtistConstants.Fields.SingedTracks.Label));
            }

            if (composedTracks) {
                Column.For(am => htmlHelper.LocalizedRouteLink(am.ComposedTracksCount.ToString(), FundamentalsSecctionConstants.FundamentalsController.ListByArtistId.RouteName, RouteParameter.Add(KnownParameterNames.ArtistId, am.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(ArtistConstants.Fields.ComposedTracks.Label));
            }

            if (arrangedTracks) {
                Column.For(am => htmlHelper.LocalizedRouteLink(am.ArrangedTracksCount.ToString(), FundamentalsSecctionConstants.FundamentalsController.ListByArtistId.RouteName, RouteParameter.Add(KnownParameterNames.ArtistId, am.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(ArtistConstants.Fields.ArrangedTracks.Label));
            }

            if (songwrittenTracks) {
                Column.For(am => htmlHelper.LocalizedRouteLink(am.SongwrittenTracksCount.ToString(), FundamentalsSecctionConstants.FundamentalsController.ListByArtistId.RouteName, RouteParameter.Add(KnownParameterNames.ArtistId, am.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(ArtistConstants.Fields.SongwrittenTracks.Label));
            }
        }
    }
}
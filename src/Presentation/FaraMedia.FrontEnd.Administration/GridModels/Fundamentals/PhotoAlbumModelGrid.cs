namespace FaraMedia.FrontEnd.Administration.GridModels.PhotoAlbums {
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

    public sealed class PhotoAlbumModelGrid : CommentableModelGridBase<PhotoAlbumModel> {
        public PhotoAlbumModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool ipAddress = true, bool creator = true, bool allowComments = true, bool comments = true, bool likes = true, bool shares = true, bool title = true, bool description = true, bool metadata = true, bool artist = true, bool photos = true) : base(htmlHelper, isSelected, edit, FundamentalsSecctionConstants.PhotoAlbumsController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn, ipAddress, creator, allowComments, commentsCount, likesCount, shares) {
            if (title)
                Column.For(pam => pam.Title).Named(htmlHelper.T(PhotoAlbumConstants.Fields.Title.Label));

            if (description)
                Column.For(pam => pam.Description).Named(htmlHelper.T(PhotoAlbumConstants.Fields.Description.Label));

            if (metadata)
                Column.For(pam => GenericHtmlHelper.EditorFor(trap => pam.Metadata)).Named(htmlHelper.T(CommonConstants.Fields.Metadata.Label));

            if (artist) {
                Column.For(pam => htmlHelper.LocalizedRouteLinkWithId(pam.ArtistFullName, FundamentalsSecctionConstants.FundamentalsController.Edit.RouteName, pam.ArtistId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(PhotoAlbumConstants.Fields.Artist.Label));
            }

            if (photos) {
                Column.For(pam => htmlHelper.LocalizedRouteLink(pam.PhotosCount.ToString(), FundamentalsSecctionConstants.PhotosController.ListByPhotoAlbumId.RouteName, RouteParameter.Add(KnownParameterNames.PhotoAlbumId, pam.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(PhotoAlbumConstants.Fields.Photos.Label));
            }
        }
    }
}
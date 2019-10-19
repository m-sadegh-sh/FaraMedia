namespace FaraMedia.FrontEnd.Administration.GridModels.Photos {
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using FaraMedia.Data.Schemas.FileManagement;
    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Fundamentals;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class PhotoModelGrid : CommentableModelGridBase<PhotoModel> {
        public PhotoModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool ipAddress = true, bool creator = true, bool allowComments = true, bool comments = true, bool likes = true, bool shares = true, bool title = true, bool description = true, bool metadata = true, bool photoAlbum = true, bool picture = true) : base(htmlHelper, isSelected, edit, FundamentalsSecctionConstants.PhotosController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn, ipAddress, creator, allowComments, commentsCount, likesCount, shares) {
            if (title)
                Column.For(pm => pm.Title).Named(htmlHelper.T(PhotoConstants.Fields.Title.Label));

            if (description)
                Column.For(pm => pm.Description).Named(htmlHelper.T(PhotoConstants.Fields.Description.Label));

            if (metadata)
                Column.For(pm => GenericHtmlHelper.EditorFor(trap => pm.Metadata)).Named(htmlHelper.T(CommonConstants.Fields.Metadata.Label));

            if (photoAlbum) {
                Column.For(pm => htmlHelper.LocalizedRouteLinkWithId(pm.PhotoAlbumTitle, FundamentalsSecctionConstants.PhotoAlbumsController.Edit.RouteName, pm.PhotoAlbumId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(PhotoConstants.Fields.PhotoAlbum.Label));
            }

            if (picture) {
                Column.For(pm => htmlHelper.LocalizedRouteLinkWithId(pm.PictureFileName, FileManagementSectionConstants.PicturesController.Edit.RouteName, pm.PictureId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(PhotoConstants.Fields.Picture.Label));
            }
        }
    }
}
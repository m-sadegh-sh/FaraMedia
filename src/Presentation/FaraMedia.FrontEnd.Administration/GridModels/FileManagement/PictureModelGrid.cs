namespace FaraMedia.FrontEnd.Administration.GridModels.FileManagement {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.FileManagement;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.FileManagement;
    using FaraMedia.Web.Framework.Mvc.Extensions;

    public sealed class PictureModelGrid : EntityModelGridBase<PictureModel> {
        public PictureModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool mimeType = true, bool fileName = true) : base(htmlHelper, isSelected, edit, FileManagementSectionConstants.PicturesController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (mimeType)
                Column.For(pm => pm.MimeType).Named(htmlHelper.T(PictureConstants.Fields.MimeType.Label));

            if (fileName)
                Column.For(pm => pm.FileName).Named(htmlHelper.T(PictureConstants.Fields.FileName.Label));
        }
    }
}
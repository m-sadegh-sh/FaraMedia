namespace FaraMedia.FrontEnd.Administration.GridModels.FileManagement {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.FileManagement;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.FileManagement;
    using FaraMedia.Web.Framework.Mvc.Extensions;

    public sealed class DownloadModelGrid : EntityModelGridBase<DownloadModel> {
        public DownloadModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool useDownloadUrl = true, bool contentType = true, bool fileName = true, bool extension = true, bool downloadUrlTargetUrl = true) : base(htmlHelper, isSelected, edit, FileManagementSectionConstants.DownloadsController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (useDownloadUrl)
                Column.For(dm => dm.UseDownloadUrl).Named(htmlHelper.T(DownloadConstants.Fields.UseDownloadUrl.Label));

            if (contentType)
                Column.For(dm => dm.ContentType).Named(htmlHelper.T(DownloadConstants.Fields.ContentType.Label));

            if (fileName)
                Column.For(dm => dm.FileName).Named(htmlHelper.T(DownloadConstants.Fields.FileName.Label));

            if (extension)
                Column.For(dm => dm.Extension).Named(htmlHelper.T(DownloadConstants.Fields.Extension.Label));

            if (downloadUrlTargetUrl)
                Column.For(dm => dm.DownloadUrlTargetUrl).Named(htmlHelper.T(DownloadConstants.Fields.DownloadUrl.Label));
        }
    }
}
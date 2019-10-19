namespace FaraMedia.FrontEnd.Administration.Controllers {
    using System;
    using System.Linq;

    using FaraMedia.Core.Domain.FileManagement;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.FrontEnd.Administration.Controllers.Abstracts;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.FrontEnd.Administration.Models.FileManagement;
    using FaraMedia.FrontEnd.Administration.Models.FileManagement.Editable;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.FileManagement;
    using FaraMedia.Services.Security;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.UI;

    [SectionName(MediaSectionConstants.SectionName)]
    public class DownloadsController : AbstractFullCrudControllerBase<Download, DownloadModel, EditableDownloadModel> {
        private readonly IDownloadService _downloadService;

        public DownloadsController(IDownloadService downloadService) {
            _downloadService = downloadService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageDownloads; }
        }

        protected override Func<EditableDownloadModel> GetInitialEditableModelInstance {
            get {
                return () => new EditableDownloadModel {
                    IsPublished = true
                };
            }
        }

        protected override void InjectModelDependencies(EditableDownloadModel editableDownloadModel) {
        }

        protected override Func<Download> GetEntityById(long id) {
            return () => _downloadService.GetDownloadById(id);
        }

        protected override Func<Download> LoadEntityById(long id) {
            return () => _downloadService.LoadDownloadById(id);
        }

        protected override Func<IQueryable<Download>> GetAllEntities {
            get { return () => _downloadService.GetAllDownloads(); }
        }

        protected override Func<ServiceOperationResult> InsertEntityAndReturnOperationResult(Download download) {
            return () => _downloadService.InsertDownload(download);
        }

        protected override Func<ServiceOperationResult> UpdateEntityAndReturnOperationResult(Download download) {
            return () => _downloadService.UpdateDownload(download);
        }

        protected override Func<ServiceOperationResult> DeleteEntityAndReturnOperationResult(Download download, bool onlyChangeFlag = true) {
            return () => _downloadService.DeleteDownload(download, onlyChangeFlag);
        }
    }
}
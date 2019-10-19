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
    public class PicturesController : AbstractFullCrudControllerBase<Picture, PictureModel, EditablePictureModel> {
        private readonly IPictureService _pictureService;

        public PicturesController(IPictureService pictureService) {
            _pictureService = pictureService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManagePictures; }
        }

        protected override Func<EditablePictureModel> GetInitialEditableModelInstance {
            get {
                return () => new EditablePictureModel {
                    IsPublished = true
                };
            }
        }

        protected override void InjectModelDependencies(EditablePictureModel editablePictureModel) {
        }

        protected override Func<Picture> GetEntityById(long id) {
            return () => _pictureService.GetPictureById(id);
        }

        protected override Func<Picture> LoadEntityById(long id) {
            return () => _pictureService.LoadPictureById(id);
        }

        protected override Func<IQueryable<Picture>> GetAllEntities {
            get { return () => _pictureService.GetAllPictures(); }
        }

        protected override Func<ServiceOperationResult> InsertEntityAndReturnOperationResult(Picture picture) {
            return () => _pictureService.InsertPicture(picture);
        }

        protected override Func<ServiceOperationResult> UpdateEntityAndReturnOperationResult(Picture picture) {
            return () => _pictureService.UpdatePicture(picture);
        }

        protected override Func<ServiceOperationResult> DeleteEntityAndReturnOperationResult(Picture picture, bool onlyChangeFlag = true) {
            return () => _pictureService.DeletePicture(picture, onlyChangeFlag);
        }
    }
}
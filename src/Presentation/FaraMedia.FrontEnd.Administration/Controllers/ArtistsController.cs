namespace FaraMedia.FrontEnd.Administration.Controllers {
    using System;
    using System.Linq;

    using FaraMedia.Core.Domain.Fundamentals;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.FrontEnd.Administration.Controllers.Abstracts;
    using FaraMedia.FrontEnd.Administration.Models.Fundamentals;
    using FaraMedia.FrontEnd.Administration.Models.Fundamentals.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.Services.Fundamentals;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.FileManagement;
    using FaraMedia.Services.Security;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.UI;

    [SectionName(ArtistsSectionConstants.SectionName)]
    public class ArtistsController : AbstractFullCrudControllerBase<Artist, ArtistModel, EditableArtistModel> {
        private readonly IPictureService _pictureService;
        private readonly IArtistService _artistService;

        public ArtistsController(IPictureService pictureService, IArtistService artistService) {
            _pictureService = pictureService;
            _artistService = artistService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageArtists; }
        }

        protected override Func<EditableArtistModel> GetInitialEditableModelInstance {
            get {
                return () => new EditableArtistModel {
                    IsPublished = true
                };
            }
        }

        protected override void InjectModelDependencies(EditableArtistModel editableArtistModel) {
            if (editableArtistModel.Metadata == null)
                editableArtistModel.Metadata = new EditableMetadataComponentModel();

            editableArtistModel.AvailableAvatars = _pictureService.GetAllPictures().ToSelectList(p => p.Id, c => c.FileName, editableArtistModel.AvatarId);
        }

        protected override Func<Artist> GetEntityById(long id) {
            return () => _artistService.GetArtistById(id);
        }

        protected override Func<Artist> LoadEntityById(long id) {
            return () => _artistService.LoadArtistById(id);
        }

        protected override Func<IQueryable<Artist>> GetAllEntities {
            get { return () => _artistService.GetAllArtists(); }
        }

        protected override Func<ServiceOperationResult> InsertEntityAndReturnOperationResult(Artist artist) {
            return () => _artistService.InsertArtist(artist);
        }

        protected override Func<ServiceOperationResult> UpdateEntityAndReturnOperationResult(Artist artist) {
            return () => _artistService.UpdateArtist(artist);
        }

        protected override Func<ServiceOperationResult> DeleteEntityAndReturnOperationResult(Artist artist, bool onlyChangeFlag = true) {
            return () => _artistService.DeleteArtist(artist, onlyChangeFlag);
        }
    }
}
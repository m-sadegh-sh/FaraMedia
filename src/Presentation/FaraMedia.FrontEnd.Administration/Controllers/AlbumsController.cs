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
    using FaraMedia.Services.Fundamentals;
    using FaraMedia.Services.Security;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.UI;

    [SectionName(AlbumsSectionConstants.SectionName)]
    public class AlbumsController : AbstractFullCrudControllerBase<Album, AlbumModel, EditableAlbumModel> {
        private readonly IPublisherService _publisherService;
        private readonly IAlbumService _albumService;

        public AlbumsController(IPublisherService publisherService, IAlbumService albumService) {
            _publisherService = publisherService;
            _albumService = albumService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageAlbums; }
        }

        protected override Func<EditableAlbumModel> GetInitialEditableModelInstance {
            get {
                return () => new EditableAlbumModel {
                    IsPublished = true
                };
            }
        }

        protected override void InjectModelDependencies(EditableAlbumModel editableAlbumModel) {
            if (editableAlbumModel.Metadata == null)
                editableAlbumModel.Metadata = new EditableMetadataComponentModel();

            editableAlbumModel.AvailablePublishers = _publisherService.GetAllPublishers().ToSelectList(p => p.Id, c => c.Name, editableAlbumModel.PublisherId);
        }

        protected override Func<Album> GetEntityById(long id) {
            return () => _albumService.GetAlbumById(id);
        }

        protected override Func<Album> LoadEntityById(long id) {
            return () => _albumService.LoadAlbumById(id);
        }

        protected override Func<IQueryable<Album>> GetAllEntities {
            get { return () => _albumService.GetAllAlbums(); }
        }

        protected override Func<ServiceOperationResult> InsertEntityAndReturnOperationResult(Album album) {
            return () => _albumService.InsertAlbum(album);
        }

        protected override Func<ServiceOperationResult> UpdateEntityAndReturnOperationResult(Album album) {
            return () => _albumService.UpdateAlbum(album);
        }

        protected override Func<ServiceOperationResult> DeleteEntityAndReturnOperationResult(Album album, bool onlyChangeFlag = true) {
            return () => _albumService.DeleteAlbum(album, onlyChangeFlag);
        }
    }
}
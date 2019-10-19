namespace FaraMedia.FrontEnd.Administration.Controllers {
    using System;
    using System.Linq;

    using FaraMedia.Core.Domain.Fundamentals;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.FrontEnd.Administration.Controllers.Abstracts;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Fundamentals;
    using FaraMedia.FrontEnd.Administration.Models.Fundamentals.Editable;
    using FaraMedia.Services.Fundamentals;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.Security;
    using FaraMedia.Web.Framework.Mvc.Attributes;

    [SectionName(GenresSectionConstants.SectionName)]
    public class GenresController : AbstractFullCrudControllerBase<Genre, GenreModel, EditableGenreModel> {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService) {
            _genreService = genreService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageGenres; }
        }

        protected override Func<EditableGenreModel> GetInitialEditableModelInstance {
            get {
                return () => new EditableGenreModel {
                    IsPublished = true
                };
            }
        }

        protected override void InjectModelDependencies(EditableGenreModel editableGenreModel) {
            if (editableGenreModel.Metadata == null)
                editableGenreModel.Metadata = new EditableMetadataComponentModel();
        }

        protected override Func<Genre> GetEntityById(long id) {
            return () => _genreService.GetGenreById(id);
        }

        protected override Func<Genre> LoadEntityById(long id) {
            return () => _genreService.LoadGenreById(id);
        }

        protected override Func<IQueryable<Genre>> GetAllEntities {
            get { return () => _genreService.GetAllGenres(); }
        }

        protected override Func<ServiceOperationResult> InsertEntityAndReturnOperationResult(Genre genre) {
            return () => _genreService.InsertGenre(genre);
        }

        protected override Func<ServiceOperationResult> UpdateEntityAndReturnOperationResult(Genre genre) {
            return () => _genreService.UpdateGenre(genre);
        }

        protected override Func<ServiceOperationResult> DeleteEntityAndReturnOperationResult(Genre genre, bool onlyChangeFlag = true) {
            return () => _genreService.DeleteGenre(genre, onlyChangeFlag);
        }
    }
}
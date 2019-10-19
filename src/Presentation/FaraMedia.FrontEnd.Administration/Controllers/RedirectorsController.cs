namespace FaraMedia.FrontEnd.Administration.Controllers {
    using System;
    using System.Linq;

    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Domain.Miscellaneous;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.FrontEnd.Administration.Controllers.Abstracts;
    using FaraMedia.FrontEnd.Administration.Models.Miscellaneous;
    using FaraMedia.FrontEnd.Administration.Models.Miscellaneous.Editable;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.Security;
    using FaraMedia.Services.Miscellaneous;
    using FaraMedia.Web.Framework.Mvc.Attributes;

    [SectionName(StatisticsSectionConstants.SectionName)]
    public class RedirectorsController : AbstractFullCrudControllerBase<Redirector, RedirectorModel, EditableRedirectorModel> {
        private readonly IRedirectorService _redirectorService;

        public RedirectorsController(IRedirectorService redirectorService) {
            _redirectorService = redirectorService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageRedirectors; }
        }

        protected override Func<EditableRedirectorModel> GetInitialEditableModelInstance {
            get {
                return () => new EditableRedirectorModel {
                    IsPublished = true
                };
            }
        }

        protected override void InjectModelDependencies(EditableRedirectorModel editableRedirectorModel) {}

        protected override Func<Redirector> GetEntityById(long id) {
            return () => _redirectorService.GetRedirectorById(id);
        }

        protected override Func<Redirector> LoadEntityById(long id) {
            return () => _redirectorService.LoadRedirectorById(id);
        }

        protected override Func<IQueryable<Redirector>> GetAllEntities {
            get { return () => _redirectorService.GetAllRedirectors(); }
        }

        protected override Func<ServiceOperationResult> InsertEntityAndReturnOperationResult(Redirector redirector) {
            return () => _redirectorService.InsertRedirector(redirector);
        }

        protected override Func<ServiceOperationResult> UpdateEntityAndReturnOperationResult(Redirector redirector) {
            return () => _redirectorService.UpdateRedirector(redirector);
        }

        protected override Func<ServiceOperationResult> DeleteEntityAndReturnOperationResult(Redirector redirector, bool onlyChangeFlag = true) {
            return () => _redirectorService.DeleteRedirector(redirector, onlyChangeFlag);
        }
    }
}
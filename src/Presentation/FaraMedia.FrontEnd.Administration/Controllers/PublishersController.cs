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
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.Fundamentals;
    using FaraMedia.Services.Security;
    using FaraMedia.Web.Framework.Mvc.Attributes;

    [SectionName(PublishersSectionConstants.SectionName)]
    public class PublishersController : AbstractFullCrudControllerBase<Publisher, PublisherModel, EditablePublisherModel> {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService) {
            _publisherService = publisherService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManagePublishers; }
        }

        protected override Func<EditablePublisherModel> GetInitialEditableModelInstance {
            get {
                return () => new EditablePublisherModel {
                    IsPublished = true
                };
            }
        }

        protected override void InjectModelDependencies(EditablePublisherModel editablePublisherModel) {
            if (editablePublisherModel.Metadata == null)
                editablePublisherModel.Metadata = new EditableMetadataComponentModel();
        }

        protected override Func<Publisher> GetEntityById(long id) {
            return () => _publisherService.GetPublisherById(id);
        }

        protected override Func<Publisher> LoadEntityById(long id) {
            return () => _publisherService.LoadPublisherById(id);
        }

        protected override Func<IQueryable<Publisher>> GetAllEntities {
            get { return () => _publisherService.GetAllPublishers(); }
        }

        protected override Func<ServiceOperationResult> InsertEntityAndReturnOperationResult(Publisher publisher) {
            return () => _publisherService.InsertPublisher(publisher);
        }

        protected override Func<ServiceOperationResult> UpdateEntityAndReturnOperationResult(Publisher publisher) {
            return () => _publisherService.UpdatePublisher(publisher);
        }

        protected override Func<ServiceOperationResult> DeleteEntityAndReturnOperationResult(Publisher publisher, bool onlyChangeFlag = true) {
            return () => _publisherService.DeletePublisher(publisher, onlyChangeFlag);
        }
    }
}
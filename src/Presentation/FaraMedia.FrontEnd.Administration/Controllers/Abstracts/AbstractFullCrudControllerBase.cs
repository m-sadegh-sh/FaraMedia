namespace FaraMedia.FrontEnd.Administration.Controllers.Abstracts {
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using FaraMedia.Core.Domain.Common;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Data.Schemas.Layout;
    using FaraMedia.FrontEnd.Administration.Infrastructure;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Controllers;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Mvc.Models;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;
    using FaraMedia.Web.Framework.UI.DataPager;

    public abstract class AbstractFullCrudControllerBase<TEntity, TModel, TEditableModel> : FullCrudControllerBase<TEditableModel> where TEntity : EntityBase where TModel : EntityModelBase where TEditableModel : EditableEntityModelBase {
        private readonly AdminAreaSettings _adminAreaSettings;

        protected AbstractFullCrudControllerBase() {
            _adminAreaSettings = EngineContext.Current.Resolve<AdminAreaSettings>();
        }

        [HttpGet]
        public override ActionResult List(int page = 1) {
            if (!IsUserizedRequest)
                return AccessDeniedView();

            var entities = GetAllEntities();

            var entityModels = new PagedList<TModel>(entities.Select(e => e.ToModel<TEntity, TModel>()).ToList(), page, _adminAreaSettings.GridPageSize);

            if (entityModels.TotalItemCount > 0 && entityModels.StartRecordIndex > entityModels.EndRecordIndex) {
                ResourceErrorNotification(CrudSharedConstants.Systematic.InvalidParameter);
                return RedirectToAction(KnownActionNames.List, RouteParameter.Add(KnownParameterNames.Page, 1));
            }

            return View(entityModels);
        }

        [HttpPost]
        [FormValuesToArray("ids")]
        [DetectPostAction("postAction")]
        public ActionResult List(long[] ids, PostAction postAction) {
            if (!IsUserizedRequest)
                return AccessDeniedView();

            if (postAction == PostAction.Unknown) {
                ResourceErrorNotification(CrudSharedConstants.Systematic.InvalidParameter);
                return RedirectToAction(KnownActionNames.List, RouteParameter.Add(KnownParameterNames.Page, 1));
            }

            if (!ids.Any()) {
                ResourceErrorNotification(CrudSharedConstants.Systematic.InvalidParameter);
                return RedirectToAction(KnownActionNames.List, RouteParameter.Add(KnownParameterNames.Page, 1));
            }

            var isSuccess = false;

            foreach (var id in ids) {
                var entity = LoadEntityById(id)();

                if (entity == null)
                    return HandleUnknown(id);

                ServiceOperationResult operationResult;

                switch (postAction) {
                    case PostAction.PublishAll:
                        entity.IsPublished = true;
                        operationResult = UpdateEntityAndReturnOperationResult(entity)();
                        break;
                    case PostAction.UnpublishAll:
                        entity.IsPublished = false;
                        operationResult = UpdateEntityAndReturnOperationResult(entity)();
                        break;
                    case PostAction.TemporarilyDeleteAll:
                        operationResult = DeleteEntityAndReturnOperationResult(entity)();
                        break;
                    case PostAction.UnDeleteAll:
                        entity.IsDeleted = false;
                        operationResult = UpdateEntityAndReturnOperationResult(entity)();
                        break;
                    default:
                        operationResult = DeleteEntityAndReturnOperationResult(entity, false)();
                        break;
                }

                if (!isSuccess)
                    isSuccess = operationResult.Success;
            }

            if (!isSuccess) {
                string key;

                switch (postAction) {
                    case PostAction.PublishAll:
                    case PostAction.UnpublishAll:
                    case PostAction.TemporarilyDeleteAll:
                    case PostAction.UnDeleteAll:
                        key = CommonConstants.Systematic.NotUpdated;
                        break;
                    default:
                        key = CommonConstants.Systematic.NotDeleted;
                        break;
                }

                ResourceErrorNotification(key);
            } else {
                string key;

                switch (postAction) {
                    case PostAction.PublishAll:
                    case PostAction.UnpublishAll:
                    case PostAction.TemporarilyDeleteAll:
                    case PostAction.UnDeleteAll:
                        key = CommonConstants.Systematic.Updated;
                        break;
                    default:
                        key = CommonConstants.Systematic.Deleted;
                        break;
                }

                ResourceSuccessNotification(key);
            }

            return RedirectToAction(KnownActionNames.List, RouteParameter.Add(KnownParameterNames.Page, 1));
        }

        [HttpGet]
        public override ActionResult New() {
            if (!IsUserizedRequest)
                return AccessDeniedView();

            var editableModel = GetInitialEditableModelInstance();

            InjectModelDependencies(editableModel);

            return View(editableModel);
        }

        [HttpPost]
        [FormValueExists("create", "create-continue", "continueEditing")]
        public override ActionResult New(TEditableModel editableModel, bool continueEditing) {
            if (!IsUserizedRequest)
                return AccessDeniedView();

            if (!ModelState.IsValid) {
                InjectModelDependencies(editableModel);

                return View(editableModel);
            }

            var entity = editableModel.ToEntity<TEditableModel, TEntity>();

            var operationResult = InsertEntityAndReturnOperationResult(entity)();

            if (!operationResult.Success) {
                ModelState.InjectMessages(operationResult);
                ResourceErrorNotification(CommonConstants.Systematic.NotInserted);

                InjectModelDependencies(editableModel);

                return View(editableModel);
            }

            ResourceSuccessNotification(CommonConstants.Systematic.Inserted);

            if (continueEditing)
                return RedirectToAction(KnownActionNames.Edit, RouteParameter.Add(KnownParameterNames.Id, entity.Id));

            return RedirectToAction(KnownActionNames.List, RouteParameter.Add(KnownParameterNames.Page, 1));
        }

        [HttpGet]
        public override ActionResult Edit(long id) {
            if (!IsUserizedRequest)
                return AccessDeniedView();

            var entity = GetEntityById(id)();

            if (entity == null)
                return HandleUnknown(id);

            var editableModel = entity.ToEditableModel<TEntity, TEditableModel>();

            InjectModelDependencies(editableModel);

            return View(editableModel);
        }

        [HttpPost]
        [FormValueExists("update", "update-continue", "continueEditing")]
        public override ActionResult Edit(TEditableModel editableModel, bool continueEditing) {
            if (!IsUserizedRequest)
                return AccessDeniedView();

            if (!ModelState.IsValid) {
                InjectModelDependencies(editableModel);

                return View(editableModel);
            }

            var entity = GetEntityById(editableModel.Id)();

            if (entity == null)
                return HandleUnknown(editableModel.Id);

            entity = editableModel.ToEntity(entity);

            var operationResult = UpdateEntityAndReturnOperationResult(entity)();

            if (!operationResult.Success) {
                ModelState.InjectMessages(operationResult);
                ResourceErrorNotification(CommonConstants.Systematic.NotUpdated);

                InjectModelDependencies(editableModel);

                return View(editableModel);
            }

            ResourceSuccessNotification(CommonConstants.Systematic.Updated);

            if (continueEditing)
                return RedirectToAction(KnownActionNames.Edit, RouteParameter.Add(KnownParameterNames.Id, entity.Id));

            return RedirectToAction(KnownActionNames.List, RouteParameter.Add(KnownParameterNames.Page, 1));
        }

        protected abstract void InjectModelDependencies(TEditableModel editableModel);

        protected abstract Func<TEditableModel> GetInitialEditableModelInstance { get; }

        protected abstract Func<TEntity> GetEntityById(long id);

        protected abstract Func<TEntity> LoadEntityById(long id);

        protected abstract Func<IQueryable<TEntity>> GetAllEntities { get; }

        protected abstract Func<ServiceOperationResult> InsertEntityAndReturnOperationResult(TEntity entity);

        protected abstract Func<ServiceOperationResult> UpdateEntityAndReturnOperationResult(TEntity entity);

        protected abstract Func<ServiceOperationResult> DeleteEntityAndReturnOperationResult(TEntity entity, bool onlyChangeFlag = true);
    }
}
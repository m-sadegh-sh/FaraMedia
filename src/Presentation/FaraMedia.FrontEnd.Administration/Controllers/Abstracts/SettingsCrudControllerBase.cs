namespace FaraMedia.FrontEnd.Administration.Controllers.Abstracts {
    using System;
    using System.Web.Mvc;

    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.FrontEnd.Administration.Infrastructure;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Controllers;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Mvc.Models.Configuration;

    public abstract class SettingsCrudControllerBase<TSettings, TEditableSettingsModel> :UserizedAreaControllerBase
        where TSettings : class, ISettings, new()
        where TEditableSettingsModel : EditableSettingsModelBase
    {
        [HttpGet]
        public ActionResult Save() {
            if (!IsUserizedRequest)
                return AccessDeniedView();

            var settings = GetSettings()();

            var editableSettingsModel = settings.ToEditableSettingsModel<TSettings, TEditableSettingsModel>();

            InjectModelDependencies(editableSettingsModel);

            return View(editableSettingsModel);
        }

        [HttpPost]
        [FormValueExists("save", "save-continue", "continueEditing")]
        public ActionResult Save(TEditableSettingsModel editableSettingsModel, bool continueEditing) {
            if (!IsUserizedRequest)
                return AccessDeniedView();

            if (!ModelState.IsValid) {
                InjectModelDependencies(editableSettingsModel);

                return View(editableSettingsModel);
            }

            var settings = GetSettings()();

            settings = editableSettingsModel.ToSettings(settings);

            var operationResult = SaveSettingsAndReturnOperationResult(settings)();

            if (!operationResult.Success) {
                ModelState.InjectMessages(operationResult);
                ResourceErrorNotification(CommonConstants.Systematic.NotSaved);

                InjectModelDependencies(editableSettingsModel);

                return View(editableSettingsModel);
            }

            ResourceSuccessNotification(CommonConstants.Systematic.Saved);

            if (continueEditing)
                return RedirectToAction(KnownActionNames.Save);

            return RedirectToRoute(SettingsSectionConstants.RouteName);
        }

        protected abstract void InjectModelDependencies(TEditableSettingsModel editableSettingsModel);

        protected abstract Func<TSettings> GetSettings();

        protected abstract Func<ServiceOperationResult> SaveSettingsAndReturnOperationResult(TSettings settings);
    }
}
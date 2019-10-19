namespace FaraMedia.FrontEnd.Administration.Infrastructure {
    using AutoMapper;

    using FaraMedia.Core.Domain.Common;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Web.Framework.Mvc.Models;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;
    using FaraMedia.Web.Framework.Mvc.Models.Configuration;

    public static class MappingExtensions {
        public static TModel ToModel<TEntity, TModel>(this TEntity entity) where TEntity : EntityBase where TModel : EntityModelBase {
            return Mapper.Map<TEntity, TModel>(entity);
        }

        public static TEditableModel ToEditableModel<TEntity, TEditableModel>(this TEntity entity) where TEntity : EntityBase where TEditableModel : EditableEntityModelBase {
            return Mapper.Map<TEntity, TEditableModel>(entity);
        }

        public static TEntity ToEntity<TEditableModel, TEntity>(this TEditableModel editableModel) where TEditableModel : EditableEntityModelBase where TEntity : EntityBase {
            return Mapper.Map<TEditableModel, TEntity>(editableModel);
        }

        public static TEntity ToEntity<TEditableModel, TEntity>(this TEditableModel editableModel, TEntity entity) where TEditableModel : EditableEntityModelBase where TEntity : EntityBase {
            return Mapper.Map(editableModel, entity);
        }

        public static TEditableSettingsModel ToEditableSettingsModel<TSettings, TEditableSettingsModel>(this TSettings settings) where TSettings : class, ISettings where TEditableSettingsModel : EditableSettingsModelBase {
            return Mapper.Map<TSettings, TEditableSettingsModel>(settings);
        }

        public static TSettings ToSettings<TEditableSettingsModel, TSettings>(this TEditableSettingsModel editableSettingsModel) where TEditableSettingsModel : EditableSettingsModelBase where TSettings : class, ISettings {
            return Mapper.Map<TEditableSettingsModel, TSettings>(editableSettingsModel);
        }

        public static TSettings ToSettings<TEditableSettingsModel, TSettings>(this TEditableSettingsModel editableSettingsModel, TSettings settings) where TEditableSettingsModel : EditableSettingsModelBase where TSettings : class, ISettings {
            return Mapper.Map(editableSettingsModel, settings);
        }
    }
}
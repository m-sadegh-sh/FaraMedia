namespace FaraMedia.Services {
    using System;
    using System.Linq;

    using FaraMedia.Core;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas;
    using FaraMedia.Services.Extensions.Configuration;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.Querying.Configuration;

    using TB.ComponentModel;

	public sealed class DbSettingsService<TSettings> : IDbSettingsService<TSettings> where TSettings : class, ISettings, new() {
        private TSettings _cachedSettings;

        private readonly ValidationProvider<TSettings> _validationProvider;
        private readonly IDbService<Setting, SettingQuery> _settingService;

        protected DbSettingsService(ValidationProvider<TSettings> validationProvider, IDbService<Setting, SettingQuery> settingService) {
            _validationProvider = validationProvider;
            _settingService = settingService;
        }

        public TSettings Get() {
            if (_cachedSettings == null)
                _cachedSettings = ReloadSettings();

            return _cachedSettings;
        }

        public ServiceOperationResult Save(TSettings settings) {
            var result = EngineContext.Current.Resolve<ServiceOperationResult>();

            if (settings == null) {
                result.AddResourceError(CommonConstants.Messages.NullEntity);
                return result;
            }

            if (!_validationProvider.Validate(settings, result))
                return result;

            try {
                var properties = from pi in typeof (TSettings).GetProperties()
                                 where pi.CanWrite && pi.CanRead
                                 where CommonHelper.GetCustomTypeConverter(pi.PropertyType).CanConvertFrom(typeof (string))
                                 select pi;

                foreach (var property in properties) {
                    var key = string.Concat(typeof (TSettings).Name, ".", property.Name);
                    var value = property.GetValue(settings, null) ?? "";

                    result.CopyFrom(_settingService.Save(key, value));
                }
            } catch {
                return result;
            }

            _cachedSettings = settings;

            return result;
        }

        private TSettings ReloadSettings() {
            var settings = Activator.CreateInstance<TSettings>();

            var properties = from pi in typeof (TSettings).GetProperties()
                             where pi.CanWrite && pi.CanRead
                             let key = string.Concat(typeof (TSettings).Name, ".", pi.Name)
                             let setting = _settingService.GetValueByKey<string>(key)
                             where setting != null
                             where setting.CT.CanConvertTo(pi.PropertyType)
                             let value = CommonHelper.GetCustomTypeConverter(pi.PropertyType).ConvertFromInvariantString(setting)
                             select new {
                                 PropertyInfo = pi,
                                 Value = value
                             };

            properties.ToList().ForEach(p => p.PropertyInfo.SetValue(settings, p.Value, null));

            return settings;
        }
    }
}
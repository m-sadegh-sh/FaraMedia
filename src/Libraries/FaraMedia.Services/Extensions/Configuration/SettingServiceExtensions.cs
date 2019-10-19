namespace FaraMedia.Services.Extensions.Configuration {
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Configuration;
	using FaraMedia.Core.Infrastructure;
	using FaraMedia.Data.Schemas.Shared;
	using FaraMedia.Services.Querying.Configuration;

	using TB.ComponentModel;

	public static class SettingServiceExtensions {
		public static T GetById<T>(this IDbService<Setting, SettingQuery> service,
		                           long id,
		                           T fallbackValue = default(T)) {
			if (Neutrals.Is(id))
				return fallbackValue;

			var setting = service.GetById(id);

			if (setting == null)
				return fallbackValue;

			if (!setting.Value.CanConvertTo<T>())
				return fallbackValue;

			var convertedValue = setting.Value.ConvertTo<T>();

			return convertedValue;
		}

		public static Setting GetByKey(this IDbService<Setting, SettingQuery> service,
		                               string key) {
			if (Neutrals.Is(key))
				return null;

			var setting = service.Get(sq => sq.WithKey(key));

			return setting;
		}

		public static T GetValueByKey<T>(this IDbService<Setting, SettingQuery> service,
		                                 string key,
		                                 T fallbackValue = default(T)) {
			if (Neutrals.Is(key))
				return fallbackValue;

			var setting = service.GetByKey(key);

			if (setting == null)
				return fallbackValue;

			if (!setting.Value.CanConvertTo<T>())
				return fallbackValue;

			var convertedValue = setting.Value.ConvertTo<T>();

			return convertedValue;
		}

		public static ServiceOperationResultWithValue<Setting> Save<T>(this IDbService<Setting, SettingQuery> service,
		                                                               string key,
		                                                               T value) {
			var result = EngineContext.Current.Resolve<ServiceOperationResultWithValue<Setting>>();

			if (!value.CanConvertTo<string>()) {
				result.AddResourceError(EntityAttributeConstants.Messages.NotSupportedValueType);
				return result;
			}

			var convertedValue = value.ConvertTo<string>();

			var setting = service.GetByKey(key);

			if (setting != null) {
				setting.Value = convertedValue;

				result.CopyFrom(service.Save(setting));
			} else {
				setting = new Setting {
						Key = key,
						Value = convertedValue,
				};

				result.CopyFrom(service.Save(setting));
			}

			return result.With(setting);
		}
	}
}
namespace FaraMedia.Services.Extensions.Systematic {
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Configuration;
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Core.Infrastructure;
	using FaraMedia.Services.Querying.Systematic;

	public static class ResourceValueServiceExtensions {
		public static ResourceValue GetByKey(this IDbService<ResourceValue, ResourceValueQuery> service,
		                                     string key,
		                                     bool logIfNotFound = true) {
			if (Neutrals.Is(key))
				return null;

			var workContext = EngineContext.Current.Resolve<IWorkContext>();

			var languageId = workContext.WorkingLanguage.Id;

			return service.GetByLanguageIdAndKey(languageId,
			                                     key,
			                                     logIfNotFound);
		}

		public static ResourceValue GetByLanguageIdAndKey(this IDbService<ResourceValue, ResourceValueQuery> service,
		                                                  long languageId,
		                                                  string key,
		                                                  bool logIfNotFound = true) {
			if (Neutrals.Is(languageId))
				return null;

			if (Neutrals.Is(key))
				return null;

			ResourceValue resourceValue;

			var settings = EngineContext.Current.Resolve<SystemSettings>();

			if (settings.LoadAllLocaleRecordsOnStartup) {
				var resourceValues = service.GetAll();

				resourceValue = resourceValues.FirstOrDefault(rv => rv.Key.Key == key);
			} else {
				resourceValue = service.Get(rvq => rvq.WithLanguageId(languageId).
				                                       WithKeyKey(key));
			}

			if (resourceValue == null && logIfNotFound) {
				var logService = EngineContext.Current.Resolve<IDbService<Log, LogQuery>>();

				logService.Warning(string.Format("[ResourceValue] with key ({0}) wasn't found.",
				                                 key));
			}

			return resourceValue;
		}

		public static string GetValueByKey(this IDbService<ResourceValue, ResourceValueQuery> service,
		                                   string key,
		                                   bool logIfNotFound = true,
		                                   string defaultValue = "",
		                                   bool returnEmptyIfNotFound = false) {
			if (Neutrals.Is(key))
				return null;

			var workContext = EngineContext.Current.Resolve<IWorkContext>();

			var languageId = workContext.WorkingLanguage.Id;

			return service.GetValueByLanguageIdAndKey(languageId,
			                                          key,
			                                          logIfNotFound,
			                                          defaultValue,
			                                          returnEmptyIfNotFound);
		}

		public static string GetValueByLanguageIdAndKey(this IDbService<ResourceValue, ResourceValueQuery> service,
		                                                long languageId,
		                                                string key,
		                                                bool logIfNotFound = true,
		                                                string defaultValue = "",
		                                                bool returnEmptyIfNotFound = false) {
			if (Neutrals.Is(languageId))
				return null;

			if (Neutrals.Is(key))
				return null;

			var value = string.Empty;

			var resourceValue = service.GetByLanguageIdAndKey(languageId,
			                                                  key,
			                                                  logIfNotFound);

			if (resourceValue != null)
				value = resourceValue.Value;

			if (string.IsNullOrEmpty(value)) {
				if (!string.IsNullOrEmpty(defaultValue))
					value = defaultValue;
				else {
					if (!returnEmptyIfNotFound)
						value = key;
				}
			}

			return value;
		}

		public static ResourceValue GetByLanguageCultureCodeAndKey(this IDbService<ResourceValue, ResourceValueQuery> service,
		                                                           string cultureCode,
		                                                           string key,
		                                                           bool logIfNotFound = true) {
			if (Neutrals.Is(cultureCode))
				return null;

			if (Neutrals.Is(key))
				return null;

			ResourceValue resourceValue;

			var settings = EngineContext.Current.Resolve<SystemSettings>();

			if (settings.LoadAllLocaleRecordsOnStartup) {
				var resourceValues = service.GetAll();

				resourceValue = resourceValues.FirstOrDefault(rv => rv.Key.Key == key);
			} else {
				resourceValue = service.Get(rvq => rvq.WithLanguageCultureCode(cultureCode).
				                                       WithKeyKey(key));
			}

			if (resourceValue == null && logIfNotFound) {
				var logService = EngineContext.Current.Resolve<IDbService<Log, LogQuery>>();

				logService.Warning(string.Format("[ResourceValue] with key ({0}) wasn't found.",
				                                 key));
			}

			return resourceValue;
		}

		public static string GetValueByLanguageCultureCodeAndKey(this IDbService<ResourceValue, ResourceValueQuery> service,
		                                                         string cultureCode,
		                                                         string key,
		                                                         bool logIfNotFound = true,
		                                                         string defaultValue = "",
		                                                         bool returnEmptyIfNotFound = false) {
			if (Neutrals.Is(cultureCode))
				return null;

			if (Neutrals.Is(key))
				return null;

			var value = string.Empty;

			var resourceValue = service.GetByLanguageCultureCodeAndKey(cultureCode,
			                                                           key,
			                                                           logIfNotFound);

			if (resourceValue != null)
				value = resourceValue.Value;

			if (string.IsNullOrEmpty(value)) {
				if (!string.IsNullOrEmpty(defaultValue))
					value = defaultValue;
				else {
					if (!returnEmptyIfNotFound)
						value = key;
				}
			}

			return value;
		}
	}
}
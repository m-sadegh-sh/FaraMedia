namespace FaraMedia.Services.Installation.Abstraction {
    using FaraMedia.Core;
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Core.States;
    using FaraMedia.Data.Schemas;
    using FaraMedia.Services.Extensions.Systematic;
    using FaraMedia.Services.Querying.Systematic;

    public class ValidationMessageFormatter {
        public static string RequiredName(string propertyName) {
            return WithKey(CommonConstants.FormattableMessages.Required, propertyName);
        }

        public static string RequiredKey(string propertyKey) {
            return WithKey(CommonConstants.FormattableMessages.Required, WithKey(propertyKey));
        }

        public static string InvalidLengthName(string propertyName, int length) {
            return WithKey(CommonConstants.FormattableMessages.InvalidLength, propertyName, length);
        }

        public static string InvalidLengthKey(string propertyKey, int length) {
            return WithKey(CommonConstants.FormattableMessages.InvalidLength, WithKey(propertyKey), length);
        }

        public static string InvalidFormatName(string propertyName) {
            return WithKey(CommonConstants.FormattableMessages.InvalidFormat, propertyName);
        }

        public static string InvalidFormatKey(string propertyKey) {
            return WithKey(CommonConstants.FormattableMessages.InvalidFormat, WithKey(propertyKey));
        }

        public static string InvalidValueName(string propertyName) {
            return WithKey(CommonConstants.FormattableMessages.InvalidValue, propertyName);
        }

        public static string InvalidValueKey(string propertyKey) {
            return WithKey(CommonConstants.FormattableMessages.InvalidValue, WithKey(propertyKey));
        }

        public static string InvalidMinValueName(string propertyName, int minValue) {
            return WithKey(CommonConstants.FormattableMessages.InvalidMinValue, propertyName, minValue);
        }

        public static string InvalidMinValueKey(string propertyKey, int minValue) {
            return WithKey(CommonConstants.FormattableMessages.InvalidMinValue, WithKey(propertyKey), minValue);
        }

        public static string InvalidMaxValueName(string propertyName, int maxValue) {
            return WithKey(CommonConstants.FormattableMessages.InvalidMaxValue, propertyName, maxValue);
        }

        public static string InvalidMaxValueKey(string propertyKey, int maxValue) {
            return WithKey(CommonConstants.FormattableMessages.InvalidMaxValue, WithKey(propertyKey), maxValue);
        }

        public static string OutOfRangeValueName(string propertyName, int minValue, int maxValue) {
            return WithKey(CommonConstants.FormattableMessages.OutOfRangeValue, propertyName, minValue, maxValue);
        }

        public static string OutOfRangeValueKey(string propertyKey, int minValue, int maxValue) {
            return WithKey(CommonConstants.FormattableMessages.OutOfRangeValue, WithKey(propertyKey), minValue, maxValue);
        }

        public static string DuplicateValueName(string propertyName) {
            return WithKey(CommonConstants.FormattableMessages.DuplicateValue, propertyName);
        }

        public static string DuplicateValueKey(string propertyKey) {
            return WithKey(CommonConstants.FormattableMessages.DuplicateValue, WithKey(propertyKey));
        }

        public static string WithKey(string key, params object[] args) {
            var dbConfigurationState = EngineContext.Current.Resolve<DbConfigurationState>();
            if (!dbConfigurationState.IsDbSynced)
                return key;

            var workContext = EngineContext.Current.Resolve<IWorkContext>();
            var localizationService = EngineContext.Current.Resolve<IDbService<ResourceValue, ResourceValueQuery>>();

            var languageId = workContext.WorkingLanguage.Id;
            var value = localizationService.GetValueByLanguageIdAndKey(languageId, key, true, key);

            if (args != null && args.Length > 0)
                value = string.Format(value, args);

            return value;
        }
    }
}
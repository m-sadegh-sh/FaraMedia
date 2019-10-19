namespace FaraMedia.Services.Validations.Extensions {
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate.Validator.Cfg.Loquacious;

    public static class RuleArgsOptionsExtensions {
        public static void WithRequired(this IRuleArgsOptions ruleArgsOptions, string labelKey) {
            var message = ValidationMessageFormatter.RequiredKey(labelKey);

            ruleArgsOptions.WithMessage(message);
        }

        public static void WithInvalidValue(this IRuleArgsOptions ruleArgsOptions, string labelKey) {
            var message = ValidationMessageFormatter.InvalidValueKey(labelKey);

            ruleArgsOptions.WithMessage(message);
        }

        public static void WithInvalidMinValue(this IRuleArgsOptions ruleArgsOptions, string labelKey, int minValue) {
            var message = ValidationMessageFormatter.InvalidMinValueKey(labelKey, minValue);

            ruleArgsOptions.WithMessage(message);
        }

        public static void WithInvalidMaxValue(this IRuleArgsOptions ruleArgsOptions, string labelKey, int maxValue) {
            var message = ValidationMessageFormatter.InvalidMaxValueKey(labelKey, maxValue);

            ruleArgsOptions.WithMessage(message);
        }

        public static void WithInvalidRange(this IRuleArgsOptions ruleArgsOptions, string labelKey, int minValue, int maxValue) {
            var message = ValidationMessageFormatter.OutOfRangeValueKey(labelKey, minValue, maxValue);

            ruleArgsOptions.WithMessage(message);
        }

        public static void WithInvalidFormat(this IRuleArgsOptions ruleArgsOptions, string labelKey) {
            var message = ValidationMessageFormatter.InvalidFormatKey(labelKey);

            ruleArgsOptions.WithMessage(message);
        }

        public static void WithLocalized(this IRuleArgsOptions ruleArgsOptions, string key) {
            var message = ValidationMessageFormatter.WithKey(key);

            ruleArgsOptions.WithMessage(message);
        }
    }
}
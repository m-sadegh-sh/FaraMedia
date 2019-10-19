namespace FaraMedia.Services.Validations.Extensions {
    using FaraMedia.Core;
    using FaraMedia.Core.Sanitization;

    using NHibernate.Validator.Cfg.Loquacious;

    public static class StringConstraintsExtensions {
        public static IChainableConstraint<IStringConstraints> MaxLength(this IStringConstraints stringConstraints) {
            return stringConstraints.MaxLength(4000);
        }

        public static IChainableConstraint<IStringConstraints> IsIp(this IStringConstraints stringConstraints, bool ignoreEmpty = true) {
            return stringConstraints.Satisfy(v => (ignoreEmpty && string.IsNullOrEmpty(v)) || CommonHelper.IsValidIp(v));
        }

        public static IChainableConstraint<IStringConstraints> IsUrl(this IStringConstraints stringConstraints, bool ignoreEmpty = true) {
            return stringConstraints.Satisfy(v => (ignoreEmpty && string.IsNullOrEmpty(v)) || CommonHelper.IsValidUrl(v));
        }

        public static IChainableConstraint<IStringConstraints> IsPath(this IStringConstraints stringConstraints, bool ignoreEmpty = true) {
            return stringConstraints.Satisfy(v => (ignoreEmpty && string.IsNullOrEmpty(v)) || CommonHelper.IsValidPath(v));
        }

        public static IChainableConstraint<IStringConstraints> IsDateTimeZoneId(this IStringConstraints stringConstraints, bool ignoreEmpty = true) {
            return stringConstraints.Satisfy(v => (ignoreEmpty && string.IsNullOrEmpty(v)) || CommonHelper.IsValidTimeZoneId(v));
        }

        public static IChainableConstraint<IStringConstraints> IsSlug(this IStringConstraints stringConstraints, bool ignoreEmpty = true) {
            return stringConstraints.Satisfy(v => (ignoreEmpty && string.IsNullOrEmpty(v)) || Sanitizer.IsSlug(v));
        }
    }
}
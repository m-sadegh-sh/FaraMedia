namespace FaraMedia.Services.Validations.Extensions {
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate.Validator.Cfg.Loquacious;

    public static class ChainableConstraintExtensions {
        public static IChainableConstraint<TConstraints> WithRequired<TConstraints>(this IChainableConstraint<TConstraints> chainableConstraint, string labelKey) where TConstraints : class {
            var message = ValidationMessageFormatter.RequiredKey(labelKey);

            return chainableConstraint.WithMessage(message);
        }

        public static IChainableConstraint<TConstraints> WithInvalidLength<TConstraints>(this IChainableConstraint<TConstraints> chainableConstraint, string labelKey, int length) where TConstraints : class {
            var message = ValidationMessageFormatter.InvalidLengthKey(labelKey, length);

            return chainableConstraint.WithMessage(message);
        }

        public static IChainableConstraint<TConstraints> WithInvalidFormat<TConstraints>(this IChainableConstraint<TConstraints> chainableConstraint, string labelKey) where TConstraints : class {
            var message = ValidationMessageFormatter.InvalidFormatKey(labelKey);

            return chainableConstraint.WithMessage(message);
        }

        public static IChainableConstraint<TConstraints> WithLocalized<TConstraints>(this IChainableConstraint<TConstraints> chainableConstraint, string labelKey) where TConstraints : class {
            var message = ValidationMessageFormatter.WithKey(labelKey);

            return chainableConstraint.WithMessage(message);
        }
    }
}
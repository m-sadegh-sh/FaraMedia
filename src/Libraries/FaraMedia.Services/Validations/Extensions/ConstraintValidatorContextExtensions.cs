namespace FaraMedia.Services.Validations.Extensions {
    using System;
    using System.Linq.Expressions;

    using FaraMedia.Services.Installation.Abstraction;
    
    using NHibernate.Validator.Engine;

    public static class ConstraintValidatorContextExtensions {
        public static void AddLocalizedInvalid(this IConstraintValidatorContext constraintValidatorContext, string key) {
            var message = ValidationMessageFormatter.WithKey(key);

            constraintValidatorContext.AddInvalid(message);
        }

        public static void AddLocalizedInvalid<TEntity, TProperty>(this IConstraintValidatorContext constraintValidatorContext, string key, Expression<Func<TEntity, TProperty>> property) {
            var message = ValidationMessageFormatter.WithKey(key);

            constraintValidatorContext.AddInvalid(message, property);
        }

        public static void AddRequired<TEntity, TProperty>(this IConstraintValidatorContext constraintValidatorContext, string key, Expression<Func<TEntity, TProperty>> property) {
            var message = ValidationMessageFormatter.RequiredKey(key);

            constraintValidatorContext.AddInvalid(message, property);
        }

        public static void AddInvalidValue<TEntity, TProperty>(this IConstraintValidatorContext constraintValidatorContext, string key, Expression<Func<TEntity, TProperty>> property) {
            var message = ValidationMessageFormatter.InvalidValueKey(key);

            constraintValidatorContext.AddInvalid(message, property);
        }

        public static void AddInvalidLength<TEntity, TProperty>(this IConstraintValidatorContext constraintValidatorContext, string key, int length, Expression<Func<TEntity, TProperty>> property) {
            var message = ValidationMessageFormatter.InvalidLengthKey(key, length);

            constraintValidatorContext.AddInvalid(message, property);
        }

        public static void AddInvalidFormat<TEntity, TProperty>(this IConstraintValidatorContext constraintValidatorContext, string key, Expression<Func<TEntity, TProperty>> property) {
            var message = ValidationMessageFormatter.InvalidFormatKey(key);

            constraintValidatorContext.AddInvalid(message, property);
        }

        public static void AddDuplicate<TEntity, TProperty>(this IConstraintValidatorContext constraintValidatorContext, string key, Expression<Func<TEntity, TProperty>> property) {
            var message = ValidationMessageFormatter.DuplicateValueKey(key);

            constraintValidatorContext.AddInvalid(message, property);
        }

        public static void AddLocalizedInvalid(this IConstraintValidatorContext constraintValidatorContext, string key, string property) {
            var message = ValidationMessageFormatter.WithKey(key);

            constraintValidatorContext.AddInvalid(message, property);
        }
    }
}
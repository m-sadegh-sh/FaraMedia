namespace FaraMedia.Services.Validations.Extensions {
    using System;

    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Core.States;

    using NHibernate.Validator.Cfg.Loquacious;
    using NHibernate.Validator.Engine;

    public static class InstanceConstraintsExtensions {
        public static IChainableConstraint<IInstanceConstraints<TEntity>> SafeBy<TEntity>(this IInstanceConstraints<TEntity> constraint, Func<TEntity, IConstraintValidatorContext, bool> isValidDelegate) where TEntity : class {
            var dbConfigurationState = EngineContext.Current.Resolve<DbConfigurationState>();

            if (!dbConfigurationState.IsDbSynced)
                isValidDelegate = (entity, context) => true;

            return constraint.By(isValidDelegate);
        }
    }
}
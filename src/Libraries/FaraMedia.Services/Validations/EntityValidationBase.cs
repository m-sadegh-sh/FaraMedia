namespace FaraMedia.Services.Validations {
    using FaraMedia.Core.Domain;

    using NHibernate.Validator.Cfg.Loquacious;

    public abstract class EntityValidationBase<T> : ValidationDef<T> where T : EntityBase {}
}
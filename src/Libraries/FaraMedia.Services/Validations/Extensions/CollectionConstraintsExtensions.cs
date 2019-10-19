namespace FaraMedia.Services.Validations.Extensions {
    using NHibernate.Validator.Cfg.Loquacious;

    public static class CollectionConstraintsExtensions {
        public static IRuleArgsOptions MaxSize(this ICollectionConstraints collectionConstraints) {
            return collectionConstraints.MaxSize(4000);
        }
    }
}
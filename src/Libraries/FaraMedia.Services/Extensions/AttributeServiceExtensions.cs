namespace FaraMedia.Services.Extensions {
	using FaraMedia.Core;
	using FaraMedia.Core.Domain;
	using FaraMedia.Services.Querying;

	public static class AttributeServiceExtensions {
		public static TEntity GetBySystemName<TEntity, TQuery>(this IDbService<TEntity, TQuery> service,
		                                                       string systemName) where TEntity : AttributeBase where TQuery : AttributeQueryBase<TEntity, TQuery> {
			if (Neutrals.Is(systemName))
				return null;

			var attribute = service.Get(aq => aq.WithSystemName(systemName));

			return attribute;
		}
	}
}
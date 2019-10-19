namespace FaraMedia.Data.Mapping {
	using FaraMedia.Core.Domain;
	using FaraMedia.Data.NHibernating.Conventions;

	using NHibernate.Mapping.ByCode;

	public abstract class EntityMapBase<TEntity> : MapBase<TEntity> where TEntity : class, IEntity {
		protected EntityMapBase() {
			Id(e => e.Id,
			   im => im.Generator(Generators.Identity,
			                      gm => gm.Params(new {
					                      seed = IdentityBuilder.DefaultSeed()
			                      })));
		}
	}
}
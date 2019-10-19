namespace FaraMedia.Data.Schemas {
	using FaraMedia.Core.Domain;

	public abstract class EntityConstantsBase<TEntity> : ConstantsBase<TEntity> where TEntity : EntityBase {
		public abstract class Fields {
			public sealed class Id {
				public static readonly string Label = Helpers.Label<Id>();
			}
		}
	}
}
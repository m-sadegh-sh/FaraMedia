namespace FaraMedia.Data.Schemas {
	using FaraMedia.Core.Domain;

	public abstract class UIElementConstantsBase<TEntity> : UserContentConstantsBase<TEntity> where TEntity : UIElementBase {
		public new abstract class Fields : UserContentConstantsBase<TEntity>.Fields {
			public sealed class DisplayOrder {
				public static readonly string Label = Helpers.Label<DisplayOrder>();
			}

			public sealed class Owner {
				public static readonly string Label = Helpers.Label<Owner>();
			}

			public sealed class Metadata {
				public static readonly string Label = Helpers.Label<Metadata>();
			}

			public sealed class DeletionHistory {
				public static readonly string Label = Helpers.Label<DeletionHistory>();
			}
		}
	}
}
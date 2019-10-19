namespace FaraMedia.Data.Schemas {
	using FaraMedia.Core.Domain;

	public abstract class UserContentConstantsBase<TEntity> : EntityConstantsBase<TEntity> where TEntity : UserContentBase {
		public new abstract class Fields : EntityConstantsBase<TEntity>.Fields {
			public sealed class CreationHistory {
				public static readonly string Label = Helpers.Label<CreationHistory>();
			}

			public sealed class ModificationHistory {
				public static readonly string Label = Helpers.Label<ModificationHistory>();
			}
		}
	}
}
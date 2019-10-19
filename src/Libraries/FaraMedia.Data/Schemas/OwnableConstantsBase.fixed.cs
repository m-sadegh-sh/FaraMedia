namespace FaraMedia.Data.Schemas {
	using FaraMedia.Core.Domain;

	public abstract class OwnableConstantsBase<TEntity> : EntityConstantsBase<TEntity> where TEntity : OwnableBase {
		public new abstract class Fields : EntityConstantsBase<TEntity>.Fields {
			public sealed class OwnerId {
				public const int MinValue = Constants.PositiveDigits;

				public static readonly string Label = Helpers.Label<OwnerId>();
			}
		}
	}
}
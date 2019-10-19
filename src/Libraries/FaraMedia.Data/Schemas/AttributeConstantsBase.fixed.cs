namespace FaraMedia.Data.Schemas {
	using FaraMedia.Core.Domain;

	public abstract class AttributeConstantsBase<TEntity> : EntityConstantsBase<TEntity> where TEntity : AttributeBase {
		public new abstract class Fields : EntityConstantsBase<TEntity>.Fields {
			public sealed class SystemName {
				public const int Length = Constants.SystemNameLength;

				public static readonly string Label = Helpers.Label<SystemName>();
			}

			public sealed class DisplayName {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<DisplayName>();
			}

			public sealed class Description {
				public static readonly string Label = Helpers.Label<Description>();
			}
		}
	}
}
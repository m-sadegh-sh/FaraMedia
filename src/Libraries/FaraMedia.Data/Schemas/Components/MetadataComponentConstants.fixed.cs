namespace FaraMedia.Data.Schemas.Components {
	using FaraMedia.Core.Domain.Components;

	public sealed class MetadataComponentConstants : ConstantsBase<MetadataComponent> {
		public sealed class Fields {
			public sealed class Title {
				public const int Length = 200;

				public static readonly string Label = Helpers.Label<Title>();
			}

			public sealed class Slug {
				public const int Length = 200;

				public static readonly string Label = Helpers.Label<Slug>();
			}

			public sealed class Keywords {
				public const int Length = 500;

				public static readonly string Label = Helpers.Label<Keywords>();
			}

			public sealed class Description {
				public const int Length = 1000;

				public static readonly string Label = Helpers.Label<Description>();
			}
		}
	}
}
namespace FaraMedia.Data.Schemas.ContentManagement {
	using FaraMedia.Core.Domain.ContentManagement;

	public sealed class NewsConstants : UIElementConstantsBase<News> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(n => n.Id);
		}

		public new sealed class Fields : UIElementConstantsBase<News>.Fields {
			public sealed class Title {
				public const int Length = 200;

				public static readonly string Label = Helpers.Label<Title>();
			}

			public sealed class Short {
				public const int Length = 500;

				public static readonly string Label = Helpers.Label<Short>();
			}

			public sealed class Full {
				public static readonly string Label = Helpers.Label<Full>();
			}

			public sealed class Category {
				public static readonly string Label = Helpers.Label<Category>();
			}
		}
	}
}
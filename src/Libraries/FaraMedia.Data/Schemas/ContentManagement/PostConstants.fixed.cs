namespace FaraMedia.Data.Schemas.ContentManagement {
	using FaraMedia.Core.Domain.ContentManagement;

	public sealed class PostConstants : UIElementConstantsBase<Post> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(p => p.Id);
		}

		public new sealed class Fields : UIElementConstantsBase<Post>.Fields {
			public sealed class Title {
				public const int Length = 200;

				public static readonly string Label = Helpers.Label<Title>();
			}

			public sealed class Body {
				public static readonly string Label = Helpers.Label<Body>();
			}

			public sealed class Blog {
				public static readonly string Label = Helpers.Label<Blog>();
			}

			public sealed class Tags {
				public static readonly string Label = Helpers.Label<Tags>();
			}
		}
	}
}
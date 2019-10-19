namespace FaraMedia.Data.Schemas.ContentManagement {
	using FaraMedia.Core.Domain.ContentManagement;

	public sealed class BlogConstants : UIElementConstantsBase<Blog> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(b => b.Id);
		}

		public new sealed class Fields : UIElementConstantsBase<Blog>.Fields {
			public sealed class Title {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<Title>();
			}

			public sealed class Description {
				public static readonly string Label = Helpers.Label<Description>();
			}

			public sealed class Authors {
				public static readonly string Label = Helpers.Label<Authors>();
			}

			public sealed class Tags {
				public static readonly string Label = Helpers.Label<Tags>();
			}

			public sealed class Posts {
				public static readonly string Label = Helpers.Label<Posts>();
			}
		}
	}
}
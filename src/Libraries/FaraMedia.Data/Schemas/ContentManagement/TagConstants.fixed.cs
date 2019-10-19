namespace FaraMedia.Data.Schemas.ContentManagement {
	using FaraMedia.Core.Domain.ContentManagement;

	public sealed class TagConstants : EntityConstantsBase<Tag> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(t => t.Id);
			public static readonly string ByTitle = Helpers.CacheKey(t => t.Title);
		}

		public new sealed class Fields : EntityConstantsBase<Tag>.Fields {
			public sealed class Title {
				public const int Length = 50;

				public static readonly string Label = Helpers.Label<Title>();
			}

			public sealed class Description {
				public static readonly string Label = Helpers.Label<Description>();
			}

			public sealed class Metadata {
				public static readonly string Label = Helpers.Label<Metadata>();
			}

			public sealed class Blog {
				public static readonly string Label = Helpers.Label<Blog>();
			}

			public sealed class Posts {
				public static readonly string Label = Helpers.Label<Posts>();
			}
		}
	}
}
namespace FaraMedia.Data.Schemas.ContentManagement {
	using FaraMedia.Core.Domain.ContentManagement;

	public sealed class CategoryConstants : EntityConstantsBase<Category> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(c => c.Id);
		}

		public new sealed class Fields : EntityConstantsBase<Category>.Fields {
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

			public sealed class Parent {
				public static readonly string Label = Helpers.Label<Parent>();
			}

			public sealed class Children {
				public static readonly string Label = Helpers.Label<Children>();
			}

			public sealed class News {
				public static readonly string Label = Helpers.Label<News>();
			}
		}
	}
}
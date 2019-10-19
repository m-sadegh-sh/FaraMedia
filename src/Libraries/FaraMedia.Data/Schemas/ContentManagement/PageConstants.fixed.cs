namespace FaraMedia.Data.Schemas.ContentManagement {
	using FaraMedia.Core.Domain.ContentManagement;

	public sealed class PageConstants : UIElementConstantsBase<Page> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(p => p.Id);
		}

		public new sealed class Fields : UIElementConstantsBase<Page>.Fields {
			public class Title {
				public const int Length = 200;

				public static readonly string Label = Helpers.Label<Title>();
			}

			public sealed class Body {
				public static readonly string Label = Helpers.Label<Body>();
			}

			public sealed class Group {
				public static readonly string Label = Helpers.Label<Group>();
			}
		}
	}
}
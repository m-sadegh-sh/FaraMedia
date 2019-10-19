namespace FaraMedia.Data.Schemas.Shared {
	using FaraMedia.Core.Domain.Shared;

	public sealed class CommentConstants : UserContentConstantsBase<Comment> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(c => c.Id);
		}

		public new sealed class Fields : UserContentConstantsBase<Comment>.Fields {
			public sealed class OwnerId {
				public const int MinValue = Constants.PositiveDigits;

				public static readonly string Label = Helpers.Label<OwnerId>();
			}

			public sealed class Email {
				public const int Length = Constants.EmailLength;

				public static readonly string Label = Helpers.Label<Email>();
			}

			public sealed class Title {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<Title>();
			}

			public sealed class Body {
				public static readonly string Label = Helpers.Label<Body>();
			}

			public sealed class InReplyTo {
				public static readonly string Label = Helpers.Label<InReplyTo>();
			}

			public sealed class Replies {
				public static readonly string Label = Helpers.Label<Replies>();
			}
		}
	}
}
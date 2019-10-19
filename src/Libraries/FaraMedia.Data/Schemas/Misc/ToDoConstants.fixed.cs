namespace FaraMedia.Data.Schemas.Misc {
	using FaraMedia.Core.Domain.Misc;

	public sealed class ToDoConstants : EntityConstantsBase<ToDo> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(td => td.Id);
		}

		public new sealed class Fields : EntityConstantsBase<ToDo>.Fields {
			public sealed class Title {
				public const int Length = 200;

				public static readonly string Label = Helpers.Label<Title>();
			}

			public sealed class Description {
				public static readonly string Label = Helpers.Label<Description>();
			}

			public sealed class Performer {
				public static readonly string Label = Helpers.Label<Performer>();
			}

			public sealed class Status {
				public static readonly string Label = Helpers.Label<Status>();
			}

			public sealed class DueDateUtc {
				public static readonly string Label = Helpers.Label<DueDateUtc>();
			}
		}
	}
}
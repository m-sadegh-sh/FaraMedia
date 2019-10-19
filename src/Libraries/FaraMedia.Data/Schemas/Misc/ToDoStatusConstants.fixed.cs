namespace FaraMedia.Data.Schemas.Misc {
	using FaraMedia.Core.Domain.Misc;
	using FaraMedia.Data.Schemas.Shared;

	public sealed class ToDoStatusConstants : AttributeConstantsBase<ToDoStatus> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(tds => tds.Id);
		}

		public new sealed class Fields : AttributeConstantsBase<ToDoStatus>.Fields {
			public sealed class ToDos {
				public static readonly string Label = Helpers.Label<ToDos>();
			}
		}
	}
}
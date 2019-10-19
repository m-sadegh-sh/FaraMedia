namespace FaraMedia.Data.Schemas.Billing {
	using FaraMedia.Core.Domain.Billing;

	public sealed class OrderNoteConstants : EntityConstantsBase<OrderNote> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(on => on.Id);
		}

		public new sealed class Fields : EntityConstantsBase<OrderNote>.Fields {
			public sealed class Note {
				public static readonly string Label = Helpers.Label<Note>();
			}

			public sealed class IsPublic {
				public static readonly string Label = Helpers.Label<IsPublic>();
			}

			public sealed class Order {
				public static readonly string Label = Helpers.Label<Order>();
			}
		}
	}
}
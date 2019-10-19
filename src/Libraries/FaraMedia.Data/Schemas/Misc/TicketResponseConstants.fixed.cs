namespace FaraMedia.Data.Schemas.Misc {
	using FaraMedia.Core.Domain.Misc;

	public sealed class TicketResponseConstants : EntityConstantsBase<TicketResponse> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(tr => tr.Id);
		}

		public new sealed class Fields : EntityConstantsBase<TicketResponse>.Fields {
			public sealed class Responder {
				public static readonly string Label = Helpers.Label<Responder>();
			}

			public sealed class InResponseTo {
				public static readonly string Label = Helpers.Label<InResponseTo>();
			}

			public sealed class ResponseDateUtc {
				public static readonly string Label = Helpers.Label<ResponseDateUtc>();
			}

			public sealed class Subject {
				public const int Length = 200;

				public static readonly string Label = Helpers.Label<Subject>();
			}

			public sealed class Body {
				public static readonly string Label = Helpers.Label<Body>();
			}
		}
	}
}
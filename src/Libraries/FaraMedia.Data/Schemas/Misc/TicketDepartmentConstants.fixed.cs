namespace FaraMedia.Data.Schemas.Misc {
	using FaraMedia.Core.Domain.Misc;
	using FaraMedia.Data.Schemas.Shared;

	public sealed class TicketDepartmentConstants : AttributeConstantsBase<TicketDepartment> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(ts => ts.Id);
		}

		public new sealed class Fields : AttributeConstantsBase<TicketDepartment>.Fields {
			public sealed class Tickets {
				public static readonly string Label = Helpers.Label<Tickets>();
			}
		}
	}
}
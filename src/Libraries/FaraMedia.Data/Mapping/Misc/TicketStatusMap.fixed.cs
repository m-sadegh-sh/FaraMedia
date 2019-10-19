namespace FaraMedia.Data.Mapping.Misc {
	using FaraMedia.Core.Domain.Misc;
	using FaraMedia.Data.Mapping.Shared;

	public sealed class TicketStatusMap : AttributeMapBase<TicketStatus> {
		public TicketStatusMap() {
			Set(ts => ts.Tickets);
		}
	}
}
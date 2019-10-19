namespace FaraMedia.Data.Mapping.Misc {
	using FaraMedia.Core.Domain.Misc;
	using FaraMedia.Data.Mapping.Shared;

	public sealed class TicketDepartmentMap : AttributeMapBase<TicketDepartment> {
		public TicketDepartmentMap() {
			Set(td => td.Tickets);
		}
	}
}
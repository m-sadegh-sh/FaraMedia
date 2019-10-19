namespace FaraMedia.Data.Knowns.Misc {
	using FaraMedia.Data.Schemas;

	public sealed class TicketDepartmentNames : ConstantsBase {
		public static readonly string Support = Helpers.Key<TicketDepartmentNames, string>(tdn => Support);
		public static readonly string Sales = Helpers.Key<TicketDepartmentNames, string>(tdn => Sales);
	}
}
namespace FaraMedia.Data.Knowns.Misc {
	using FaraMedia.Data.Schemas;

	public sealed class TicketStatusNames : ConstantsBase {
		public static readonly string Open = Helpers.Key<TicketStatusNames, string>(tsn => Open);
		public static readonly string Closed = Helpers.Key<TicketStatusNames, string>(tsn => Closed);
	}
}
namespace FaraMedia.Data.Mapping.Misc {
	using FaraMedia.Core.Domain.Misc;

	public sealed class TicketResponseMap : EntityMapBase<TicketResponse> {
		public TicketResponseMap() {
			ManyToOne(tr => tr.Responder);
			ManyToOne(tr => tr.InResponseTo);
			Property(tr => tr.ResponseDateUtc);
			Property(tr => tr.Subject);
			Property(tr => tr.Body);
		}
	}
}
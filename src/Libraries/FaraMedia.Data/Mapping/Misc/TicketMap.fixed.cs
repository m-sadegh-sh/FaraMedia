namespace FaraMedia.Data.Mapping.Misc {
	using FaraMedia.Core.Domain.Misc;

	public sealed class TicketMap : EntityMapBase<Ticket> {
		public TicketMap() {
			ManyToOne(t => t.Opener);
			Property(t => t.OpenDateUtc);
			Property(t => t.Subject);
			Property(t => t.Body);
			ManyToOne(t => t.Department);
			Property(t => t.CheckPriority);
			ManyToOne(t => t.Status);
			Set(t => t.Responses);
		}
	}
}
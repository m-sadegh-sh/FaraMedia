namespace FaraMedia.Core.Domain.Misc {
	using System;

	using FaraMedia.Core.Domain.Security;

	public class TicketResponse : EntityBase {
		public virtual User Responder { get; set; }
		public virtual Ticket InResponseTo { get; set; }
		public virtual DateTime ResponseDateUtc { get; set; }
		public virtual string Subject { get; set; }
		public virtual string Body { get; set; }
	}
}
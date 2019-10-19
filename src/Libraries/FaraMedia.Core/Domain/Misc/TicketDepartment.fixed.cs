namespace FaraMedia.Core.Domain.Misc {
	using FaraMedia.Core.Domain.Shared;

	using Iesi.Collections.Generic;

	public class TicketDepartment : AttributeBase {
		private ISet<Ticket> _tickets;

		public virtual ISet<Ticket> Tickets {
			get { return _tickets ?? (_tickets = new HashedSet<Ticket>()); }
			protected set { _tickets = value; }
		}
	}
}
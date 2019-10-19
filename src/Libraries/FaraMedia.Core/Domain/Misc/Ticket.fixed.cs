namespace FaraMedia.Core.Domain.Misc {
	using System;

	using FaraMedia.Core.Domain.Security;

	using Iesi.Collections.Generic;

	public class Ticket : EntityBase {
		private ISet<TicketResponse> _responses;

		public virtual User Opener { get; set; }
		public virtual DateTime OpenDateUtc { get; set; }
		public virtual string Subject { get; set; }
		public virtual string Body { get; set; }
		public virtual TicketDepartment Department { get; set; }
		public virtual Priority CheckPriority { get; set; }
		public virtual TicketStatus Status { get; set; }

		public virtual ISet<TicketResponse> Responses {
			get { return _responses ?? (_responses = new HashedSet<TicketResponse>()); }
			protected set { _responses = value; }
		}
	}
}
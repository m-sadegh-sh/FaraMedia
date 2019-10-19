namespace FaraMedia.Core.Domain.Shared {
	using System;

	using FaraMedia.Core.Domain.Security;

	public class Share : OwnableBase {
		public virtual User Sharer { get; set; }
		public virtual DateTime ShareDateUtc { get; set; }
	}
}
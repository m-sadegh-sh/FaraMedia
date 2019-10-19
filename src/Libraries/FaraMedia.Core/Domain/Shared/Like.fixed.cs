namespace FaraMedia.Core.Domain.Shared {
	using System;

	using FaraMedia.Core.Domain.Security;

	public class Like : OwnableBase {
		public virtual User Liker { get; set; }
		public virtual DateTime LikeDateUtc { get; set; }
	}
}
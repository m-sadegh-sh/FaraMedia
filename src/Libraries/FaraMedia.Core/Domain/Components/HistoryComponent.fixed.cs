namespace FaraMedia.Core.Domain.Components {
	using System;

	using FaraMedia.Core.Domain.Security;

	public class HistoryComponent : IComponent {
		public virtual User Invoker { get; set; }
		public virtual string InvokerIp { get; set; }
		public virtual DateTime InvokeDateUtc { get; set; }
	}
}
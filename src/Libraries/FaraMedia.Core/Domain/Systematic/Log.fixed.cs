namespace FaraMedia.Core.Domain.Systematic {
	using System;

	using FaraMedia.Core.Domain.Security;

	public class Log : EntityBase {
		public virtual string ShortMessage { get; set; }
		public virtual string FullMessage { get; set; }
		public virtual string RequestedUrl { get; set; }
		public virtual string ReferrerUrl { get; set; }
		public virtual LogLevel Level { get; set; }
		public virtual DateTime LogDateUtc { get; set; }
		public virtual User Invoker { get; set; }
		public virtual string InvokerIp { get; set; }
	}
}
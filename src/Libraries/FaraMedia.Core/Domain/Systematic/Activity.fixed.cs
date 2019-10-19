namespace FaraMedia.Core.Domain.Systematic {
	using System;

	using FaraMedia.Core.Domain.Security;

	public class Activity : EntityBase {
		public virtual User Activator { get; set; }
		public virtual ActivityType Type { get; set; }
		public virtual string Comment { get; set; }
		public virtual DateTime ActivationDateUtc { get; set; }
	}
}
namespace FaraMedia.Core.Domain.Systematic {
	using System;

	public class NewsletterSubscription : EntityBase {
		public virtual string Email { get; set; }
		public virtual Guid Guid { get; set; }
	}
}
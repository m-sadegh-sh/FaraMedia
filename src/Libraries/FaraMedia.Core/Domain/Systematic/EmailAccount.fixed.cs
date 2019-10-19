namespace FaraMedia.Core.Domain.Systematic {
	using FaraMedia.Core.Domain.Shared;

	using Iesi.Collections.Generic;

	public class EmailAccount : AttributeBase {
		private ISet<MessageTemplate> _templates;
		private ISet<QueuedEmail> _emails;

		public virtual string Email { get; set; }
		public virtual string UserName { get; set; }
		public virtual string Password { get; set; }
		public virtual string Host { get; set; }
		public virtual int Port { get; set; }
		public virtual bool SslEnabled { get; set; }
		public virtual bool UseDefaultCredentials { get; set; }

		public virtual ISet<MessageTemplate> Templates {
			get { return _templates ?? (_templates = new HashedSet<MessageTemplate>()); }
			protected set { _templates = value; }
		}

		public virtual ISet<QueuedEmail> Emails {
			get { return _emails ?? (_emails = new HashedSet<QueuedEmail>()); }
			protected set { _emails = value; }
		}
	}
}
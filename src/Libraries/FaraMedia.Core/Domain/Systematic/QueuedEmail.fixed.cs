namespace FaraMedia.Core.Domain.Systematic {
	using System;
	using System.Collections.Generic;

	public class QueuedEmail : EntityBase {
		private IList<string> _cc;
		private IList<string> _bcc;

		public virtual string From { get; set; }
		public virtual string FromName { get; set; }
		public virtual string To { get; set; }
		public virtual string ToName { get; set; }

		public virtual IList<string> Cc {
			get { return _cc ?? (_cc = new List<string>()); }
			set { _cc = value; }
		}

		public virtual IList<string> Bcc {
			get { return _bcc ?? (_bcc = new List<string>()); }
			set { _bcc = value; }
		}

		public virtual string Subject { get; set; }
		public virtual string Body { get; set; }
		public virtual Priority SendPriority { get; set; }
		public virtual int SendingTries { get; set; }
		public virtual DateTime? SentDateUtc { get; set; }
		public virtual EmailAccount Account { get; set; }
	}
}
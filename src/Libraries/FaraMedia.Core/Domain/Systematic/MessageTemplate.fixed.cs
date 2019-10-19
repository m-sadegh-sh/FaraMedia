namespace FaraMedia.Core.Domain.Systematic {
	using System.Collections.Generic;

	public class MessageTemplate : AttributeBase {
		private IList<string> _bccEmailAddresses;

		public virtual IList<string> BccEmailAddresses {
			get { return _bccEmailAddresses ?? (_bccEmailAddresses = new List<string>()); }
			set { _bccEmailAddresses = value; }
		}

		public virtual string Subject { get; set; }
		public virtual string Body { get; set; }
		public virtual EmailAccount Account { get; set; }
	}
}
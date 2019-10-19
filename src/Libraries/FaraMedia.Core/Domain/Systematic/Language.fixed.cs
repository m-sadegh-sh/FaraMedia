namespace FaraMedia.Core.Domain.Systematic {
	using FaraMedia.Core.Domain.Shared;

	using Iesi.Collections.Generic;

	public class Language : AttributeBase {
		private ISet<ResourceValue> _values;

		public virtual string NativeName { get; set; }
		public virtual string CultureCode { get; set; }

		public virtual ISet<ResourceValue> Values {
			get { return _values ?? (_values = new HashedSet<ResourceValue>()); }
			set { _values = value; }
		}
	}
}
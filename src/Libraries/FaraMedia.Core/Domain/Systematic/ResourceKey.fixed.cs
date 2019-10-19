namespace FaraMedia.Core.Domain.Systematic {
	using Iesi.Collections.Generic;

	public class ResourceKey : EntityBase {
		private ISet<ResourceValue> _values;

		public virtual string Key { get; set; }
		public virtual string DisplayName { get; set; }
		public virtual string Description { get; set; }

		public virtual ISet<ResourceValue> Values {
			get { return _values ?? (_values = new HashedSet<ResourceValue>()); }
			set { _values = value; }
		}
	}
}
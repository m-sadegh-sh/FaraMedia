namespace FaraMedia.Core.Domain.ContentManagement {
	using Iesi.Collections.Generic;

	public class PollChoice : EntityBase {
		private ISet<PollChoiceItem> _items;

		public virtual string Title { get; set; }
		public virtual string Description { get; set; }
		public virtual bool IsMultiSelection { get; set; }
		public virtual Poll Poll { get; set; }

		public virtual ISet<PollChoiceItem> Items {
			get { return _items ?? (_items = new HashedSet<PollChoiceItem>()); }
			protected set { _items = value; }
		}
	}
}
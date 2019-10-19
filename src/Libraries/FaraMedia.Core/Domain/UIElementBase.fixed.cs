namespace FaraMedia.Core.Domain {
	using FaraMedia.Core.Domain.Components;
	using FaraMedia.Core.Domain.Security;

	public abstract class UIElementBase : UserContentBase,
	                                      IRoleOwnable,
	                                      IHasMetadata,
	                                      IHasDeletionHistory {
		private MetadataComponent _metadata;
		private HistoryComponent _deletionHistory;

		public virtual short DisplayOrder { get; set; }
		public virtual Role Owner { get; set; }

		public virtual MetadataComponent Metadata {
			get { return _metadata ?? (_metadata = new MetadataComponent()); }
			set { _metadata = value; }
		}

		public abstract void OverrideMetadata();

		public virtual HistoryComponent DeletionHistory {
			get { return _deletionHistory ?? (_deletionHistory = new HistoryComponent()); }
			set { _deletionHistory = value; }
		}
	}
}
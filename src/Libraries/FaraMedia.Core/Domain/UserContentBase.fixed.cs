namespace FaraMedia.Core.Domain {
	using FaraMedia.Core.Domain.Components;

	public abstract class UserContentBase : EntityBase,
	                                        IHasCreationHistory,
	                                        IHasModificationHistory {
		private HistoryComponent _creationHistory;
		private HistoryComponent _modificationHistory;

		public virtual HistoryComponent CreationHistory {
			get { return _creationHistory ?? (_creationHistory = new HistoryComponent()); }
			set { _creationHistory = value; }
		}

		public virtual HistoryComponent ModificationHistory {
			get { return _modificationHistory ?? (_modificationHistory = new HistoryComponent()); }
			set { _modificationHistory = value; }
		}
	}
}
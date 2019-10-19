namespace FaraMedia.Data.Mapping {
	using FaraMedia.Core.Domain;

	public abstract class UIElementMapBase<T> : UserContentMapBase<T> where T : UIElementBase {
		protected UIElementMapBase() {
			Property(uie => uie.DisplayOrder);
			ManyToOne(uie => uie.Owner);
			Component(uie => uie.Metadata);
			Component(uie => uie.DeletionHistory);
		}
	}
}
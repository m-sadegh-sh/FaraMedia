namespace FaraMedia.Data.Mapping {
	using FaraMedia.Core.Domain;

	public abstract class UserContentMapBase<T> : EntityMapBase<T> where T : UserContentBase {
		protected UserContentMapBase() {
			Component(uc => uc.CreationHistory);
			Component(uc => uc.ModificationHistory);
		}
	}
}
namespace FaraMedia.Data.Mapping {
	using FaraMedia.Core.Domain;

	public abstract class OwnableMapBase<T> : EntityMapBase<T> where T : OwnableBase {
		protected OwnableMapBase() {
			Property(o => o.OwnerId);
		}
	}
}
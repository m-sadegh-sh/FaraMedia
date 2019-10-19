namespace FaraMedia.Data.Mapping {
	using FaraMedia.Core.Domain;

	public abstract class AttributeMapBase<TEntity> : EntityMapBase<TEntity> where TEntity : AttributeBase {
		protected AttributeMapBase() {
			Property(a => a.SystemName,
			         pm => pm.Unique(true));
			Property(a => a.DisplayName);
			Property(a => a.Description);
		}
	}
}
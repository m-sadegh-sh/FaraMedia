namespace FaraMedia.Data.Mapping.Shared {
	using FaraMedia.Core.Domain.Shared;

	public sealed class EntityAttributeMap : OwnableMapBase<EntityAttribute> {
		public EntityAttributeMap() {
			Property(ea => ea.Key,
			         pm => pm.Unique(true));
			Property(ea => ea.DisplayName);
			Property(ea => ea.Value);
			Property(ea => ea.Description);
		}
	}
}
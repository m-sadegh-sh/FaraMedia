namespace FaraMedia.Data.Mapping.Systematic {
	using FaraMedia.Core.Domain.Systematic;

	public sealed class ResourceKeyMap : EntityMapBase<ResourceKey> {
		public ResourceKeyMap() {
			Property(rk => rk.Key,
			         pm => pm.Unique(true));
			Property(rk => rk.DisplayName);
			Property(rk => rk.Description);
			Set(rk => rk.Values);
		}
	}
}
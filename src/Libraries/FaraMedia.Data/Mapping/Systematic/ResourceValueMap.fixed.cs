namespace FaraMedia.Data.Mapping.Systematic {
	using FaraMedia.Core.Domain.Systematic;

	public sealed class ResourceValueMap : EntityMapBase<ResourceValue> {
		public ResourceValueMap() {
			ManyToOne(rv => rv.Language);
			ManyToOne(rv => rv.Key);
			Property(rv => rv.Value);
		}
	}
}
namespace FaraMedia.Data.Mapping.Components {
	using FaraMedia.Core.Domain.Components;

	using NHibernate.Mapping.ByCode.Conformist;

	public sealed class MetadataComponentMap : ComponentMapping<MetadataComponent> {
		public MetadataComponentMap() {
			Property(mc => mc.Title);
			Property(mc => mc.Slug);
			Property(mc => mc.Keywords);
			Property(mc => mc.Description);
		}
	}
}
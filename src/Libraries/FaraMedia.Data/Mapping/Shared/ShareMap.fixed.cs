namespace FaraMedia.Data.Mapping.Shared {
	using FaraMedia.Core.Domain.Shared;

	public sealed class ShareMap : OwnableMapBase<Share> {
		public ShareMap() {
			ManyToOne(s => s.Sharer);
			Property(s => s.ShareDateUtc);
		}
	}
}
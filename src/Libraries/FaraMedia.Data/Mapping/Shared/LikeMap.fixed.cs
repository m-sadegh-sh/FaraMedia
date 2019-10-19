namespace FaraMedia.Data.Mapping.Shared {
	using FaraMedia.Core.Domain.Shared;

	public sealed class LikeMap : OwnableMapBase<Like> {
		public LikeMap() {
			ManyToOne(l => l.Liker);
			Property(l => l.LikeDateUtc);
		}
	}
}
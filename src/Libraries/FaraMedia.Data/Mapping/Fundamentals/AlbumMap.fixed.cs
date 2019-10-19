namespace FaraMedia.Data.Mapping.Fundamentals {
	using FaraMedia.Core.Domain.Fundamentals;

	public sealed class AlbumMap : UIElementMapBase<Album> {
		public AlbumMap() {
			Property(a => a.Title);
			Property(a => a.Description);
			Property(a => a.ReleaseDateUtc);
			Set(a => a.Tracks);
		}
	}
}
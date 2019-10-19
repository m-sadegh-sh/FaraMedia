namespace FaraMedia.Data.Mapping.Fundamentals {
	using FaraMedia.Core.Domain.Fundamentals;

	public sealed class PhotoAlbumMap : UIElementMapBase<PhotoAlbum> {
		public PhotoAlbumMap() {
			Property(pa => pa.Title);
			Property(pa => pa.Description);
			ManyToOne(pa => pa.Artist);
			Set(pa => pa.Photos);
		}
	}
}
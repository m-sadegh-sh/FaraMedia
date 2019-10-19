namespace FaraMedia.Data.Mapping.Fundamentals {
	using FaraMedia.Core.Domain.Fundamentals;

	public sealed class PhotoMap : UIElementMapBase<Photo> {
		public PhotoMap() {
			Property(p => p.Title);
			Property(p => p.Description);
			ManyToOne(p => p.Album);
			ManyToOne(p => p.Picture);
		}
	}
}
namespace FaraMedia.Data.Mapping.FileManagement {
	using FaraMedia.Core.Domain.FileManagement;

	public sealed class PictureMap : UserContentMapBase<Picture> {
		public PictureMap() {
			Property(p => p.FileName);
			Property(p => p.MimeType);
		}
	}
}
namespace FaraMedia.Data.Mapping.FileManagement {
	using FaraMedia.Core.Domain.FileManagement;

	public sealed class DownloadMap : UserContentMapBase<Download> {
		public DownloadMap() {
			Property(d => d.UseDownloadUrl);
			Property(d => d.FileName);
			Property(d => d.ContentType);
			Property(d => d.ContentLength);
			Property(d => d.Checksum);
			Property(d => d.BinaryContent);
			ManyToOne(d => d.DownloadUrl);
		}
	}
}
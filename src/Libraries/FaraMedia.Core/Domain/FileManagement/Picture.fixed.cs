namespace FaraMedia.Core.Domain.FileManagement {
	public class Picture : UserContentBase {
		public virtual string FileName { get; set; }
		public virtual string MimeType { get; set; }
	}
}
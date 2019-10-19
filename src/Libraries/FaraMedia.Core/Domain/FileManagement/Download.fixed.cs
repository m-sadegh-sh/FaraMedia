namespace FaraMedia.Core.Domain.FileManagement {
	using FaraMedia.Core.Domain.Misc;

	public class Download : UserContentBase {
		public virtual bool UseDownloadUrl { get; set; }
		public virtual string FileName { get; set; }
		public virtual string ContentType { get; set; }
		public virtual long ContentLength { get; set; }
		public virtual string Checksum { get; set; }
		public virtual byte[] BinaryContent { get; set; }
		public virtual Redirector DownloadUrl { get; set; }
	}
}
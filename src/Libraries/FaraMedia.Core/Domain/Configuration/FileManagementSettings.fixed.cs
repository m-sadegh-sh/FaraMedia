namespace FaraMedia.Core.Domain.Configuration {
	public class FileManagementSettings : ISettings {
		public bool DefaultPictureZoomEnabled { get; set; }
		public int MaximumImageSize { get; set; }
		public int AvatarPictureSize { get; set; }
		public int ThumbPictureSize { get; set; }
		public int DetailsPictureSize { get; set; }
		public long ImageQuality { get; set; }
		public string DefaultAvatarImageName { get; set; }
		public string DefaultEntityImageName { get; set; }
		public string CdnUrl { get; set; }
		public string ImagesPath { get; set; }
		public string StylesPath { get; set; }
		public string ScriptsPath { get; set; }
		public string DownloadsPath { get; set; }
	}
}
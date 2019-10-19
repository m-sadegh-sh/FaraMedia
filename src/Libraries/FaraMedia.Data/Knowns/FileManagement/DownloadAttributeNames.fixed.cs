namespace FaraMedia.Data.Knowns.FileManagement {
	using FaraMedia.Data.Schemas;

	public sealed class DownloadAttributeNames : ConstantsBase {
		public static readonly string IsOrderLineDownload = Helpers.Key<DownloadAttributeNames, string>(dan => IsOrderLineDownload);
		public static readonly string IsDemo = Helpers.Key<DownloadAttributeNames, string>(dan => IsDemo);
	}
}
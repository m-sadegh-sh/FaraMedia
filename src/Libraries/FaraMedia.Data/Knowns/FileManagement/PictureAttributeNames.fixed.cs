namespace FaraMedia.Data.Knowns.FileManagement {
	using FaraMedia.Data.Schemas;

	public sealed class PictureAttributeNames : ConstantsBase {
		public static readonly string IsThumbnail = Helpers.Key<PictureAttributeNames, string>(pan => IsThumbnail);
	}
}
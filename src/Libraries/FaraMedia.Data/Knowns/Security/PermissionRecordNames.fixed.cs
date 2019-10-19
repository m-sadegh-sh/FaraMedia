namespace FaraMedia.Data.Knowns.Security {
	using FaraMedia.Data.Schemas;

	public sealed class PermissionRecordNames : ConstantsBase {
		public static readonly string BasicRead = Helpers.Key<PermissionRecordNames, string>(prn => BasicRead);
		public static readonly string BasicCreate = Helpers.Key<PermissionRecordNames, string>(prn => BasicCreate);
		public static readonly string BasicUpdate = Helpers.Key<PermissionRecordNames, string>(prn => BasicUpdate);
		public static readonly string BasicDelete = Helpers.Key<PermissionRecordNames, string>(prn => BasicDelete);
	}
}
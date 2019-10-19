namespace FaraMedia.Data.Knowns {
	using FaraMedia.Data.Schemas;

	public sealed class KnownActionNames : ConstantsBase {
		public static readonly string Default = Helpers.Key<KnownActionNames, string>(kan => Default);
		public static readonly string List = Helpers.Key<KnownActionNames, string>(kan => List);
		public static readonly string Details = Helpers.Key<KnownActionNames, string>(kan => Details);
		public static readonly string New = Helpers.Key<KnownActionNames, string>(kan => New);
		public static readonly string Edit = Helpers.Key<KnownActionNames, string>(kan => Edit);
		public static readonly string Save = Helpers.Key<KnownActionNames, string>(kan => Save);

		public static readonly string[] NonPluralizableTokens = new[] {Default, List, Details, New, Edit, Save};
	}
}
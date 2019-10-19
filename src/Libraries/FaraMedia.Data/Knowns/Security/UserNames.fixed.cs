namespace FaraMedia.Data.Knowns.Security {
	using FaraMedia.Data.Schemas;

	public sealed class UserNames : ConstantsBase {
		public static readonly string SearchEngine = Helpers.Key<UserNames, string>(un => SearchEngine);
	}
}
namespace FaraMedia.Data.Knowns.Security {
	using FaraMedia.Data.Schemas;

	public sealed class RoleNames : ConstantsBase {
		public static readonly string Administrators = Helpers.Key<RoleNames, string>(rn => Administrators);
		public static readonly string Moderators = Helpers.Key<RoleNames, string>(rn => Moderators);
		public static readonly string ContentProviders = Helpers.Key<RoleNames, string>(rn => ContentProviders);
		public static readonly string Companies = Helpers.Key<RoleNames, string>(rn => Companies);
		public static readonly string Registered = Helpers.Key<RoleNames, string>(rn => Registered);
		public static readonly string Guests = Helpers.Key<RoleNames, string>(rn => Guests);
	}
}
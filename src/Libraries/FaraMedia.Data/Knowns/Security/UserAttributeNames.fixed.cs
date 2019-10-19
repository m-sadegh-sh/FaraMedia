namespace FaraMedia.Data.Knowns.Security {
	using FaraMedia.Data.Schemas;

	public sealed class UserAttributeNames : ConstantsBase {
		public static readonly string RegisterDateUtc = Helpers.Key<UserAttributeNames, string>(uan => RegisterDateUtc);
		public static readonly string AccountActivationToken = Helpers.Key<UserAttributeNames, string>(uan => AccountActivationToken);
		public static readonly string PasswordRecoveryToken = Helpers.Key<UserAttributeNames, string>(uan => PasswordRecoveryToken);
		public static readonly string FirstName = Helpers.Key<UserAttributeNames, string>(uan => FirstName);
		public static readonly string LastName = Helpers.Key<UserAttributeNames, string>(uan => LastName);
		public static readonly string NickName = Helpers.Key<UserAttributeNames, string>(uan => NickName);
		public static readonly string DateOfBirth = Helpers.Key<UserAttributeNames, string>(uan => DateOfBirth);
		public static readonly string LanguageId = Helpers.Key<UserAttributeNames, string>(uan => LanguageId);
		public static readonly string TimeZoneId = Helpers.Key<UserAttributeNames, string>(uan => TimeZoneId);
		public static readonly string City = Helpers.Key<UserAttributeNames, string>(uan => City);
		public static readonly string Phone = Helpers.Key<UserAttributeNames, string>(uan => Phone);
		public static readonly string AvatarPictureId = Helpers.Key<UserAttributeNames, string>(uan => AvatarPictureId);
		public static readonly string PublicEmail = Helpers.Key<UserAttributeNames, string>(uan => PublicEmail);
		public static readonly string FacebookPageId = Helpers.Key<UserAttributeNames, string>(uan => FacebookPageId);
		public static readonly string TwitterAccountId = Helpers.Key<UserAttributeNames, string>(uan => TwitterAccountId);
		public static readonly string WorkingDesktopThemeName = Helpers.Key<UserAttributeNames, string>(uan => WorkingDesktopThemeName);
		public static readonly string DontUseMobileVersion = Helpers.Key<UserAttributeNames, string>(uan => DontUseMobileVersion);
	}
}
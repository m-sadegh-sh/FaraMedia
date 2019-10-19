namespace FaraMedia.Data.Knowns.Systematic {
	using FaraMedia.Data.Schemas;

	public sealed class ActivityTypeNames : ConstantsBase {
		//Users
		public static readonly string SignUp = Helpers.Key<ActivityTypeNames, string>(atn => SignUp);
		public static readonly string ActivateAccount = Helpers.Key<ActivityTypeNames, string>(atn => ActivateAccount);
		public static readonly string SignIn = Helpers.Key<ActivityTypeNames, string>(atn => SignIn);
		public static readonly string SignOut = Helpers.Key<ActivityTypeNames, string>(atn => SignOut);
		public static readonly string ChangePassword = Helpers.Key<ActivityTypeNames, string>(atn => ChangePassword);
		public static readonly string ResetPassword = Helpers.Key<ActivityTypeNames, string>(atn => ResetPassword);

		//Administrators
		public static readonly string BlockAccount = Helpers.Key<ActivityTypeNames, string>(atn => BlockAccount);
		public static readonly string UnBlockAccount = Helpers.Key<ActivityTypeNames, string>(atn => UnBlockAccount);
	}
}
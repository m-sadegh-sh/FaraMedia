namespace FaraMedia.Data.Knowns.Systematic {
	using FaraMedia.Data.Schemas;

	public sealed class MessageTemplateNames : ConstantsBase {
		//Users
		public static readonly string AccountValidation = Helpers.Key<MessageTemplateNames, string>(mtn => AccountValidation);
		public static readonly string ChangePassword = Helpers.Key<MessageTemplateNames, string>(mtn => ChangePassword);
		public static readonly string ResetPassword = Helpers.Key<MessageTemplateNames, string>(mtn => ResetPassword);
		public static readonly string NewsletterSubscribtionConfirmation = Helpers.Key<MessageTemplateNames, string>(mtn => NewsletterSubscribtionConfirmation);

		//Administrators
		public static readonly string AccountBlocking = Helpers.Key<MessageTemplateNames, string>(mtn => AccountBlocking);
		public static readonly string AccountUnBlocking = Helpers.Key<MessageTemplateNames, string>(mtn => AccountUnBlocking);

		//User Billing
		public static readonly string OrderConfirmation = Helpers.Key<MessageTemplateNames, string>(mtn => OrderConfirmation);
		public static readonly string OrderCancellation = Helpers.Key<MessageTemplateNames, string>(mtn => OrderCancellation);
		public static readonly string OrderCompletion = Helpers.Key<MessageTemplateNames, string>(mtn => OrderCompletion);

		//User 
		public static readonly string NewInFavorites = Helpers.Key<MessageTemplateNames, string>(mtn => NewInFavorites);
		public static readonly string TopFeatured = Helpers.Key<MessageTemplateNames, string>(mtn => TopFeatured);
	}
}
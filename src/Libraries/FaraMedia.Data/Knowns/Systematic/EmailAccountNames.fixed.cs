namespace FaraMedia.Data.Knowns.Systematic {
	using FaraMedia.Data.Schemas;

	public sealed class EmailAccountNames : ConstantsBase {
		public static readonly string NoReply = Helpers.Key<EmailAccountNames, string>(ean => NoReply);
		public static readonly string Info = Helpers.Key<EmailAccountNames, string>(ean => Info);
		public static readonly string Support = Helpers.Key<EmailAccountNames, string>(ean => Support);
		public static readonly string Sales = Helpers.Key<EmailAccountNames, string>(ean => Sales);
	}
}
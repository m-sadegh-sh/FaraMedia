namespace FaraMedia.Data.Mapping.Systematic {
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Data.NHibernating.CustomTypes;

	public sealed class MessageTemplateMap : AttributeMapBase<MessageTemplate> {
		public MessageTemplateMap() {
			Property(mt => mt.BccEmailAddresses,
			         pm => pm.Type<CsvFormattedUserType<string>>());
			Property(mt => mt.Subject);
			Property(mt => mt.Body);
			ManyToOne(mt => mt.Account);
		}
	}
}
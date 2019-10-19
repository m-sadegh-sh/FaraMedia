namespace FaraMedia.Data.Mapping.Systematic {
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Data.NHibernating.CustomTypes;

	public sealed class QueuedEmailMap : EntityMapBase<QueuedEmail> {
		public QueuedEmailMap() {
			Property(qe => qe.From);
			Property(qe => qe.FromName);
			Property(qe => qe.To);
			Property(qe => qe.ToName);
			Property(qe => qe.Cc,
			         pm => pm.Type<CsvFormattedUserType<string>>());
			Property(qe => qe.Bcc,
			         pm => pm.Type<CsvFormattedUserType<string>>());
			Property(qe => qe.Subject);
			Property(qe => qe.Body);
			Property(qe => qe.SendPriority);
			Property(qe => qe.SendingTries);
			Property(qe => qe.SentDateUtc);
			ManyToOne(qe => qe.Account);
		}
	}
}
namespace FaraMedia.Data.Mapping.Systematic {
	using FaraMedia.Core.Domain.Systematic;

	public sealed class LogMap : EntityMapBase<Log> {
		public LogMap() {
			Property(l => l.ShortMessage);
			Property(l => l.FullMessage);
			Property(l => l.RequestedUrl);
			Property(l => l.ReferrerUrl);
			Property(l => l.Level);
			Property(l => l.LogDateUtc);
			ManyToOne(l => l.Invoker);
			Property(l => l.InvokerIp);
		}
	}
}
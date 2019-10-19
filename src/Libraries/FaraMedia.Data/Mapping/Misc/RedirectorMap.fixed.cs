namespace FaraMedia.Data.Mapping.Misc {
	using FaraMedia.Core.Domain.Misc;

	public sealed class RedirectorMap : EntityMapBase<Redirector> {
		public RedirectorMap() {
			Property(r => r.TargetUrl,
			         pm => pm.Unique(true));
			Property(r => r.ShortHash,
			         pm => pm.Unique(true));
			Property(r => r.UrlName);
			Property(r => r.Description);
			Property(r => r.UsageTimes);
			Set(r => r.Downloads);
			Set(r => r.Artists);
			Set(r => r.Publishers);
		}
	}
}
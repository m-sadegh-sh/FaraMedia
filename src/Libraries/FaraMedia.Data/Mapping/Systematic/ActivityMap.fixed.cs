namespace FaraMedia.Data.Mapping.Systematic {
	using FaraMedia.Core.Domain.Systematic;

	public sealed class ActivityMap : EntityMapBase<Activity> {
		public ActivityMap() {
			ManyToOne(a => a.Type);
			ManyToOne(a => a.Activator);
			Property(a => a.Comment);
			Property(a => a.ActivationDateUtc);
		}
	}
}
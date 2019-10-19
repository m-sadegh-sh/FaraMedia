namespace FaraMedia.Data.Mapping.Systematic {
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Data.Mapping.Shared;

	public sealed class ActivityTypeMap : AttributeMapBase<ActivityType> {
		public ActivityTypeMap() {
			Set(at => at.Activities);
		}
	}
}
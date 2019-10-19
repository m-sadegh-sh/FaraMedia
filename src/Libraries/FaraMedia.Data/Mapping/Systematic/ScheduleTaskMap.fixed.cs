namespace FaraMedia.Data.Mapping.Systematic {
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Data.Mapping.Shared;

	public sealed class ScheduleTaskMap : AttributeMapBase<ScheduleTask> {
		public ScheduleTaskMap() {
			Property(st => st.TypeName);
			Property(st => st.ExecutionPriority);
			Property(st => st.IsActive);
			Property(st => st.StopOnError);
			Property(st => st.MaximumRunningSeconds);
		}
	}
}
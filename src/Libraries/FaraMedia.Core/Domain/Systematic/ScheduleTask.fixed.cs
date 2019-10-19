namespace FaraMedia.Core.Domain.Systematic {
	using FaraMedia.Core.Domain.Shared;

	public class ScheduleTask : AttributeBase {
		public virtual string TypeName { get; set; }
		public virtual bool IsActive { get; set; }
		public virtual Priority ExecutionPriority { get; set; }
		public virtual bool StopOnError { get; set; }
		public virtual int MaximumRunningSeconds { get; set; }
	}
}
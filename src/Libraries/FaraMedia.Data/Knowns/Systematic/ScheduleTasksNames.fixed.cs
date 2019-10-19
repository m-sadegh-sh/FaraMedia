namespace FaraMedia.Data.Knowns.Systematic {
	using FaraMedia.Data.Schemas;

	public sealed class ScheduleTasksNames : ConstantsBase {
		public static readonly string ClearCache = Helpers.Key<ScheduleTasksNames, string>(stn => ClearCache);
	}
}
namespace FaraMedia.Services.Tasks {
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Services.Extensions.Systematic;
    using FaraMedia.Services.Querying.Systematic;
    using FaraMedia.Services.Tasks.Abstraction;

    public sealed class ClearActivityTask : ITask {
        private readonly IDbService<Activity, ActivityQuery> _activityService;

        public ClearActivityTask(IDbService<Activity, ActivityQuery> activityService) {
            _activityService = activityService;
        }

        public void Execute() {
            _activityService.Clear();
        }
    }
}
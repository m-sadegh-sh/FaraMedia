namespace FaraMedia.Services.Tasks {
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Services.Extensions.Systematic;
    using FaraMedia.Services.Querying.Systematic;
    using FaraMedia.Services.Tasks.Abstraction;

    public sealed class ClearLogTask : ITask {
        private readonly IDbService<Log, LogQuery> _logService;

        public ClearLogTask(IDbService<Log, LogQuery> logService) {
            _logService = logService;
        }

        public void Execute() {
            _logService.Clear();
        }
    }
}
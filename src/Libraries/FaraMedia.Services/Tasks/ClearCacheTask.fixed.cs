namespace FaraMedia.Services.Tasks {
    using FaraMedia.Core.Caching;
    using FaraMedia.Services.Tasks.Abstraction;

    public sealed class ClearCacheTask : ITask {
        private readonly ICache _cache;

        public ClearCacheTask(ICache cache) {
            _cache = cache;
        }

        public void Execute() {
            _cache.Clear();
        }
    }
}
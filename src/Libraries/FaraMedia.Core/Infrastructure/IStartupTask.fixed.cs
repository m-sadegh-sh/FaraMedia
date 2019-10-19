namespace FaraMedia.Core.Infrastructure {
	public interface IStartupTask {
		int ExecutionOrder { get; }
		void Execute();
	}
}
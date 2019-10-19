namespace FaraMedia.Services.Tasks.Abstraction {
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Services.Querying.Systematic;
    using FaraMedia.Services.Systematic;

    public sealed class TaskManager {
        private static readonly TaskManager _taskManager = new TaskManager();
        private readonly List<TaskThread> _taskThreads = new List<TaskThread>();

        private TaskManager() {}

        public static TaskManager Instance {
            get { return _taskManager; }
        }

        public IList<TaskThread> TaskThreads {
            get { return new ReadOnlyCollection<TaskThread>(_taskThreads); }
        }

        public void Initialize() {
            _taskThreads.Clear();

            var scheduleTaskService = EngineContext.Current.Resolve<IDbService<ScheduleTask,ScheduleTaskQuery>>();
            var scheduleTasks = scheduleTaskService.GetAll().OrderBy(st => st.MaximumRunningSeconds).ToList();

            foreach (var scheduleTask in scheduleTasks) {
                var taskThread = new TaskThread(scheduleTask);
                _taskThreads.Add(taskThread);
                var task = new Task(scheduleTask);
                taskThread.AddTask(task);
            }
        }

        public void Start() {
            foreach (var taskThread in _taskThreads)
                taskThread.InitTimer();
        }

        public void Stop() {
            foreach (var taskThread in _taskThreads)
                taskThread.Dispose();
        }
    }
}
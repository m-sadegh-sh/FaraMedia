namespace FaraMedia.Services.Tasks.Abstraction {
    using System;

    using FaraMedia.Core.Domain.Systematic;

    public sealed class Task {
        private readonly ScheduleTask _scheduleTask;
        private readonly Type _taskType;
        private ITask _task;

        public Task(ScheduleTask scheduleTask) {
            _scheduleTask = scheduleTask;

            _taskType = Type.GetType(scheduleTask.TypeName);
            IsEanbled = _scheduleTask.IsActive;
        }

        public bool IsRunning { get; private set; }

        public DateTime LastStarted { get; private set; }

        public DateTime LastEnd { get; private set; }

        public DateTime LastSuccess { get; private set; }

        public Type TaskType {
            get { return _taskType; }
        }

        public bool IsEanbled { get; private set; }

        public bool StopOnError {
            get { return _scheduleTask.StopOnError; }
        }

        public string DisplayName {
            get { return _scheduleTask.DisplayName; }
        }

        private ITask CreateTask() {
            if (IsEanbled && _task == null) {
                if (_taskType != null)
                    _task = Activator.CreateInstance(_taskType) as ITask;
                
                IsEanbled = _task != null;
            }

            return _task;
        }

        public void Execute() {
            IsRunning = true;

            try {
                var task = CreateTask();
                if (task != null) {
                    LastStarted = DateTime.Now;
                    task.Execute();
                    LastEnd = LastSuccess = DateTime.Now;
                }
            } catch (Exception) {
                IsEanbled = !StopOnError;
                LastEnd = DateTime.Now;
            }

            IsRunning = false;
        }
    }
}
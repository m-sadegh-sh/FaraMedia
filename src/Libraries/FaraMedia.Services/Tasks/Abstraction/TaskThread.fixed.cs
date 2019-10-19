namespace FaraMedia.Services.Tasks.Abstraction {
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Threading;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Systematic;

	public sealed class TaskThread : DisposableBase {
		private readonly int _seconds;
		private readonly Dictionary<string, Task> _tasks;
		private Timer _timer;

		internal TaskThread(ScheduleTask scheduleTask) {
			_tasks = new Dictionary<string, Task>();
			_seconds = scheduleTask.MaximumRunningSeconds;
			IsRunning = false;
		}

		public int Seconds {
			get { return _seconds; }
		}

		public DateTime Started { get; private set; }

		public bool IsRunning { get; private set; }

		public IList<Task> Tasks {
			get {
				var list = _tasks.Values.ToList();
				return new ReadOnlyCollection<Task>(list);
			}
		}

		public int Interval {
			get { return _seconds*1000; }
		}

		protected override void CoreDispose(bool disposeManagedResources) {
			if (_timer != null) {
				lock (this) {
					_timer.Dispose();
					_timer = null;
				}
			}
		}

		private void Run() {
			if (_seconds <= 0)
				return;

			Started = DateTime.Now;
			IsRunning = true;

			foreach (var task in _tasks.Values)
				task.Execute();

			IsRunning = false;
		}

		private void TimerHandler(object state) {
			_timer.Change(-1,
			              -1);
			Run();
			_timer.Change(Interval,
			              Interval);
		}

		public void InitTimer() {
			if (_timer == null) {
				_timer = new Timer(TimerHandler,
				                   null,
				                   Interval,
				                   Interval);
			}
		}

		public void AddTask(Task task) {
			if (!_tasks.ContainsKey(task.DisplayName)) {
				_tasks.Add(task.DisplayName,
				           task);
			}
		}
	}
}
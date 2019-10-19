namespace FaraMedia.Core.Domain.Misc {
	using System;

	using FaraMedia.Core.Domain.Security;

	public class ToDo : EntityBase {
		public virtual string Title { get; set; }
		public virtual string Description { get; set; }
		public virtual User Performer { get; set; }
		public virtual ToDoStatus Status { get; set; }
		public virtual DateTime DueDateUtc { get; set; }
	}
}
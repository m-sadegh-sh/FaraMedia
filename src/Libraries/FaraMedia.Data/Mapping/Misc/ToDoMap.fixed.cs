namespace FaraMedia.Data.Mapping.Misc {
	using FaraMedia.Core.Domain.Misc;

	public sealed class ToDoMap : EntityMapBase<ToDo> {
		public ToDoMap() {
			Property(td => td.Title);
			Property(td => td.Description);
			ManyToOne(td => td.Performer);
			ManyToOne(td => td.Status);
			Property(td => td.DueDateUtc);
		}
	}
}
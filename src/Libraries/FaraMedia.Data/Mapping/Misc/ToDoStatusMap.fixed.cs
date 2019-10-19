namespace FaraMedia.Data.Mapping.Misc {
	using FaraMedia.Core.Domain.Misc;
	using FaraMedia.Data.Mapping.Shared;

	public sealed class ToDoStatusMap : AttributeMapBase<ToDoStatus> {
		public ToDoStatusMap() {
			Set(tds => tds.ToDos);
		}
	}
}
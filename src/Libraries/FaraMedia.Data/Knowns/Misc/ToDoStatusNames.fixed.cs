namespace FaraMedia.Data.Knowns.Misc {
	using FaraMedia.Data.Schemas;

	public sealed class ToDoStatusNames : ConstantsBase {
		public static readonly string Pending = Helpers.Key<ToDoStatusNames, string>(tdsn => Pending);
		public static readonly string Disabled = Helpers.Key<ToDoStatusNames, string>(tdsn => Disabled);
		public static readonly string Cancelled = Helpers.Key<ToDoStatusNames, string>(tdsn => Cancelled);
		public static readonly string Done = Helpers.Key<ToDoStatusNames, string>(tdsn => Done);
	}
}
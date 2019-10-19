namespace FaraMedia.Core.Domain.Misc {
	using FaraMedia.Core.Domain.Shared;

	using Iesi.Collections.Generic;

	public class ToDoStatus : AttributeBase {
		private ISet<ToDo> _toDos;

		public virtual ISet<ToDo> ToDos {
			get { return _toDos ?? (_toDos = new HashedSet<ToDo>()); }
			protected set { _toDos = value; }
		}
	}
}
namespace FaraMedia.Core.Domain.Shared {
	public class EntityAttribute : OwnableBase {
		public virtual string Key { get; set; }
		public virtual string DisplayName { get; set; }
		public virtual string Value { get; set; }
		public virtual string Description { get; set; }
	}
}
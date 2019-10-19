namespace FaraMedia.Core.Domain.Systematic {
	public class ResourceValue : EntityBase {
		public virtual Language Language { get; set; }
		public virtual ResourceKey Key { get; set; }
		public virtual string Value { get; set; }
	}
}
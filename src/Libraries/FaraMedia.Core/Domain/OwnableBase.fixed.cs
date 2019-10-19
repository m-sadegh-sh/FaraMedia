namespace FaraMedia.Core.Domain {
	public abstract class OwnableBase : EntityBase,
	                                    IOwnable {
		public virtual long OwnerId { get; set; }
	}
}
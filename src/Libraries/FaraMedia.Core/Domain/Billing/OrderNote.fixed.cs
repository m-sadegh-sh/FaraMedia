namespace FaraMedia.Core.Domain.Billing {
	public class OrderNote : EntityBase {
		public virtual string Note { get; set; }
		public virtual bool IsPublic { get; set; }
		public virtual Order Order { get; set; }
	}
}
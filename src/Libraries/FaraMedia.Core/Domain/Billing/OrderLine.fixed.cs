namespace FaraMedia.Core.Domain.Billing {
	using FaraMedia.Core.Domain.FileManagement;

	public class OrderLine : EntityBase {
		public virtual ItemType Type { get; set; }
		public virtual long? ItemId { get; set; }
		public virtual string ItemTitle { get; set; }
		public virtual int Quantity { get; set; }
		public virtual int? Discount { get; set; }
		public virtual int Price { get; set; }
		public virtual Order Order { get; set; }
		public virtual Download Download { get; set; }
		public virtual short AccessTries { get; set; }
	}
}
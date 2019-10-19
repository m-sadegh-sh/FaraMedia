namespace FaraMedia.Data.Mapping.Billing {
	using FaraMedia.Core.Domain.Billing;

	public sealed class OrderNoteMap : EntityMapBase<OrderNote> {
		public OrderNoteMap() {
			Property(on => on.Note);
			Property(on => on.IsPublic);
			ManyToOne(on => on.Order);
		}
	}
}
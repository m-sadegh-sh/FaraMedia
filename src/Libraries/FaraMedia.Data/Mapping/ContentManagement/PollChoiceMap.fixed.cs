namespace FaraMedia.Data.Mapping.ContentManagement {
	using FaraMedia.Core.Domain.ContentManagement;

	public sealed class PollChoiceMap : EntityMapBase<PollChoice> {
		public PollChoiceMap() {
			Property(pc => pc.Title);
			Property(pc => pc.Description);
			Property(pc => pc.IsMultiSelection);
			ManyToOne(pc => pc.Poll);
			Set(pc => pc.Items);
		}
	}
}
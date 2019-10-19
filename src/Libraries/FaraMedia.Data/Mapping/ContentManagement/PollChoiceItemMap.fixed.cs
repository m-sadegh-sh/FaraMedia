namespace FaraMedia.Data.Mapping.ContentManagement {
	using FaraMedia.Core.Domain.ContentManagement;

	public sealed class PollChoiceItemMap : EntityMapBase<PollChoiceItem> {
		public PollChoiceItemMap() {
			Property(pci => pci.Text);
			ManyToOne(pci => pci.Choice);
			Set(pci => pci.VotingRecords);
		}
	}
}
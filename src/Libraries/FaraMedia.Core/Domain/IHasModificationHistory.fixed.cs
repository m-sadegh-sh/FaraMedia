namespace FaraMedia.Core.Domain {
	using FaraMedia.Core.Domain.Components;

	public interface IHasModificationHistory {
		HistoryComponent ModificationHistory { get; set; }
	}
}
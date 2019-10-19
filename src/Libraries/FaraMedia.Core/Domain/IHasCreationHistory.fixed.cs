namespace FaraMedia.Core.Domain {
	using FaraMedia.Core.Domain.Components;

	public interface IHasCreationHistory {
		HistoryComponent CreationHistory { get; set; }
	}
}
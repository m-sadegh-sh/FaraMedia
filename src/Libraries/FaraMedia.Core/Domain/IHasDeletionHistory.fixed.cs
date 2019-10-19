namespace FaraMedia.Core.Domain {
	using FaraMedia.Core.Domain.Components;

	public interface IHasDeletionHistory {
		HistoryComponent DeletionHistory { get; set; }
	}
}
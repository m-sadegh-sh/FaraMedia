namespace FaraMedia.Core.Domain {
	using FaraMedia.Core.Domain.Components;

	public interface IHasMetadata {
		MetadataComponent Metadata { get; set; }

		void OverrideMetadata();
	}
}
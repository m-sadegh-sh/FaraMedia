namespace FaraMedia.Data.Mapping.Security {
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Data.Mapping.Shared;

	public sealed class BlockReasonMap : AttributeMapBase<BlockReason> {
		public BlockReasonMap() {
			Set(bt => bt.Users);
		}
	}
}
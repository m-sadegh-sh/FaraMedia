namespace FaraMedia.Data.Knowns.Security {
	using FaraMedia.Data.Schemas;

	public sealed class BlockReasonNames : ConstantsBase {
		public static readonly string NoActivatedYet = Helpers.Key<BlockReasonNames, string>(brn => NoActivatedYet);
		public static readonly string AdminBlocked = Helpers.Key<BlockReasonNames, string>(brn => AdminBlocked);
	}
}
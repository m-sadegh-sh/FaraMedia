namespace FaraMedia.Core.Operators {
	public enum StringOperator : byte {
		Exact = 1,
		Contains = 2,
		StartsWith = 4,
		EndsWith = 8
	}
}
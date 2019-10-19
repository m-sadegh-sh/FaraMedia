namespace FaraMedia.Data.Knowns {
	public static class ParameterNamesExtensions {
		public static string ToExpression(this string parameterName) {
			return "{" + parameterName + "}";
		}
	}
}
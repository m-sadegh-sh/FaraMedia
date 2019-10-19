namespace FaraMedia.Core.Infrastructure.Extensions {
	using System.Linq;

	public static class GenericExtensions {
		public static bool Any<T>(this T actualValue,
		                          T expectedValue,
		                          params T[] otherExpectedValues) {
			return otherExpectedValues.Concat(new[] {expectedValue}).
			                           Contains(actualValue);
		}

		public static bool Any(this object actualValue,
		                       object expectedValue,
		                       params object[] otherExpectedValues) {
			return otherExpectedValues.Concat(new[] {expectedValue}).
			                           Contains(actualValue);
		}
	}
}
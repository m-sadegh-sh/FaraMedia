namespace FaraMedia.Core.Infrastructure.Extensions {
	using System.Collections.Generic;
	using System.Linq;

	public static class ListExtensions {
		public static T Prev<T>(this IList<T> source,
		                        T @this) {
			return RelativeWith(source,
			                    @this,
			                    -1);
		}

		public static T Next<T>(this IList<T> source,
		                        T @this) {
			return RelativeWith(source,
			                    @this,
			                    1);
		}

		private static T RelativeWith<T>(this IList<T> source,
		                                 T @this,
		                                 int differential) {
			if (source == null)
				return default(T);

			if (source.Contains(@this)) {
				var indexOfOther = source.IndexOf(@this) + differential;
				return source.ElementAtOrDefault(indexOfOther);
			}

			return default(T);
		}
	}
}
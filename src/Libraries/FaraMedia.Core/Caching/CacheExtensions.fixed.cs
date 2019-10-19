namespace FaraMedia.Core.Caching {
	using System;

	public static class CacheExtensions {
		public static T Get<T>(this ICache cache,
		                       string key,
		                       Func<T> acquire) {
			if (cache.Exists(key))
				return cache.Get<T>(key);

			var value = acquire();

			cache.Add(key,
			          value);

			return value;
		}
	}
}
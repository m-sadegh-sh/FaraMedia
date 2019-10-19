namespace FaraMedia.Data.Schemas {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;

	using FaraMedia.Core.Domain;

	using Utilities.Reflection.ExtensionMethods;

	public sealed class ConstantKeyHelpers<T> : ConstantKeyHelpers where T : class {
		private readonly string _cachePattern;

		public ConstantKeyHelpers() {
			_cachePattern = (typeof (T).Name + KeySeparator).ToUpperInvariant();
		}

		public string CachePattern() {
			return JoinCacheKeyParameters();
		}

		public string CacheKey(params Expression<Func<T, object>>[] properties) {
			var parameters = new Dictionary<string, bool>();

			if (properties != null && properties.Length > 0) {
				foreach (var property in properties) {
					parameters.Add(property.GetPropertyName(),
					               true);
				}
			}

			return JoinCacheKeyParameters(parameters.ToArray());
		}

		private string JoinCacheKeyParameters(params KeyValuePair<string, bool>[] parameters) {
			var cacheKeyBuilder = new StringBuilder();

			cacheKeyBuilder.Append(_cachePattern);

			if (parameters != null && parameters.Length > 0) {
				var index = 0;

				foreach (var parameter in parameters) {
					cacheKeyBuilder.Append(parameter.Key);

					if (parameter.Value) {
						cacheKeyBuilder.AppendFormat("{{{0}}}",
						                             index);
					}

					if (index < parameters.Length - 1)
						cacheKeyBuilder.Append(KeySeparator);

					if (parameter.Value)
						index++;
				}
			}

			return cacheKeyBuilder.ToString().
			                       ToUpperInvariant();
		}
	}
}
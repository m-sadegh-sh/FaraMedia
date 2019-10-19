namespace FaraMedia.Core.Infrastructure.Extensions {
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	using CuttingEdge.Conditions;

	public static class DictionaryExtensions {
		public static string ToQueryString(this IDictionary<string, string> source) {
			Condition.Requires(source,
			                   "source").
			          IsNotNull();

			var builder = new StringBuilder("?");

			foreach (var keyValue in source.OrderBy(i => i.Key)) {
				builder.Append(string.Concat(Format(keyValue.Key),
				                             "=",
				                             keyValue.Value));

				if (source.Keys.Last() == keyValue.Key)
					builder.Append("&");
			}

			return builder.ToString();
		}

		private static string Format(string key) {
			return string.Concat(char.ToLower(key[0]),
			                     key.Substring(1));
		}
	}
}
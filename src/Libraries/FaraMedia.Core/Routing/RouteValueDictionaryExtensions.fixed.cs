namespace FaraMedia.Core.Routing {
	using System.Web.Routing;

	public static class RouteValueDictionaryExtensions {
		public static RouteValueDictionary Merge(this RouteValueDictionary first,
		                                         RouteValueDictionary second,
		                                         bool updateDuplicates = true) {
			var result = new RouteValueDictionary();

			foreach (var item in first) {
				result.Add(item.Key,
				           item.Value);
			}

			foreach (var item in second) {
				if (result.ContainsKey(item.Key)) {
					if (updateDuplicates)
						result[item.Key] = item.Value;
				} else {
					result.Add(item.Key,
					           item.Value);
				}
			}

			return result;
		}
	}
}
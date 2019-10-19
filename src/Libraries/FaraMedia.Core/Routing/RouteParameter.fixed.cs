namespace FaraMedia.Core.Routing {
	using System.Web.Mvc;
	using System.Web.Routing;

	public static class RouteParameter {
		public static RouteValueDictionary Add<T>(string key,
		                                          T value) {
			return Append(null,
			              key,
			              value);
		}

		public static RouteValueDictionary Append<T>(this object routeValues,
		                                             string key,
		                                             T value) {
			return Append(HtmlHelper.AnonymousObjectToHtmlAttributes(routeValues),
			              key,
			              value);
		}

		public static RouteValueDictionary Append<T>(this RouteValueDictionary routeValues,
		                                             string key,
		                                             T value) {
			if (routeValues == null)
				routeValues = new RouteValueDictionary();

			if (routeValues.ContainsKey(key))
				routeValues[key] = value;
			else {
				routeValues.Add(key,
				                value);
			}

			return routeValues;
		}
	}
}
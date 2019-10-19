namespace FaraMedia.Core {
	using System.Web;

	public sealed class HttpContextState : ISimpleState {
		private readonly HttpContextBase _httpContext;

		public HttpContextState(HttpContextBase httpContext) {
			_httpContext = httpContext;
		}

		public T Get<T>(string key) {
			return (T) _httpContext.Items[key];
		}

		public void Store(string key,
		                  object something) {
			_httpContext.Items[key] = something;
		}
	}
}
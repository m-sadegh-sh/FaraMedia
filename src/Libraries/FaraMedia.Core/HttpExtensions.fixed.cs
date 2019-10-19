namespace FaraMedia.Core {
	using System.Web;

	public static class HttpExtensions {
		public static bool IsReady(this HttpContextBase context) {
			try {
				if (context == null)
					return false;

				//Call something on request to ensure that is accessible!
				context.Request.ToString();

				//Call something on response to ensure that is accessible!
				context.Response.ToString();

				return true;
			} catch {
				return false;
			}
		}
	}
}
namespace FaraMedia.Core {
	using System.Web;

	public interface IWebHelper {
		string GetHost();
		string GetHost(bool useSsl);
		string GetIpAddress();
		string GetLocation();
		string GetLocation(bool useSsl);

		string GetUrl(bool absoluteUrl,
		              bool includeQueryString);

		string GetUrl(bool absoluteUrl,
		              bool includeQueryString,
		              bool useSsl);

		string GetReferrer();
		string MapPath(string path);
		bool IsCurrentConnectionSecured();
		string ServerVariables(string name);

		T QueryString<T>(string name,
		                 T defaultValue = default(T));

		bool RestartAppDomain();
		bool IsStaticResource(HttpRequestBase request);
		bool IsSearchEngine(HttpRequestBase request);
	}
}
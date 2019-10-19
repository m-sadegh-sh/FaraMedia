namespace FaraMedia.Web.Framework {
    using System.Collections.Specialized;
    using System.Web;

    using FaraMedia.Core.Infrastructure;

    public class RemotePost {
        private readonly HttpContextBase _httpContext;
        private readonly NameValueCollection _inputValues;

        public RemotePost() {
            _inputValues = new NameValueCollection();
            Url = "http:";
            Method = "post";
            FormName = "formName";

            _httpContext = EngineContext.Current.Resolve<HttpContextBase>();
        }

        public string Url { get; set; }

        public string Method { get; set; }

        public string FormName { get; set; }

        public NameValueCollection Params {
            get { return _inputValues; }
        }

        public void Add(string name, string value) {
            _inputValues.Add(name, value);
        }

        public void Post() {
            _httpContext.Response.Clear();
            _httpContext.Response.Write("<html><head>");
            _httpContext.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));
            _httpContext.Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url));
            for (var i = 0; i < _inputValues.Keys.Count; i++)
                _httpContext.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", HttpUtility.HtmlEncode(_inputValues.Keys[i]), HttpUtility.HtmlEncode(_inputValues[_inputValues.Keys[i]])));
            _httpContext.Response.Write("</form>");
            _httpContext.Response.Write("</body></html>");
            _httpContext.Response.End();
        }
    }
}
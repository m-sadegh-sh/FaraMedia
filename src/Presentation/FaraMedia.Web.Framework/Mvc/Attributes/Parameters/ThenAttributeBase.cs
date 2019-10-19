namespace FaraMedia.Web.Framework.Mvc.Attributes {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Root;
    using FaraMedia.Web.Framework.Routing;

    public abstract class ThenAttributeBase : ActionFilterAttribute {
        protected const string ParameterName = "then";
        protected string[] ParameterNames = new[] {ParameterName, "url"};

        protected string FormatOrRenewParameter(ControllerContext controllerContext, string then) {
            if (string.IsNullOrWhiteSpace(then))
                return RouteUrlProvider.GetUrl(RootSectionConstants.CommonController.Home.RouteName);

            then = controllerContext.RequestContext.HttpContext.Server.UrlDecode(then);

            foreach (var parameterName in ParameterNames) {
                var indexOfThen = then.IndexOf(parameterName + "=");

                while (indexOfThen > 0) {
                    indexOfThen += parameterName.Length + 1;
                    then = then.Substring(indexOfThen, then.Length - indexOfThen);

                    indexOfThen = then.IndexOf(parameterName + "=");
                }
            }

            return then;
        }
    }
}
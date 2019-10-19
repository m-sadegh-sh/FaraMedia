namespace FaraMedia.Web.Framework.Routing {
    using System;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using FaraMedia.Core;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Authenticate;
    using FaraMedia.Data.Schemas.Layout;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Root;
    using FaraMedia.Services.Configuration;
    using FaraMedia.Web.Framework.Mvc.Extensions;

    public static class HtmlHelperExtensions {
        public static MvcHtmlString RootLink(this HtmlHelper htmlHelper, object htmlAttributes = null, string surroundUsing = "li", object surrounderAttributes = null, bool detectAndMarkAsActive = true, MvcHtmlString innerHtml = null) {
            var seoSettings = EngineContext.Current.Resolve<ISeoSettingsService>().LoadSeoSettings();

            return htmlHelper.LocalizedRouteLink(seoSettings.DefaultTitle, RootSectionConstants.CommonController.Root.RouteName, null, htmlAttributes, surroundUsing, surrounderAttributes, detectAndMarkAsActive, innerHtml);
        }

        public static MvcHtmlString HomeLink(this HtmlHelper htmlHelper, object htmlAttributes = null, string surroundUsing = "li", object surrounderAttributes = null, bool detectAndMarkAsActive = true, MvcHtmlString innerHtml = null) {
            return htmlHelper.LocalizedRouteLink(RootSectionConstants.CommonController.Home.Commands.Home, RootSectionConstants.CommonController.Home.RouteName, null, htmlAttributes, surroundUsing, surrounderAttributes, detectAndMarkAsActive, innerHtml);
        }

        public static MvcHtmlString LocalizedBackLink(this HtmlHelper htmlHelper, string routeName, object htmlAttributes = null, MvcHtmlString innerHtml = null) {
            return htmlHelper.LocalizedRouteLink(CrudSharedConstants.Commands.Back, routeName, null, htmlAttributes, null, null, false, innerHtml);
        }

        public static MvcHtmlString LocalizedBackToLink(this HtmlHelper htmlHelper, string argKey, string routeName, object routeValues, object htmlAttributes = null, MvcHtmlString innerHtml = null) {
            var arg = htmlHelper.T(argKey);
            var lintText = htmlHelper.T(CrudSharedConstants.Commands.BackTo, arg);

            return htmlHelper.SmartRouteLink(lintText, routeName, routeValues, htmlAttributes, null, null, false, innerHtml);
        }

        public static MvcHtmlString SignInLink(this HtmlHelper htmlHelper, object routeValues = null, object htmlAttributes = null, string surroundUsing = "li", object surrounderAttributes = null, bool detectAndMarkAsActive = true, MvcHtmlString innerHtml = null) {
            var routeValuesDictionary = RouteValueDictionaryExtensions.Convert(routeValues);

            routeValuesDictionary.Add("then", htmlHelper.ViewContext.RequestContext.HttpContext.Request.Url.PathAndQuery);

            return htmlHelper.LocalizedRouteLink(AuthenticateSectionConstants.SignController.In.Commands.SignIn, AuthenticateSectionConstants.SignController.In.RouteName, routeValuesDictionary, htmlAttributes, surroundUsing, surrounderAttributes, detectAndMarkAsActive, innerHtml);
        }

        public static MvcHtmlString SignOutLink(this HtmlHelper htmlHelper, object routeValues = null, object htmlAttributes = null, string surroundUsing = "li", object surrounderAttributes = null, bool detectAndMarkAsActive = true, MvcHtmlString innerHtml = null) {
            var routeValuesDictionary = RouteValueDictionaryExtensions.Convert(routeValues);

            routeValuesDictionary.Add("then", htmlHelper.ViewContext.RequestContext.HttpContext.Request.Url.PathAndQuery);

            return htmlHelper.LocalizedRouteLink(AuthenticateSectionConstants.SignController.Out.Commands.SignOut, AuthenticateSectionConstants.SignController.Out.RouteName, routeValuesDictionary, htmlAttributes, surroundUsing, surrounderAttributes, detectAndMarkAsActive, innerHtml);
        }

        public static MvcHtmlString SmartRouteLink(this HtmlHelper htmlHelper, string linkText, string routeName, object routeValues = null, object htmlAttributes = null, string surroundUsing = "li", object surrounderAttributes = null, bool detectAndMarkAsActive = true, MvcHtmlString innerHtml = null) {
            return htmlHelper.BuildRouteLink(linkText, routeName, routeValues, htmlAttributes, surroundUsing, surrounderAttributes, detectAndMarkAsActive, innerHtml: innerHtml);
        }

        public static MvcHtmlString LocalizedRouteLink(this HtmlHelper htmlHelper, string key, string routeName, object routeValues = null, object htmlAttributes = null, string surroundUsing = "li", object surrounderAttributes = null, bool detectAndMarkAsActive = true, MvcHtmlString innerHtml = null) {
            return htmlHelper.BuildRouteLink(htmlHelper.T(key), routeName, routeValues, htmlAttributes, surroundUsing, surrounderAttributes, detectAndMarkAsActive, innerHtml: innerHtml);
        }

        public static MvcHtmlString RouteLinkWithId(this HtmlHelper htmlHelper, string linkText, string routeName, long id, object routeValues = null, object htmlAttributes = null, string surroundUsing = "li", object surrounderAttributes = null, bool detectAndMarkAsActive = true, MvcHtmlString innerHtml = null) {
            var routeValueDictionary = RouteValueDictionaryExtensions.Convert(routeValues);

            routeValueDictionary.Add(KnownParameterNames.Id, id);

            return htmlHelper.BuildRouteLink(linkText, routeName, routeValueDictionary, htmlAttributes, surroundUsing, surrounderAttributes, detectAndMarkAsActive, innerHtml: innerHtml);
        }

        public static MvcHtmlString LocalizedRouteLinkWithId(this HtmlHelper htmlHelper, string key, string routeName, long id, object routeValues = null, object htmlAttributes = null, string surroundUsing = "li", object surrounderAttributes = null, bool detectAndMarkAsActive = true, MvcHtmlString innerHtml = null) {
            return LocalizedRouteLinkWithId(htmlHelper, key, null, routeName, id, routeValues, htmlAttributes, surroundUsing, surrounderAttributes, detectAndMarkAsActive, innerHtml);
        }

        public static MvcHtmlString LocalizedRouteLinkWithId(this HtmlHelper htmlHelper, string key, object[] args, string routeName, long id, object routeValues = null, object htmlAttributes = null, string surroundUsing = "li", object surrounderAttributes = null, bool detectAndMarkAsActive = true, MvcHtmlString innerHtml = null) {
            var routeValueDictionary = RouteValueDictionaryExtensions.Convert(routeValues);

            routeValueDictionary.Add(KnownParameterNames.Id, id);

            return htmlHelper.BuildRouteLink(htmlHelper.T(key, args), routeName, routeValueDictionary, htmlAttributes, surroundUsing, surrounderAttributes, detectAndMarkAsActive, innerHtml: innerHtml);
        }

        private static MvcHtmlString BuildRouteLink(this HtmlHelper htmlHelper, string linkText, string routeName, object routeValues = null, object htmlAttributes = null, string surroundUsing = "li", object surrounderAttributes = null, bool detectAndMarkAsActive = true, string activeClassName = "active", MvcHtmlString innerHtml = null) {
            var isCurrentRequest = false;

            if (detectAndMarkAsActive)
                isCurrentRequest = IsCurrentRequest(new UrlHelper(htmlHelper.ViewContext.RequestContext), routeName);

            var htmlAttributesDictionary = RouteValueDictionaryExtensions.Convert(htmlAttributes);

            if (isCurrentRequest && string.IsNullOrEmpty(surroundUsing)) {
                if (htmlAttributesDictionary.ContainsKey("class"))
                    htmlAttributesDictionary["class"] += string.Concat(" ", activeClassName);
                else
                    htmlAttributesDictionary.Add("class", activeClassName);
            }

            var link = htmlHelper.RouteLink(linkText, routeName, RouteValueDictionaryExtensions.Convert(routeValues), htmlAttributesDictionary);

            if (string.IsNullOrEmpty(surroundUsing))
                return link;

            var tag = new TagBuilder(surroundUsing);

            tag.MergeAttributes(RouteValueDictionaryExtensions.Convert(surrounderAttributes));

            if (isCurrentRequest)
                tag.AppendAttribute("class", activeClassName);

            tag.InnerHtml = link.ToHtmlString();

            if (innerHtml != null)
                tag.InnerHtml += innerHtml;

            return new MvcHtmlString(tag.ToString(TagRenderMode.Normal));
        }

        private static bool IsCurrentRequest(UrlHelper urlHelper, string routeName) {
            var requestedUrl = urlHelper.RouteUrl(routeName);

            var webHelper = EngineContext.Current.Resolve<IWebHelper>();
            var currentUrl = webHelper.GetUrl(false, false);

            var isCurrentRequest = string.Compare(requestedUrl, currentUrl, StringComparison.InvariantCultureIgnoreCase) == 0;

            return isCurrentRequest;
        }
    }
}
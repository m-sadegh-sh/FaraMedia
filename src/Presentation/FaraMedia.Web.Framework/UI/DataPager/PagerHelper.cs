namespace FaraMedia.Web.Framework.UI.DataPager {
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Web.Framework.Mvc;

    public static class PagerHelper {
        public static MvcHtmlString Pager(this HtmlHelper htmlHelper, int totalPageCount, int pageIndex, int pageSize, int totalItemCount, string actionName, string controllerName, PagerOptions pagerOptions, string routeName, object routeValues, object htmlAttributes) {
            var pagerBuilder = new PagerBuilder(htmlHelper, actionName, controllerName, totalPageCount, pageIndex, pageSize, totalItemCount, pagerOptions, routeName, RouteValueDictionaryExtensions.Convert(routeValues), RouteValueDictionaryExtensions.Convert(htmlAttributes));

            return pagerBuilder.RenderPager();
        }

        public static MvcHtmlString Pager(this HtmlHelper htmlHelper, int totalPageCount, int pageIndex, int pageSize, int totalItemCount, string actionName, string controllerName, PagerOptions pagerOptions, string routeName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) {
            var pagerBuilder = new PagerBuilder(htmlHelper, actionName, controllerName, totalPageCount, pageIndex, pageSize, totalItemCount, pagerOptions, routeName, routeValues, htmlAttributes);

            return pagerBuilder.RenderPager();
        }

        private static MvcHtmlString Pager(HtmlHelper htmlHelper, PagerOptions pagerOptions, IDictionary<string, object> htmlAttributes) {
            return new PagerBuilder(htmlHelper, null, pagerOptions, htmlAttributes).RenderPager();
        }

        public static MvcHtmlString Pager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList) {
            if (pagedList == null)
                return Pager(htmlHelper, null, null);

            return Pager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, null, null, null, null, null, null);
        }

        public static MvcHtmlString Pager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, PagerOptions pagerOptions) {
            if (pagedList == null)
                return Pager(htmlHelper, pagerOptions, null);

            return Pager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, null, null, pagerOptions, null, null, null);
        }

        public static MvcHtmlString Pager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, PagerOptions pagerOptions, object htmlAttributes) {
            if (pagedList == null)
                return Pager(htmlHelper, pagerOptions, RouteValueDictionaryExtensions.Convert(htmlAttributes));

            return Pager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, null, null, pagerOptions, null, null, htmlAttributes);
        }

        public static MvcHtmlString Pager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, PagerOptions pagerOptions, IDictionary<string, object> htmlAttributes) {
            if (pagedList == null)
                return Pager(htmlHelper, pagerOptions, htmlAttributes);

            return Pager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, null, null, pagerOptions, null, null, htmlAttributes);
        }

        public static MvcHtmlString Pager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, string routeName) {
            if (pagedList == null)
                return Pager(htmlHelper, new PagerOptions(htmlHelper), null);

            return Pager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, null, null, new PagerOptions(htmlHelper), routeName, null, null);
        }

        public static MvcHtmlString Pager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, PagerOptions pagerOptions, string routeName, object routeValues) {
            if (pagedList == null)
                return Pager(htmlHelper, pagerOptions, null);

            return Pager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, null, null, pagerOptions, routeName, routeValues, null);
        }

        public static MvcHtmlString Pager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, PagerOptions pagerOptions, string routeName, RouteValueDictionary routeValues) {
            if (pagedList == null)
                return Pager(htmlHelper, pagerOptions, null);

            return Pager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, null, null, pagerOptions, routeName, routeValues, null);
        }

        public static MvcHtmlString Pager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, PagerOptions pagerOptions, string routeName, object routeValues, object htmlAttributes) {
            if (pagedList == null)
                return Pager(htmlHelper, pagerOptions, RouteValueDictionaryExtensions.Convert(htmlAttributes));

            return Pager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, null, null, pagerOptions, routeName, routeValues, htmlAttributes);
        }

        public static MvcHtmlString Pager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, PagerOptions pagerOptions, string routeName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) {
            if (pagedList == null)
                return Pager(htmlHelper, pagerOptions, htmlAttributes);

            return Pager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, null, null, pagerOptions, routeName, routeValues, htmlAttributes);
        }

        public static MvcHtmlString Pager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, string routeName, object routeValues, object htmlAttributes) {
            if (pagedList == null)
                return Pager(htmlHelper, null, RouteValueDictionaryExtensions.Convert(htmlAttributes));

            return Pager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, null, null, null, routeName, routeValues, htmlAttributes);
        }

        public static MvcHtmlString Pager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, string routeName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) {
            if (pagedList == null)
                return Pager(htmlHelper, null, htmlAttributes);

            return Pager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, null, null, null, routeName, routeValues, htmlAttributes);
        }

        private static MvcHtmlString AjaxPager(HtmlHelper htmlHelper, PagerOptions pagerOptions, IDictionary<string, object> htmlAttributes) {
            return new PagerBuilder(htmlHelper, null, pagerOptions, htmlAttributes).RenderPager();
        }

        public static MvcHtmlString AjaxPager(this HtmlHelper htmlHelper, int totalPageCount, int pageIndex, int pageSize, int totalItemCount, string actionName, string controllerName, string routeName, PagerOptions pagerOptions, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes) {
            if (pagerOptions == null)
                pagerOptions = new PagerOptions(htmlHelper);

            var pagerBuilder = new PagerBuilder(htmlHelper, actionName, controllerName, totalPageCount, pageIndex, pageSize, totalItemCount, pagerOptions, routeName, RouteValueDictionaryExtensions.Convert(routeValues), ajaxOptions, RouteValueDictionaryExtensions.Convert(htmlAttributes));

            return pagerBuilder.RenderPager();
        }

        public static MvcHtmlString AjaxPager(this HtmlHelper htmlHelper, int totalPageCount, int pageIndex, int pageSize, int totalItemCount, string actionName, string controllerName, string routeName, PagerOptions pagerOptions, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes) {
            if (pagerOptions == null)
                pagerOptions = new PagerOptions(htmlHelper);

            var pagerBuilder = new PagerBuilder(htmlHelper, actionName, controllerName, totalPageCount, pageIndex, pageSize, totalItemCount, pagerOptions, routeName, routeValues, ajaxOptions, htmlAttributes);

            return pagerBuilder.RenderPager();
        }

        public static MvcHtmlString AjaxPager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, AjaxOptions ajaxOptions) {
            if (pagedList == null)
                return AjaxPager(htmlHelper, null, null);

            return AjaxPager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, null, null, null, null, null, ajaxOptions, null);
        }

        public static MvcHtmlString AjaxPager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, string routeName, AjaxOptions ajaxOptions) {
            if (pagedList == null)
                return AjaxPager(htmlHelper, null, null);

            return AjaxPager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, null, null, routeName, null, null, ajaxOptions, null);
        }

        public static MvcHtmlString AjaxPager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, PagerOptions pagerOptions, AjaxOptions ajaxOptions) {
            if (pagedList == null)
                return AjaxPager(htmlHelper, pagerOptions, null);

            return AjaxPager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, null, null, null, pagerOptions, null, ajaxOptions, null);
        }

        public static MvcHtmlString AjaxPager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, PagerOptions pagerOptions, AjaxOptions ajaxOptions, object htmlAttributes) {
            if (pagedList == null)
                return AjaxPager(htmlHelper, pagerOptions, RouteValueDictionaryExtensions.Convert(htmlAttributes));

            return AjaxPager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, null, null, null, pagerOptions, null, ajaxOptions, htmlAttributes);
        }

        public static MvcHtmlString AjaxPager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, PagerOptions pagerOptions, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes) {
            if (pagedList == null)
                return AjaxPager(htmlHelper, pagerOptions, htmlAttributes);

            return AjaxPager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, null, null, null, pagerOptions, null, ajaxOptions, htmlAttributes);
        }

        public static MvcHtmlString AjaxPager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, string routeName, object routeValues, AjaxOptions ajaxOptions) {
            if (pagedList == null)
                return AjaxPager(htmlHelper, new PagerOptions(htmlHelper), null);

            return AjaxPager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, null, null, routeName, new PagerOptions(htmlHelper), routeValues, ajaxOptions, null);
        }

        public static MvcHtmlString AjaxPager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, string routeName) {
            return AjaxPager(htmlHelper, pagedList, routeName, "");
        }

        public static MvcHtmlString AjaxPager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, string routeName, string updateTargetId) {
            if (pagedList == null)
                return AjaxPager(htmlHelper, new PagerOptions(htmlHelper), null);

            var routeValues = new {
                page = pagedList.CurrentPageIndex
            };

            var extendedAjaxOptions = new ExtendedAjaxOptions();

            if (!string.IsNullOrEmpty(updateTargetId))
                extendedAjaxOptions.UpdateTargetId = updateTargetId;

            return AjaxPager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, null, null, routeName, new PagerOptions(htmlHelper), routeValues, extendedAjaxOptions, null);
        }

        public static MvcHtmlString AjaxPager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, string routeName, object routeValues, PagerOptions pagerOptions, AjaxOptions ajaxOptions) {
            if (pagedList == null)
                return AjaxPager(htmlHelper, pagerOptions, null);

            return AjaxPager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, null, null, routeName, pagerOptions, routeValues, ajaxOptions, null);
        }

        public static MvcHtmlString AjaxPager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, string routeName, object routeValues, PagerOptions pagerOptions, AjaxOptions ajaxOptions, object htmlAttributes) {
            if (pagedList == null)
                return AjaxPager(htmlHelper, pagerOptions, RouteValueDictionaryExtensions.Convert(htmlAttributes));

            return AjaxPager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, null, null, routeName, pagerOptions, routeValues, ajaxOptions, htmlAttributes);
        }

        public static MvcHtmlString AjaxPager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, string routeName, RouteValueDictionary routeValues, PagerOptions pagerOptions, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes) {
            if (pagedList == null)
                return AjaxPager(htmlHelper, pagerOptions, htmlAttributes);

            return AjaxPager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, null, null, routeName, pagerOptions, routeValues, ajaxOptions, htmlAttributes);
        }

        public static MvcHtmlString AjaxPager<T>(this HtmlHelper htmlHelper, PagedList<T> pagedList, string actionName, string controllerName, PagerOptions pagerOptions, AjaxOptions ajaxOptions) {
            if (pagedList == null)
                return AjaxPager(htmlHelper, pagerOptions, null);

            return AjaxPager(htmlHelper, pagedList.TotalPageCount, pagedList.CurrentPageIndex, pagedList.PageSize, pagedList.TotalItemCount, actionName, controllerName, null, pagerOptions, null, ajaxOptions, null);
        }
    }
}
namespace FaraMedia.Web.Framework.UI.DataPager {
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Routing;

    internal class PagerBuilder {
        private readonly string _actionName;
        private readonly AjaxOptions _ajaxOptions;
        private readonly string _controllerName;
        private readonly int _endPageIndex = 1;
        private readonly HtmlHelper _htmlHelper;
        private readonly IDictionary<string, object> _htmlAttributes;
        private readonly int _currentPageIndex;
        private readonly int _pageSize;
        private readonly int _totalItemCount;
        private readonly PagerOptions _pagerOptions;
        private readonly string _routeName;
        private readonly RouteValueDictionary _routeValues;
        private readonly int _startPageIndex = 1;
        private readonly int _totalPageCount = 1;

        internal PagerBuilder(HtmlHelper htmlHelper, AjaxHelper ajaxHelper, PagerOptions pagerOptions, IDictionary<string, object> htmlAttributes) {
            if (pagerOptions == null)
                pagerOptions = new PagerOptions(htmlHelper);

            _htmlHelper = htmlHelper;
            _pagerOptions = pagerOptions;
            _htmlAttributes = htmlAttributes;
        }

        internal PagerBuilder(HtmlHelper htmlHelper, AjaxHelper ajaxHelper, string actionName, string controllerName, int totalPageCount, int currentPageIndex, int pageSize, int totalItemCount, PagerOptions pagerOptions, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes) {
            if (string.IsNullOrEmpty(actionName)) {
                if (ajaxHelper != null)
                    actionName = (string) ajaxHelper.ViewContext.RouteData.Values["Action"];
                else
                    actionName = (string) htmlHelper.ViewContext.RouteData.Values["Action"];
            }
            if (string.IsNullOrEmpty(controllerName)) {
                if (ajaxHelper != null)
                    controllerName = (string) ajaxHelper.ViewContext.RouteData.Values["Controller"];
                else
                    controllerName = (string) htmlHelper.ViewContext.RouteData.Values["Controller"];
            }
            if (pagerOptions == null)
                pagerOptions = new PagerOptions(htmlHelper);

            _htmlHelper = htmlHelper;
            _actionName = actionName;
            _controllerName = controllerName;
            _totalPageCount = totalPageCount;
            _currentPageIndex = currentPageIndex;
            _pageSize = pageSize;
            _totalItemCount = totalItemCount;
            _pagerOptions = pagerOptions;
            _routeName = routeName;
            _routeValues = routeValues;
            _ajaxOptions = ajaxOptions;
            _htmlAttributes = htmlAttributes;

            _startPageIndex = currentPageIndex - (pagerOptions.NumericPagerItemCount/2);
            if (_startPageIndex + pagerOptions.NumericPagerItemCount > _totalPageCount)
                _startPageIndex = _totalPageCount + 1 - pagerOptions.NumericPagerItemCount;
            if (_startPageIndex < 1)
                _startPageIndex = 1;

            _endPageIndex = _startPageIndex + _pagerOptions.NumericPagerItemCount - 1;
            if (_endPageIndex > _totalPageCount)
                _endPageIndex = _totalPageCount;
        }

        internal PagerBuilder(HtmlHelper htmlHelper, string actionName, string controllerName, int totalPageCount, int currentPageIndex, int pageSize, int totalItemCount, PagerOptions pagerOptions, string routeName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) : this(htmlHelper, null, actionName, controllerName, totalPageCount, currentPageIndex, pageSize, totalItemCount, pagerOptions, routeName, routeValues, null, htmlAttributes) {}

        internal PagerBuilder(HtmlHelper htmlHelper, string actionName, string controllerName, int totalPageCount, int currentPageIndex, int pageSize, int totalItemCount, PagerOptions pagerOptions, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes) : this(htmlHelper, null, actionName, controllerName, totalPageCount, currentPageIndex, pageSize, totalItemCount, pagerOptions, routeName, routeValues, ajaxOptions, htmlAttributes) {}

        private void AddPrevious(ICollection<PagerItem> results) {
            var pagerItem = new PagerItem(_pagerOptions.PrevPageText, _currentPageIndex - 1, _currentPageIndex == 1, PagerItemType.PrevPage);

            if (!pagerItem.Disabled || (pagerItem.Disabled && _pagerOptions.ShowDisabledPagerItems))
                results.Add(pagerItem);
        }

        private void AddFirst(ICollection<PagerItem> results) {
            var pagerItem = new PagerItem(_pagerOptions.FirstPageText, 1, _currentPageIndex == 1, PagerItemType.FirstPage);

            if (!pagerItem.Disabled || (pagerItem.Disabled && _pagerOptions.ShowDisabledPagerItems))
                results.Add(pagerItem);
        }

        private void AddMoreBefore(ICollection<PagerItem> results) {
            if (_startPageIndex <= 1 || !_pagerOptions.ShowMorePagerItems)
                return;

            var index = _startPageIndex - 1;

            if (index < 1)
                index = 1;

            var pagerItem = new PagerItem(_pagerOptions.MorePageText, index, false, PagerItemType.MorePage);

            results.Add(pagerItem);
        }

        private void AddPageNumbers(ICollection<PagerItem> results) {
            for (var pageIndex = _startPageIndex; pageIndex <= _endPageIndex; pageIndex++) {
                var text = pageIndex.ToString();

                if (pageIndex == _currentPageIndex && !string.IsNullOrEmpty(_pagerOptions.CurrentPageNumberFormatString))
                    text = string.Format(_pagerOptions.CurrentPageNumberFormatString, text);
                else if (!string.IsNullOrEmpty(_pagerOptions.PageNumberFormatString))
                    text = string.Format(_pagerOptions.PageNumberFormatString, text);

                var pagerItem = new PagerItem(text, pageIndex, false, pageIndex == _currentPageIndex ? PagerItemType.CurrentPage : PagerItemType.NumericPage);

                results.Add(pagerItem);
            }
        }

        private void AddMoreAfter(ICollection<PagerItem> results) {
            if (_endPageIndex >= _totalPageCount)
                return;

            var index = _startPageIndex + _pagerOptions.NumericPagerItemCount;

            if (index > _totalPageCount)
                index = _totalPageCount;

            var pagerItem = new PagerItem(_pagerOptions.MorePageText, index, false, PagerItemType.MorePage);

            results.Add(pagerItem);
        }

        private void AddNext(ICollection<PagerItem> results) {
            var pagerItem = new PagerItem(_pagerOptions.NextPageText, _currentPageIndex + 1, _currentPageIndex >= _totalPageCount, PagerItemType.NextPage);

            if (!pagerItem.Disabled || (pagerItem.Disabled && _pagerOptions.ShowDisabledPagerItems))
                results.Add(pagerItem);
        }

        private void AddLast(ICollection<PagerItem> results) {
            var pagerItem = new PagerItem(_pagerOptions.LastPageText, _totalPageCount, _currentPageIndex >= _totalPageCount, PagerItemType.LastPage);

            if (!pagerItem.Disabled || (pagerItem.Disabled && _pagerOptions.ShowDisabledPagerItems))
                results.Add(pagerItem);
        }

        private string GenerateUrl(int pageIndex) {
            if (pageIndex > _totalPageCount || pageIndex == _currentPageIndex)
                return null;

            var routeValues = _routeValues ?? new RouteValueDictionary();

            routeValues[_pagerOptions.PageIndexParameterName] = pageIndex;

            var rq = _htmlHelper.ViewContext.HttpContext.Request.QueryString;
            foreach (var key in rq.Keys.Cast<string>().Where(key => key != _pagerOptions.PageIndexParameterName))
                routeValues[key] = rq[key];

            if (string.IsNullOrEmpty(_routeName)) {
                routeValues["Action"] = _actionName;
                routeValues["Controller"] = _controllerName;
            }

            var urlHelper = new UrlHelper(_htmlHelper.ViewContext.RequestContext);
            return !string.IsNullOrEmpty(_routeName) ? urlHelper.RouteUrl(_routeName, routeValues) : urlHelper.RouteUrl(routeValues);
        }

        internal MvcHtmlString RenderPager() {
            if (_totalPageCount <= 1 && _pagerOptions.AutoHide)
                return null;

            var pagerItems = new List<PagerItem>();

            if (_pagerOptions.ShowFirstLast)
                AddFirst(pagerItems);

            if (_pagerOptions.ShowPrevNext)
                AddPrevious(pagerItems);

            if (_pagerOptions.ShowNumericPagerItems) {
                if (_pagerOptions.AlwaysShowFirstLastPageNumber && _startPageIndex > 1)
                    pagerItems.Add(new PagerItem("1", 1, false, PagerItemType.NumericPage));

                if (_pagerOptions.ShowMorePagerItems)
                    AddMoreBefore(pagerItems);

                AddPageNumbers(pagerItems);

                if (_pagerOptions.ShowMorePagerItems)
                    AddMoreAfter(pagerItems);

                if (_pagerOptions.AlwaysShowFirstLastPageNumber && _endPageIndex < _totalPageCount)
                    pagerItems.Add(new PagerItem(_totalPageCount.ToString(), _totalPageCount, false, PagerItemType.NumericPage));
            }

            if (_pagerOptions.ShowPrevNext)
                AddNext(pagerItems);

            if (_pagerOptions.ShowFirstLast)
                AddLast(pagerItems);

            var stringBuilder = new StringBuilder();
            if (_pagerOptions.UseJqueryAjax) {
                foreach (var pagerItem in pagerItems)
                    stringBuilder.Append(GenerateJqAjaxPagerElement(pagerItem));
            } else {
                foreach (var pagerItem in pagerItems)
                    stringBuilder.Append(GeneratePagerElement(pagerItem));
            }

            var tagBuilder = new TagBuilder(_pagerOptions.ContainerTagName);

            if (!string.IsNullOrEmpty(_pagerOptions.Id))
                tagBuilder.GenerateId(_pagerOptions.Id);
            if (!string.IsNullOrEmpty(_pagerOptions.CssClass))
                tagBuilder.AddCssClass(_pagerOptions.CssClass);

            tagBuilder.MergeAttributes(_htmlAttributes, true);

            stringBuilder.Length -= _pagerOptions.SeparatorHtml.Length;
            tagBuilder.InnerHtml += string.Format("<ul>{0}</ul>", stringBuilder);

            if (_pagerOptions.RenderDetails) {
                var startIndex = (_currentPageIndex - 1)*_pageSize;
                if (startIndex == 0)
                    startIndex = 1;

                var endIndex = _currentPageIndex*_pageSize;
                if (endIndex > _totalItemCount)
                    endIndex = _totalItemCount;

                var details = string.Format(_totalPageCount == 0 ? _pagerOptions.FormatSingleText : _pagerOptions.FormatText, startIndex, endIndex, _totalItemCount);

                tagBuilder.InnerHtml += string.Format("<p>{0}</p>", details);
            }

            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }

        private string GenerateAnchor(PagerItem pagerItem) {
            var url = GenerateUrl(pagerItem.PageIndex);
            if (_pagerOptions.UseJqueryAjax) {
                var scriptBuilder = new StringBuilder();

                if (!string.IsNullOrEmpty(_ajaxOptions.OnFailure) || !string.IsNullOrEmpty(_ajaxOptions.OnBegin) || (!string.IsNullOrEmpty(_ajaxOptions.OnComplete) && _ajaxOptions.HttpMethod.ToUpper() != "GET")) {
                    scriptBuilder.Append("$.ajax({type:\'").Append(_ajaxOptions.HttpMethod.ToUpper() == "GET" ? "get" : "post");
                    scriptBuilder.Append("\',url:$(this).attr(\'href\'),success:function(data,status,xhr){$(\'#");
                    scriptBuilder.Append(_ajaxOptions.UpdateTargetId).Append("\').html(data);}");
                    if (!string.IsNullOrEmpty(_ajaxOptions.OnFailure))
                        scriptBuilder.Append(",error:").Append(HttpUtility.HtmlAttributeEncode(_ajaxOptions.OnFailure));
                    if (!string.IsNullOrEmpty(_ajaxOptions.OnBegin))
                        scriptBuilder.Append(",beforeSend:").Append(HttpUtility.HtmlAttributeEncode(_ajaxOptions.OnBegin));
                    if (!string.IsNullOrEmpty(_ajaxOptions.OnComplete))
                        scriptBuilder.Append(",complete:").Append(HttpUtility.HtmlAttributeEncode(_ajaxOptions.OnComplete));
                    scriptBuilder.Append("});return false;");
                } else {
                    if (_ajaxOptions.HttpMethod.ToUpper() == "GET") {
                        scriptBuilder.Append("return $(\'#").Append(_ajaxOptions.UpdateTargetId);
                        scriptBuilder.Append("\').pagerLoadInto($(this)");
                        if (!string.IsNullOrEmpty(_ajaxOptions.OnComplete))
                            scriptBuilder.Append(",").Append(HttpUtility.HtmlAttributeEncode(_ajaxOptions.OnComplete));
                        scriptBuilder.Append(");");
                    } else {
                        scriptBuilder.Append("$.post($(this).attr(\'href\'), function(data) {$(\'#");
                        scriptBuilder.Append(_ajaxOptions.UpdateTargetId);
                        scriptBuilder.Append("\').html(data);});return false;");
                    }
                }
                return string.IsNullOrEmpty(url) ? string.Format("<li class=\"active\"><a>{0}</a></li>", _htmlHelper.Encode(pagerItem.Text)) : string.Format("<li><a href=\"{0}\" onclick=\"{1}\">{2}</a></li>", url, scriptBuilder, pagerItem.Text);
            }
            return string.Format("<li><a href=\"{0}\" onclick=\"window.open(this.attributes.getNamedItem('href').value,'_self')\"></a></li>", (url));
        }

        private MvcHtmlString GeneratePagerElement(PagerItem pagerItem) {
            var url = GenerateUrl(pagerItem.PageIndex);
            if (pagerItem.Disabled) {
                switch (pagerItem.Type) {
                    case PagerItemType.CurrentPage:
                        return CreateWrappedPagerElement(pagerItem, string.Format("<li class=\"active disabled\"><a>{0}</a></li>", pagerItem.Text));
                    case PagerItemType.PrevPage:
                        return CreateWrappedPagerElement(pagerItem, string.Format("<li class=\"disabled\"><a>{0}</a></li>", pagerItem.Text));
                    case PagerItemType.NextPage:
                        return CreateWrappedPagerElement(pagerItem, string.Format("<li class=\"disabled\"><a>{0}</a></li>", pagerItem.Text));
                    default:
                        return CreateWrappedPagerElement(pagerItem, string.Format("<li class=\"disabled\"><a>{0}</a></li>", pagerItem.Text));
                }
            }
            switch (pagerItem.Type) {
                case PagerItemType.CurrentPage:
                    return CreateWrappedPagerElement(pagerItem, string.Format("<li class=\"active\"><a>{0}</a></li>", pagerItem.Text));
                case PagerItemType.PrevPage:
                    return CreateWrappedPagerElement(pagerItem, string.IsNullOrEmpty(url) ? _htmlHelper.Encode(pagerItem.Text) : string.Format("<li><a href='{0}'>{1}</a></li>", url, pagerItem.Text));
                case PagerItemType.NextPage:
                    return CreateWrappedPagerElement(pagerItem, string.IsNullOrEmpty(url) ? _htmlHelper.Encode(pagerItem.Text) : string.Format("<li><a href='{0}'>{1}</a></li>", url, pagerItem.Text));
                default:
                    return CreateWrappedPagerElement(pagerItem, string.IsNullOrEmpty(url) ? _htmlHelper.Encode(pagerItem.Text) : string.Format("<li><a href='{0}'>{1}</a></li>", url, pagerItem.Text));
            }
        }

        private MvcHtmlString GenerateJqAjaxPagerElement(PagerItem pagerItem) {
            if (pagerItem.Disabled) {
                switch (pagerItem.Type) {
                    case PagerItemType.CurrentPage:
                        return CreateWrappedPagerElement(pagerItem, string.Format("<li class=\"active disabled\"><a>{0}</a></li>", pagerItem.Text));
                    case PagerItemType.PrevPage:
                        return CreateWrappedPagerElement(pagerItem, string.Format("<li class=\"disabled\"><a>{0}</a></li>", pagerItem.Text));
                    case PagerItemType.NextPage:
                        return CreateWrappedPagerElement(pagerItem, string.Format("<li class=\"disabled\"><a>{0}</a></li>", pagerItem.Text));
                    default:
                        return CreateWrappedPagerElement(pagerItem, string.Format("<li class=\"disabled\"><a>{0}</a></li>", pagerItem.Text));
                }
            }
            return CreateWrappedPagerElement(pagerItem, GenerateAnchor(pagerItem));
        }

        private MvcHtmlString CreateWrappedPagerElement(PagerItem pagerItem, string el) {
            var navStr = el;
            switch (pagerItem.Type) {
                case PagerItemType.CurrentPage:
                case PagerItemType.FirstPage:
                case PagerItemType.LastPage:
                case PagerItemType.NextPage:
                case PagerItemType.PrevPage:
                    if ((!string.IsNullOrEmpty(_pagerOptions.NavigationPagerItemWrapperFormatString) || !string.IsNullOrEmpty(_pagerOptions.PagerItemWrapperFormatString)))
                        navStr = string.Format(_pagerOptions.NavigationPagerItemWrapperFormatString ?? _pagerOptions.PagerItemWrapperFormatString, el);
                    break;
                case PagerItemType.MorePage:
                    if ((!string.IsNullOrEmpty(_pagerOptions.MorePagerItemWrapperFormatString) || !string.IsNullOrEmpty(_pagerOptions.PagerItemWrapperFormatString)))
                        navStr = string.Format(_pagerOptions.MorePagerItemWrapperFormatString ?? _pagerOptions.PagerItemWrapperFormatString, el);
                    break;
                case PagerItemType.NumericPage:
                    if (pagerItem.PageIndex == _currentPageIndex && (!string.IsNullOrEmpty(_pagerOptions.CurrentPagerItemWrapperFormatString) || !string.IsNullOrEmpty(_pagerOptions.PagerItemWrapperFormatString)))
                        navStr = string.Format(_pagerOptions.CurrentPagerItemWrapperFormatString ?? _pagerOptions.PagerItemWrapperFormatString, el);
                    else if (!string.IsNullOrEmpty(_pagerOptions.NumericPagerItemWrapperFormatString) || !string.IsNullOrEmpty(_pagerOptions.PagerItemWrapperFormatString))
                        navStr = string.Format(_pagerOptions.NumericPagerItemWrapperFormatString ?? _pagerOptions.PagerItemWrapperFormatString, el);
                    break;
            }
            return MvcHtmlString.Create(navStr + _pagerOptions.SeparatorHtml);
        }
    }
}
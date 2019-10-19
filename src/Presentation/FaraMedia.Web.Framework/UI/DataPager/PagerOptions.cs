namespace FaraMedia.Web.Framework.UI.DataPager {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Layout;
    using FaraMedia.Web.Framework.Mvc.Extensions;

    public class PagerOptions {
        public PagerOptions(HtmlHelper htmlHelper) {
            AutoHide = true;
            CssClass = "pagination";
            PageIndexParameterName = "page";
            NumericPagerItemCount = 10;
            AlwaysShowFirstLastPageNumber = false;
            ShowPrevNext = true;
            PrevPageText = htmlHelper.T(ControlHelpersConstants.Pager.Labels.Previous);
            NextPageText = htmlHelper.T(ControlHelpersConstants.Pager.Labels.Next);
            FormatText = htmlHelper.T(ControlHelpersConstants.Pager.Texts.Format);
            FormatSingleText = htmlHelper.T(ControlHelpersConstants.Pager.Texts.SingleFormat);
            ShowNumericPagerItems = true;
            ShowFirstLast = false;
            ShowMorePagerItems = true;
            MorePageText = "...";
            ShowDisabledPagerItems = true;
            SeparatorHtml = string.Empty;
            UseJqueryAjax = false;
            ContainerTagName = "div";
            MaximumPageIndexItems = 80;
            RenderDetails = true;
            InvalidPageIndexErrorMessage = "Invalid page index";
            PageIndexOutOfRangeErrorMessage = "Page index out of range";
        }

        public bool AutoHide { get; set; }

        public string PageIndexOutOfRangeErrorMessage { get; set; }

        public string InvalidPageIndexErrorMessage { get; set; }

        public string PageIndexParameterName { get; set; }

        public int MaximumPageIndexItems { get; set; }

        public string PageNumberFormatString { get; set; }

        public string ContainerTagName { get; set; }

        public string PagerItemWrapperFormatString { get; set; }

        public string CurrentPageNumberFormatString { get; set; }

        public string NumericPagerItemWrapperFormatString { get; set; }

        public string CurrentPagerItemWrapperFormatString { get; set; }

        public string NavigationPagerItemWrapperFormatString { get; set; }

        public string MorePagerItemWrapperFormatString { get; set; }

        public string PageIndexBoxWrapperFormatString { get; set; }

        public string GoToPageSectionWrapperFormatString { get; set; }

        public bool AlwaysShowFirstLastPageNumber { get; set; }

        public int NumericPagerItemCount { get; set; }

        public bool ShowPrevNext { get; set; }

        public string PrevPageText { get; set; }

        public string NextPageText { get; set; }

        public string FormatText { get; set; }

        public string FormatSingleText { get; set; }

        public bool ShowNumericPagerItems { get; set; }

        public bool ShowFirstLast { get; set; }

        public string FirstPageText { get; set; }

        public string LastPageText { get; set; }

        public bool ShowMorePagerItems { get; set; }

        public string MorePageText { get; set; }

        public string Id { get; set; }

        public string CssClass { get; set; }

        public bool ShowDisabledPagerItems { get; set; }

        public string SeparatorHtml { get; set; }

        public bool UseJqueryAjax { get; set; }

        public bool RenderDetails { get; set; }
    }
}
namespace FaraMedia.Web.Framework.UI {
    using System.Web.Mvc;

    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Web.Framework.Mvc.Extensions;

    public static class LayoutExtensions {
        public static void AddLocalizedTitleParts(this HtmlHelper htmlHelper, string key, params object[] args) {
            var part = htmlHelper.T(key, args);

            AddTitleParts(htmlHelper, part);
        }

        public static void AppendLocalizedTitleParts(this HtmlHelper htmlHelper, string key, params object[] args) {
            var part = htmlHelper.T(key, args);

            AppendTitleParts(htmlHelper, part);
        }

        public static void AddTitleParts(this HtmlHelper htmlHelper, string part) {
            var pagePartBuilder = EngineContext.Current.Resolve<IPagePartBuilder>();

            pagePartBuilder.AddTitleParts(part);
        }

        public static void AppendTitleParts(this HtmlHelper htmlHelper, string part) {
            var pagePartBuilder = EngineContext.Current.Resolve<IPagePartBuilder>();

            pagePartBuilder.AppendTitleParts(part);
        }

        public static MvcHtmlString FaraTitle(this HtmlHelper htmlHelper) {
            var pagePartBuilder = EngineContext.Current.Resolve<IPagePartBuilder>();

            return MvcHtmlString.Create(htmlHelper.Encode(pagePartBuilder.GenerateTitle()));
        }

        public static void AddBreadcrumbParts(this HtmlHelper htmlHelper, MvcHtmlString part) {
            var pagePartBuilder = EngineContext.Current.Resolve<IPagePartBuilder>();

            pagePartBuilder.AddBreadcrumbParts(part);
        }

        public static void AppendBreadcrumbParts(this HtmlHelper htmlHelper, MvcHtmlString part) {
            var pagePartBuilder = EngineContext.Current.Resolve<IPagePartBuilder>();

            pagePartBuilder.AppendBreadcrumbParts(part);
        }

        public static MvcHtmlString FaraBreadcrumb(this HtmlHelper htmlHelper) {
            var pagePartBuilder = EngineContext.Current.Resolve<IPagePartBuilder>();

            return pagePartBuilder.GenerateBreadcrumb();
        }

        public static void AddLocalizedMetaKeywordParts(this HtmlHelper htmlHelper, string key, params object[] args) {
            var part = htmlHelper.T(key, args);

            AddMetaKeywordParts(htmlHelper, part);
        }

        public static void AppendLocalizedMetaKeywordParts(this HtmlHelper htmlHelper, string key, params object[] args) {
            var part = htmlHelper.T(key, args);

            AppendMetaKeywordParts(htmlHelper, part);
        }

        public static void AddMetaKeywordParts(this HtmlHelper htmlHelper, string part) {
            var pagePartBuilder = EngineContext.Current.Resolve<IPagePartBuilder>();

            pagePartBuilder.AddMetaKeywordParts(part);
        }

        public static void AppendMetaKeywordParts(this HtmlHelper htmlHelper, string part) {
            var pagePartBuilder = EngineContext.Current.Resolve<IPagePartBuilder>();

            pagePartBuilder.AppendMetaKeywordParts(part);
        }

        public static MvcHtmlString FaraMetaKeywords(this HtmlHelper htmlHelper) {
            var pagePartBuilder = EngineContext.Current.Resolve<IPagePartBuilder>();

            return MvcHtmlString.Create(htmlHelper.Encode(pagePartBuilder.GenerateMetaKeywords()));
        }

        public static void AddLocalizedMetaDescriptionParts(this HtmlHelper htmlHelper, string key, params object[] args) {
            var part = htmlHelper.T(key, args);

            AddMetaDescriptionParts(htmlHelper, part);
        }

        public static void AppendLocalizedMetaDescriptionParts(this HtmlHelper htmlHelper, string key, params object[] args) {
            var part = htmlHelper.T(key, args);

            AppendMetaDescriptionParts(htmlHelper, part);
        }

        public static void AddMetaDescriptionParts(this HtmlHelper htmlHelper, string part) {
            var pagePartBuilder = EngineContext.Current.Resolve<IPagePartBuilder>();

            pagePartBuilder.AddMetaDescriptionParts(part);
        }

        public static void AppendMetaDescriptionParts(this HtmlHelper htmlHelper, string part) {
            var pagePartBuilder = EngineContext.Current.Resolve<IPagePartBuilder>();

            pagePartBuilder.AppendMetaDescriptionParts(part);
        }

        public static MvcHtmlString FaraMetaDescription(this HtmlHelper htmlHelper) {
            var pagePartBuilder = EngineContext.Current.Resolve<IPagePartBuilder>();

            return MvcHtmlString.Create(htmlHelper.Encode(pagePartBuilder.GenerateMetaDescription()));
        }

        public static void AddScriptParts(this HtmlHelper htmlHelper, string part) {
            var pagePartBuilder = EngineContext.Current.Resolve<IPagePartBuilder>();

            pagePartBuilder.AddScriptParts(part);
        }

        public static void AppendScriptParts(this HtmlHelper htmlHelper, string part) {
            var pagePartBuilder = EngineContext.Current.Resolve<IPagePartBuilder>();

            pagePartBuilder.AppendScriptParts(part);
        }

        public static MvcHtmlString FaraScripts(this HtmlHelper htmlHelper) {
            var pagePartBuilder = EngineContext.Current.Resolve<IPagePartBuilder>();

            return MvcHtmlString.Create(pagePartBuilder.GenerateScripts());
        }

        public static void AddCssFileParts(this HtmlHelper htmlHelper, string part) {
            var pagePartBuilder = EngineContext.Current.Resolve<IPagePartBuilder>();

            pagePartBuilder.AddCssFileParts(part);
        }

        public static void AppendCssFileParts(this HtmlHelper htmlHelper, string part) {
            var pagePartBuilder = EngineContext.Current.Resolve<IPagePartBuilder>();

            pagePartBuilder.AppendCssFileParts(part);
        }

        public static MvcHtmlString FaraCssFiles(this HtmlHelper htmlHelper) {
            var pagePartBuilder = EngineContext.Current.Resolve<IPagePartBuilder>();

            return MvcHtmlString.Create(pagePartBuilder.GenerateCssFiles());
        }

        public static void AddCanonicalUrlParts(this HtmlHelper htmlHelper, string part) {
            var pagePartBuilder = EngineContext.Current.Resolve<IPagePartBuilder>();

            pagePartBuilder.AddCanonicalUrlParts(part);
        }

        public static void AppendCanonicalUrlParts(this HtmlHelper htmlHelper, string part) {
            var pagePartBuilder = EngineContext.Current.Resolve<IPagePartBuilder>();

            pagePartBuilder.AppendCanonicalUrlParts(part);
        }

        public static MvcHtmlString FaraCanonicalUrls(this HtmlHelper htmlHelper) {
            var pagePartBuilder = EngineContext.Current.Resolve<IPagePartBuilder>();

            return MvcHtmlString.Create(pagePartBuilder.GenerateCanonicalUrls());
        }
    }
}
namespace FaraMedia.Web.Framework.UI {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;

    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Infrastructure.Extensions;
    using FaraMedia.Services.Configuration;

    public class PagePartBuilder : IPagePartBuilder {
        private readonly List<string> _titleParts;
        private readonly List<string> _metaKeywordParts;
        private readonly List<string> _metaDescriptionParts;
        private readonly List<string> _cssParts;
        private readonly List<string> _scriptParts;
        private readonly List<string> _canonicalUrlParts;
        private readonly List<MvcHtmlString> _breadcrumbParts;

        private readonly SeoSettings _seoSettings;

        public PagePartBuilder(ISeoSettingsService seoSettingsService) {
            _titleParts = new List<string>();
            _metaKeywordParts = new List<string>();
            _metaDescriptionParts = new List<string>();
            _cssParts = new List<string>();
            _scriptParts = new List<string>();
            _canonicalUrlParts = new List<string>();
            _breadcrumbParts = new List<MvcHtmlString>();

            _seoSettings = seoSettingsService.LoadSeoSettings();
        }

        public void AddTitleParts(params string[] parts) {
            AddParts(_titleParts, parts);
        }

        public void AppendTitleParts(params string[] parts) {
            AppendParts(_titleParts, parts);
        }

        public string GenerateTitle() {
            string result;
            var specificTitle = string.Join(_seoSettings.TitleSeparator, _titleParts.AsEnumerable().Reverse().ToArray());

            if (!string.IsNullOrEmpty(specificTitle))
                result = string.Join(_seoSettings.TitleSeparator, _seoSettings.DefaultTitle, specificTitle);
            else
                result = _seoSettings.DefaultTitle;

            return result;
        }

        public void AddMetaKeywordParts(params string[] parts) {
            AddParts(_metaKeywordParts, parts);
        }

        public void AppendMetaKeywordParts(params string[] parts) {
            AppendParts(_metaKeywordParts, parts);
        }

        public string GenerateMetaKeywords() {
            var metaKeyword = string.Join(", ", _metaKeywordParts.AsEnumerable().Reverse().ToArray());

            var result = !string.IsNullOrEmpty(metaKeyword) ? metaKeyword : _seoSettings.DefaultMetaKeywords;

            return result;
        }

        public void AddMetaDescriptionParts(params string[] parts) {
            AddParts(_metaDescriptionParts, parts);
        }

        public void AppendMetaDescriptionParts(params string[] parts) {
            AppendParts(_metaDescriptionParts, parts);
        }

        public string GenerateMetaDescription() {
            var metaDescription = string.Join(", ", _metaDescriptionParts.AsEnumerable().Reverse().ToArray());

            var result = !string.IsNullOrEmpty(metaDescription) ? metaDescription : _seoSettings.DefaultMetaDescription;

            return result;
        }

        public void AddCssFileParts(params string[] parts) {
            AddParts(_cssParts, parts);
        }

        public void AppendCssFileParts(params string[] parts) {
            AppendParts(_cssParts, parts);
        }

        public string GenerateCssFiles() {
            return Generate("<link href=\"{0}\" rel=\"stylesheet\" type=\"text/css\" />", _cssParts);
        }

        public void AddScriptParts(params string[] parts) {
            AddParts(_scriptParts, parts);
        }

        public void AppendScriptParts(params string[] parts) {
            AppendParts(_scriptParts, parts);
        }

        public string GenerateScripts() {
            return Generate("<script src=\"{0}\" type=\"text/javascript\"></script>", _scriptParts);
        }

        public void AddCanonicalUrlParts(params string[] parts) {
            AddParts(_canonicalUrlParts, parts);
        }

        public void AppendCanonicalUrlParts(params string[] parts) {
            AppendParts(_canonicalUrlParts, parts);
        }

        public string GenerateCanonicalUrls() {
            return Generate("<link rel=\"canonical\" href=\"{0}\" />", _canonicalUrlParts);
        }

        public void AddBreadcrumbParts(params MvcHtmlString[] parts) {
            AddParts(_breadcrumbParts, parts);
        }

        public void AppendBreadcrumbParts(params MvcHtmlString[] parts) {
            AppendParts(_breadcrumbParts, parts);
        }

        public MvcHtmlString GenerateBreadcrumb() {
            var result = new StringBuilder();

            _breadcrumbParts.Reverse();

            foreach (var breadcrumbPart in _breadcrumbParts) {
                result.Append("<li>");

                result.Append(breadcrumbPart);

                if (!_breadcrumbParts.IsLast(breadcrumbPart))
                    result.AppendFormat("<span class=\"divider\">{0}</span>", _seoSettings.BreadcrumbSeparator);

                result.Append("</li>");
            }

            return new MvcHtmlString(result.ToString());
        }

        private static void AddParts<T>(ICollection<T> collection, params T[] parts) where T : class {
            if (parts == null)
                return;

            foreach (var part in parts.Where(p => p != null))
                collection.Add(part);
        }

        private static void AppendParts<T>(IList<T> list, params T[] parts) where T : class {
            if (parts == null)
                return;

            foreach (var part in parts.Where(p => p != null))
                list.Insert(0, part);
        }

        private static string Generate(string pattern, IEnumerable<string> items) {
            var result = new StringBuilder();

            foreach (var item in items) {
                result.AppendFormat(pattern, item);
                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }
    }
}
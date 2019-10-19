namespace FaraMedia.Web.Framework.UI {
    using System.Web.Mvc;

    public interface IPagePartBuilder {
        void AddTitleParts(params string[] parts);
        void AppendTitleParts(params string[] parts);
        string GenerateTitle();

        void AddMetaKeywordParts(params string[] parts);
        void AppendMetaKeywordParts(params string[] parts);
        string GenerateMetaKeywords();

        void AddMetaDescriptionParts(params string[] parts);
        void AppendMetaDescriptionParts(params string[] parts);
        string GenerateMetaDescription();

        void AddCssFileParts(params string[] parts);
        void AppendCssFileParts(params string[] parts);
        string GenerateCssFiles();

        void AddScriptParts(params string[] parts);
        void AppendScriptParts(params string[] parts);
        string GenerateScripts();

        void AddCanonicalUrlParts(params string[] parts);
        void AppendCanonicalUrlParts(params string[] parts);
        string GenerateCanonicalUrls();

        void AddBreadcrumbParts(params MvcHtmlString[] parts);
        void AppendBreadcrumbParts(params MvcHtmlString[] parts);
        MvcHtmlString GenerateBreadcrumb();
    }
}
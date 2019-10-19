namespace FaraMedia.Web.Framework.ViewEngines.Razor {
    using System;
    using System.IO;
    using System.Web.Mvc;
    using System.Web.WebPages;

    using FaraMedia.Core;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Services.Common;
    using FaraMedia.Services.Systematic;

    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel> {
        public ICdnService Cdn { get; private set; }
        public IStringResourceService LocalizationService { get; private set; }
        public IWorkContext WorkContext { get; private set; }

        public override string Layout {
            get {
                var layout = base.Layout;

                if (!string.IsNullOrEmpty(layout)) {
                    var filename = Path.GetFileNameWithoutExtension(layout);
                    var viewResult = ViewEngines.Engines.FindView(ViewContext.Controller.ControllerContext, filename, string.Empty);

                    if (viewResult.View != null) {
                        var razorView = viewResult.View as RazorView;

                        if (razorView != null)
                            layout = razorView.ViewPath;
                    }
                }

                return layout;
            }
            set { base.Layout = value; }
        }

        public override void InitHelpers() {
            base.InitHelpers();

            Cdn = EngineContext.Current.Resolve<ICdnService>();
            LocalizationService = EngineContext.Current.Resolve<IStringResourceService>();
            WorkContext = EngineContext.Current.Resolve<IWorkContext>();
        }

        public HelperResult RenderWrappedSection(string name, object wrapperHtmlAttributes) {
            Action<TextWriter> action = delegate(TextWriter textWriter) {
                                            var htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(wrapperHtmlAttributes);
                                            var tagBuilder = new TagBuilder("div");
                                            tagBuilder.MergeAttributes(htmlAttributes);

                                            var section = RenderSection(name, false);
                                            if (section != null) {
                                                textWriter.Write(tagBuilder.ToString(TagRenderMode.StartTag));
                                                section.WriteTo(textWriter);
                                                textWriter.Write(tagBuilder.ToString(TagRenderMode.EndTag));
                                            }
                                        };
            return new HelperResult(action);
        }

        public HelperResult RenderSection(string sectionName, Func<object, HelperResult> defaultContent) {
            return IsSectionDefined(sectionName) ? RenderSection(sectionName) : defaultContent(new object());
        }

        public bool ShouldUseRtlTheme() {
            var supportRtl = WorkContext.WorkingLanguage.IsRightToLeft;

            return supportRtl;
        }
    }

    public abstract class WebViewPage : WebViewPage<dynamic> {}
}
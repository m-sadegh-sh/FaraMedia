namespace FaraMedia.FrontEnd.Administration.Renderes.Grid {
    using FaraMedia.Web.Framework.Mvc.Models;

    using MvcContrib.UI.Grid;

    public sealed class ZebraStripedTableRenderer<TModel> : HtmlTableGridRenderer<TModel> where TModel : EntityModelBase {
        private const string DEFAULT_CSS_CLASS = "zebra-striped sortable-table";

        protected override void RenderRowStart(GridRowViewData<TModel> rowData) {
            var attributes = GridModel.Sections.Row.Attributes(rowData);

            var attributeString = BuildHtmlAttributes(attributes);

            if (attributeString.Length > 0)
                attributeString = " " + attributeString;

            RenderText(string.Format("<tr{0}>", attributeString));
        }

        protected override void RenderGridStart() {
            if (!GridModel.Attributes.ContainsKey("class"))
                GridModel.Attributes["class"] = DEFAULT_CSS_CLASS;
            else
                GridModel.Attributes["class"] += string.Concat(" ", DEFAULT_CSS_CLASS);

            var attrs = BuildHtmlAttributes(GridModel.Attributes);

            if (attrs.Length > 0)
                attrs = " " + attrs;

            RenderText(string.Format("<table{0}>", attrs));
        }

        protected override void RenderEmpty() {
            RenderHeadStart();
            RenderEmptyHeaderCellStart();
            RenderHeaderCellEnd();
            RenderHeadEnd();
            RenderBodyStart();
            RenderText("<tr><td class=\"center\">" + GridModel.EmptyText + "</td></tr>");
            RenderBodyEnd();
        }
    }
}
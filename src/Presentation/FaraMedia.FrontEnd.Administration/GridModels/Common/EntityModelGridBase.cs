namespace FaraMedia.FrontEnd.Administration.GridModels.Common {
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Data.Schemas.Layout;
    using FaraMedia.FrontEnd.Administration.Renderes.Grid;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Mvc.Models;
    using FaraMedia.Web.Framework.Routing;

    using MvcContrib.UI.Grid;

    public abstract class EntityModelGridBase<TModel> : GridModel<TModel> where TModel : EntityModelBase {
        protected HtmlHelper<TModel> GenericHtmlHelper { get; private set; }

        protected EntityModelGridBase(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, string editRouteName = null, bool id = true) {
            GenericHtmlHelper = new HtmlHelper<TModel>(htmlHelper.ViewContext, new ViewPage(), htmlHelper.RouteCollection);

            Column.For(em => htmlHelper.CheckBox(em.Id.ToString(), em.IsSelected));

            if (edit) {
                Column.For(em => htmlHelper.LocalizedRouteLinkWithId(CrudSharedConstants.Commands.Edit, editRouteName, em.Id, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(CrudSharedConstants.Commands.Update));
            }

            if (id)
                Column.For(em => em.Id).Named(htmlHelper.T(EntityConstants.Fields.Id.Label));

            Empty(htmlHelper.T(CommonConstants.Messages.Empty));

            RenderUsing(new ZebraStripedTableRenderer<TModel>());
        }
    }
}
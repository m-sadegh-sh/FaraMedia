namespace FaraMedia.FrontEnd.Administration.GridModels.Billing {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Billing;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class OrderNoteModelGrid : EntityModelGridBase<OrderNoteModel> {
        public OrderNoteModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, string editRouteName = null, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool visibleForUser = true, bool note = true,
                                  bool order = true) : base(htmlHelper, isSelected, edit, editRouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (visibleForUser)
                Column.For(onm => onm.VisibleForUser).Named(htmlHelper.T(OrderNoteConstants.Fields.VisibleForUser.Label));

            if (note)
                Column.For(onm => onm.Note).Named(htmlHelper.T(OrderNoteConstants.Fields.Note.Label));

            if (order) {
                Column.For(onm => htmlHelper.LocalizedRouteLinkWithId(onm.OrderId.ToString(), BillingSectionConstants.BillingController.Edit.RouteName, onm.OrderId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(OrderNoteConstants.Fields.Order.Label));
            }
        }
    }
}
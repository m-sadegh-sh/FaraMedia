namespace FaraMedia.FrontEnd.Administration.GridModels.Billing {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.FileManagement;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Billing;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class OrderLineModelGrid : EntityModelGridBase<OrderLineModel> {
        public OrderLineModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, string editRouteName = null, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool quantity = true, bool accessTries = true, bool itemPrice = true, bool itemName = true, bool order = true, bool download = true)
            : base(htmlHelper, isSelected, edit, editRouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (quantity)
                Column.For(olm => olm.Quantity).Named(htmlHelper.T(OrderLineConstants.Fields.Quantity.Label));

            if (accessTries)
                Column.For(olm => olm.AccessTries).Named(htmlHelper.T(OrderLineConstants.Fields.AccessTries.Label));

            if (itemName)
                Column.For(olm => olm.ItemName).Named(htmlHelper.T(OrderLineConstants.Fields.ItemName.Label));

            if (itemPrice)
                Column.For(olm => olm.ItemPrice).Named(htmlHelper.T(OrderLineConstants.Fields.ItemPrice.Label));

            if (order) {
                Column.For(olm => htmlHelper.LocalizedRouteLinkWithId(olm.OrderId.ToString(), BillingSectionConstants.BillingController.Edit.RouteName, olm.OrderId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(OrderLineConstants.Fields.Order.Label));
            }

            if (download) {
                Column.For(olm => htmlHelper.LocalizedRouteLinkWithId(olm.DownloadId.ToString(), FileManagementSectionConstants.DownloadsController.Edit.RouteName, olm.DownloadId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(OrderLineConstants.Fields.Download.Label));
            }
        }
    }
}
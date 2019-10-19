namespace FaraMedia.FrontEnd.Administration.GridModels.Billing {
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Billing;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class OrderModelGrid : EntityModelGridBase<OrderModel> {
        public OrderModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, string editRouteName = null, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool orderStatus = true, bool paidDateOn = true, bool orderedBy = true, bool orderLines = true, bool orderNotes = true, bool transactionDebugs = true)
            : base(htmlHelper, isSelected, edit, editRouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (orderStatus)
                Column.For(om => om.OrderStatus).Named(htmlHelper.T(OrderConstants.Fields.OrderStatus.Label));

            if (paidDateOn)
                Column.For(om => GenericHtmlHelper.EditorFor(trap => om.PaidDate)).Named(htmlHelper.T(OrderConstants.Fields.PaidDateUtc.Label));

            if (orderedBy) {
                Column.For(om => htmlHelper.LocalizedRouteLinkWithId(om.UserFullName, SecuritySectionConstants.UsersController.Edit.RouteName, om.UserId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(OrderConstants.Fields.User.Label));
            }

            if (orderNotes) {
                Column.For(om => htmlHelper.LocalizedRouteLink(om.OrderNotesCount.ToString(), BillingSectionConstants.OrderNotesController.ListByOrderId.RouteName, RouteParameter.Add(KnownParameterNames.OrderId, om.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(OrderConstants.Fields.OrderNotes.Label));
            }

            if (orderLines) {
                Column.For(om => htmlHelper.LocalizedRouteLink(om.OrderLinesCount.ToString(), BillingSectionConstants.OrderLinesController.ListByOrderId.RouteName, RouteParameter.Add(KnownParameterNames.OrderId, om.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(OrderConstants.Fields.OrderLines.Label));
            }

            if (transactionDebugs) {
                Column.For(om => htmlHelper.LocalizedRouteLink(om.TransactionDebugsCount.ToString(), BillingSectionConstants.TransactionDebugsController.ListByOrderId.RouteName, RouteParameter.Add(KnownParameterNames.OrderId, om.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(OrderConstants.Fields.TransactionDebugs.Label));
            }
        }
    }
}
namespace FaraMedia.FrontEnd.Administration.GridModels.Billing {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Billing;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class TransactionDebugModelGrid : EntityModelGridBase<TransactionDebugModel> {
        public TransactionDebugModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, string editRouteName = null, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool transactionDebugStatus = true, bool originalStatus = true, bool authorityCode = true, bool order = true)
            : base(htmlHelper, isSelected, edit, editRouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (transactionDebugStatus)
                Column.For(tdm => tdm.TransactionDebugStatus).Named(htmlHelper.T(TransactionDebugConstants.Fields.TransactionDebugStatus.Label));

            if (originalStatus)
                Column.For(tdm => tdm.OriginalStatus).Named(htmlHelper.T(TransactionDebugConstants.Fields.OriginalStatus.Label));

            if (authorityCode)
                Column.For(tdm => tdm.AuthorityCode).Named(htmlHelper.T(TransactionDebugConstants.Fields.AuthorityCode.Label));

            if (order) {
                Column.For(tdm => htmlHelper.LocalizedRouteLinkWithId(tdm.OrderId.ToString(), BillingSectionConstants.BillingController.Edit.RouteName, tdm.OrderId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(TransactionDebugConstants.Fields.Order.Label));
            }
        }
    }
}
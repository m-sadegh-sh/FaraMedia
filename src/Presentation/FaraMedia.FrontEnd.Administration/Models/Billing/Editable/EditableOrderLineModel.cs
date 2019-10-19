namespace FaraMedia.FrontEnd.Administration.Models.Billing.Editable {
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditableOrderLineModel : EditableEntityModelBase {
        [ResourceDisplayName(OrderLineConstants.Fields.Quantity.Label)]
        [ResourceMin(OrderLineConstants.Fields.Quantity.MinValue)]
        public int Quantity { get; set; }

        [ResourceDisplayName(OrderLineConstants.Fields.AccessTries.Label)]
        [ResourceMin(OrderLineConstants.Fields.AccessTries.MinValue)]
        public int AccessTries { get; set; }

        //Code-assigned
        [ResourceDisplayName(OrderLineConstants.Fields.ItemPrice.Label)]
        public decimal ItemPrice { get; set; }

        //Code-assigned
        [ResourceDisplayName(OrderLineConstants.Fields.ItemName.Label)]
        public string ItemName { get; set; }

        //Code-assigned
        [ResourceDisplayName(OrderLineConstants.Fields.Order.Label)]
        public long OrderId { get; set; }

        //Code-assigned
        [ResourceDisplayName(OrderLineConstants.Fields.Download.Label)]
        public long DownloadId { get; set; }
    }
}
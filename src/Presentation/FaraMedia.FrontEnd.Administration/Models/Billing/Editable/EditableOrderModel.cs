namespace FaraMedia.FrontEnd.Administration.Models.Billing.Editable {
    using System.Web.Mvc;

    using FaraMedia.Core.Globalization;
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditableOrderModel : EditableEntityModelBase {
        [ResourceDisplayName(OrderConstants.Fields.OrderStatus.Label)]
        [ResourceMin(OrderConstants.Fields.OrderStatus.MinValue)]
        [ResourceMax(OrderConstants.Fields.OrderStatus.MaxValue)]
        public int OrderStatus { get; set; }

        public SelectList AvailableOrderStatuses { get; set; }

        //Code-assigned
        public MultiFormatDateTime PaidDate { get; set; }

        //Code-assigned
        [ResourceDisplayName(OrderConstants.Fields.User.Label)]
        public long UserId { get; set; }
        public string UserFullName { get; set; }
    }
}
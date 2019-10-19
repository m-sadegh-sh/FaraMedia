namespace FaraMedia.Services.Validations.Billing {
    using FaraMedia.Core.Domain.Billing;
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class OrderLineValidation : EntityValidationBase<OrderLine> {
        public OrderLineValidation() {
            Define(ol => ol.ItemId)
                .GreaterThanOrEqualTo(OrderLineConstants.Fields.ItemId.MinValue)
                .WithInvalidMinValue(OrderLineConstants.Fields.ItemId.Label,
                                     OrderLineConstants.Fields.ItemId.MinValue);

            Define(ol => ol.ItemTitle)
                .NotNullableAndNotEmpty()
                .WithRequired(OrderLineConstants.Fields.ItemTitle.Label)
                .And
                .MaxLength(OrderLineConstants.Fields.ItemTitle.Length)
                .WithInvalidLength(OrderLineConstants.Fields.ItemTitle.Label,
                                   OrderLineConstants.Fields.ItemTitle.Length);

            Define(ol => ol.Quantity)
                .GreaterThanOrEqualTo(OrderLineConstants.Fields.Quantity.MinValue)
                .WithInvalidMinValue(OrderLineConstants.Fields.Quantity.Label,
                                     OrderLineConstants.Fields.Quantity.MinValue);

            Define(ol => ol.Discount)
                .GreaterThanOrEqualTo(OrderLineConstants.Fields.Discount.MinValue)
                .WithInvalidMinValue(OrderLineConstants.Fields.Discount.Label,
                                     OrderLineConstants.Fields.Discount.MinValue);

            Define(ol => ol.Price)
                .GreaterThanOrEqualTo(OrderLineConstants.Fields.Price.MinValue)
                .WithInvalidMinValue(OrderLineConstants.Fields.Price.Label,
                                     OrderLineConstants.Fields.Price.MinValue);

            Define(ol => ol.Type);

            Define(ol => ol.Order)
                .NotNullable()
                .WithRequired(OrderLineConstants.Fields.Order.Label);

            Define(ol => ol.Download)
                .NotNullable()
                .WithRequired(OrderLineConstants.Fields.Download.Label);

            Define(ol => ol.AccessTries)
                .GreaterThanOrEqualTo(OrderLineConstants.Fields.AccessTries.MinValue)
                .WithInvalidMinValue(OrderLineConstants.Fields.AccessTries.Label,
                                     OrderLineConstants.Fields.AccessTries.MinValue);
        }
    }
}
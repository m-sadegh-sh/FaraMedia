namespace FaraMedia.Services.Validations.Billing {
    using System;

    using FaraMedia.Core.Domain.Billing;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.Services.Extensions.Billing;
    using FaraMedia.Services.Querying.Billing;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class OrderValidation : EntityValidationBase<Order> {
        public OrderValidation() {
            Define(o => o.Guid)
                .NotEmpty()
                .WithInvalidValue(OrderConstants.Fields.Guid.Label);

            Define(o => o.PlaceDateUtc);

            Define(o => o.Buyer)
                .NotNullable()
                .WithRequired(OrderConstants.Fields.Buyer.Label);

            Define(o => o.BuyerIp)
                .NotNullable()
                .WithRequired(OrderConstants.Fields.BuyerIp.Label)
                .And
                .MaxLength(OrderConstants.Fields.BuyerIp.Length)
                .WithInvalidLength(OrderConstants.Fields.BuyerIp.Label,
                                   OrderConstants.Fields.BuyerIp.Length)
                .And
                .IsIp()
                .WithInvalidFormat(OrderConstants.Fields.BuyerIp.Label);

            Define(o => o.Status)
                .NotNullable()
                .WithRequired(OrderConstants.Fields.Status.Label);

            Define(o => o.Lines);

            Define(o => o.Notes);

            Define(o => o.Requests);

            ValidateInstance.SafeBy((order, context) => {
                                        var isValid = true;

                                        var service = EngineContext.Current.Resolve<IDbService<Order, OrderQuery>>();

                                        if (service.GetByGuid(order.Guid).IsDuplicate(order)) {
                                            context.AddDuplicate<Order, Guid>(OrderConstants.Fields.Guid.Label, o => o.Guid);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}
namespace FaraMedia.Services.Validations.Billing {
    using FaraMedia.Core.Domain.Billing;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.Services.Extensions.Billing;
    using FaraMedia.Services.Querying.Billing;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class OrderStatusValidation : EntityValidationBase<OrderStatus> {
        public OrderStatusValidation() {
            Define(os => os.SystemName)
                .NotNullableAndNotEmpty()
                .WithRequired(OrderStatusConstants.Fields.SystemName.Label)
                .And
                .MaxLength(OrderStatusConstants.Fields.SystemName.Length)
                .WithInvalidLength(OrderStatusConstants.Fields.SystemName.Label,
                                   OrderStatusConstants.Fields.SystemName.Length);

            Define(os => os.DisplayName)
                .NotNullableAndNotEmpty()
                .WithRequired(OrderStatusConstants.Fields.DisplayName.Label)
                .And
                .MaxLength(OrderStatusConstants.Fields.DisplayName.Length)
                .WithInvalidLength(OrderStatusConstants.Fields.DisplayName.Label,
                                   OrderStatusConstants.Fields.DisplayName.Length);

            Define(os => os.Description)
                .MaxLength();

            Define(os => os.Orders);

            ValidateInstance.SafeBy((orderStatus, context) => {
                                        var isValid = true;

                                        var service = EngineContext.Current.Resolve<IDbService<OrderStatus, OrderStatusQuery>>();

                                        if (service.GetBySystemName(orderStatus.SystemName).IsDuplicate(orderStatus)) {
                                            context.AddDuplicate<OrderStatus, string>(OrderStatusConstants.Fields.SystemName.Label,
                                                                                      os => os.SystemName);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}
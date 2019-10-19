namespace FaraMedia.Services.Validations.Billing {
    using FaraMedia.Core.Domain.Billing;
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class OrderNoteValidation : EntityValidationBase<OrderNote> {
        public OrderNoteValidation() {
            Define(on => on.Note)
                .NotNullableAndNotEmpty()
                .WithRequired(OrderNoteConstants.Fields.Note.Label)
                .And
                .MaxLength();

            Define(on => on.IsPublic);

            Define(on => on.Order)
                .NotNullable()
                .WithRequired(OrderNoteConstants.Fields.Order.Label);
        }
    }
}
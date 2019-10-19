namespace FaraMedia.Services.Validations.Billing {
    using FaraMedia.Core.Domain.Billing;
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class TransactionResponseValidation : EntityValidationBase<TransactionResponse> {
        public TransactionResponseValidation() {
            Define(tr => tr.Request)
                .NotNullable().WithRequired(TransactionResponseConstants.Fields.Request.Label);

            Define(tr => tr.VerifyDateUtc);

            Define(tr => tr.Code)
                .NotNullableAndNotEmpty()
                .WithRequired(TransactionResponseConstants.Fields.Code.Label)
                .And
                .MaxLength();

            Define(tr => tr.SubCode)
                .MaxLength();

            Define(tr => tr.ReasonCode)
                .MaxLength();

            Define(tr => tr.ReasonDescription)
                .MaxLength();
        }
    }
}
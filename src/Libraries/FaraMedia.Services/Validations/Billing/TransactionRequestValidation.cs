namespace FaraMedia.Services.Validations.Billing {
    using FaraMedia.Core.Domain.Billing;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.Services.Extensions.Billing;
    using FaraMedia.Services.Querying.Billing;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class TransactionRequestValidation : EntityValidationBase<TransactionRequest> {
        public TransactionRequestValidation() {
            Define(tr => tr.Order)
                .NotNullable()
                .WithRequired(TransactionRequestConstants.Fields.Order.Label);

            Define(tr => tr.RequestDateUtc);

            Define(tr => tr.MerchantId)
                .NotNullableAndNotEmpty()
                .WithRequired(TransactionRequestConstants.Fields.MerchantId.Label)
                .And
                .MaxLength();

            Define(tr => tr.TransactionKey)
                .NotNullableAndNotEmpty()
                .WithRequired(TransactionRequestConstants.Fields.TransactionKey.Label)
                .And
                .MaxLength();

            Define(tr => tr.ComputedHash)
                .NotNullableAndNotEmpty()
                .WithRequired(TransactionRequestConstants.Fields.ComputedHash.Label)
                .And
                .MaxLength();

            Define(tr => tr.IsPending);
            Define(tr => tr.IsVerified);

            Define(tr => tr.Responses);

            ValidateInstance.SafeBy((transactionRequest, context) => {
                                        var isValid = true;

                                        var service = EngineContext.Current.Resolve<IDbService<TransactionRequest, TransactionRequestQuery>>();
                                 
                if (service.GetByComputedHash(transactionRequest.ComputedHash).IsDuplicate(transactionRequest)) {
                                            context.AddDuplicate<TransactionRequest, string>(TransactionRequestConstants.Fields.ComputedHash.Label,
                                                                                             tr => tr.ComputedHash);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}
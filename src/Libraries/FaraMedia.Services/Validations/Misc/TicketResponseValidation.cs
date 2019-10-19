namespace FaraMedia.Services.Validations.Misc {
    using FaraMedia.Core.Domain.Misc;
    using FaraMedia.Data.Schemas.Misc;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class TicketResponseValidation : EntityValidationBase<TicketResponse> {
        public TicketResponseValidation() {
            Define(tr => tr.Responder)
                .NotNullable()
                .WithRequired(TicketResponseConstants.Fields.Responder.Label);

            Define(tr => tr.InResponseTo)
                .NotNullable()
                .WithRequired(TicketResponseConstants.Fields.InResponseTo.Label);

            Define(tr => tr.ResponseDateUtc);

            Define(tr => tr.Subject)
                .NotNullableAndNotEmpty()
                .WithRequired(TicketResponseConstants.Fields.Subject.Label)
                .And
                .MaxLength(TicketResponseConstants.Fields.Subject.Length)
                .WithInvalidLength(TicketResponseConstants.Fields.Subject.Label,
                                   TicketResponseConstants.Fields.Subject.Length);

            Define(tr => tr.Body)
                .NotNullableAndNotEmpty()
                .WithRequired(TicketResponseConstants.Fields.Body.Label)
                .And
                .MaxLength();
        }
    }
}
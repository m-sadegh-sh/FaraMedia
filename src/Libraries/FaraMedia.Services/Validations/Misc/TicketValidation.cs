namespace FaraMedia.Services.Validations.Misc {
    using FaraMedia.Core.Domain.Misc;
    using FaraMedia.Data.Schemas.Misc;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class TicketValidation : EntityValidationBase<Ticket> {
        public TicketValidation() {
            Define(t => t.Opener)
                .NotNullable()
                .WithRequired(TicketConstants.Fields.Opener.Label);

            Define(t => t.OpenDateUtc);

            Define(t => t.Subject)
                .NotNullableAndNotEmpty()
                .WithRequired(TicketConstants.Fields.Subject.Label)
                .And
                .MaxLength(TicketConstants.Fields.Subject.Length)
                .WithInvalidLength(TicketConstants.Fields.Subject.Label,
                                   TicketConstants.Fields.Subject.Length);

            Define(t => t.Body)
                .NotNullableAndNotEmpty()
                .WithRequired(TicketConstants.Fields.Body.Label)
                .And
                .MaxLength();

            Define(t => t.Department)
                .NotNullable()
                .WithRequired(TicketConstants.Fields.Department.Label);

            Define(t => t.CheckPriority);

            Define(t => t.Status)
                .NotNullable()
                .WithRequired(TicketConstants.Fields.Status.Label);

            Define(t => t.Responses);
        }
    }
}
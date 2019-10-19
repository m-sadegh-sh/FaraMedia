namespace FaraMedia.Services.Validations.Misc {
    using FaraMedia.Core.Domain.Misc;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Misc;
    using FaraMedia.Services.Extensions.Misc;
    using FaraMedia.Services.Querying.Misc;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class TicketStatusValidation : EntityValidationBase<TicketStatus> {
        public TicketStatusValidation() {
            Define(ts => ts.SystemName)
                .NotNullableAndNotEmpty()
                .WithRequired(TicketStatusConstants.Fields.SystemName.Label)
                .And
                .MaxLength(TicketStatusConstants.Fields.SystemName.Length)
                .WithInvalidLength(TicketStatusConstants.Fields.SystemName.Label,
                                   TicketStatusConstants.Fields.SystemName.Length);

            Define(ts => ts.DisplayName)
                .NotNullableAndNotEmpty()
                .WithRequired(TicketStatusConstants.Fields.DisplayName.Label)
                .And
                .MaxLength(TicketStatusConstants.Fields.DisplayName.Length)
                .WithInvalidLength(TicketStatusConstants.Fields.DisplayName.Label,
                                   TicketStatusConstants.Fields.DisplayName.Length);

            Define(ts => ts.Description)
                .MaxLength();

            Define(ts => ts.Tickets);

            ValidateInstance.SafeBy((ticketStatus, context) => {
                                        var isValid = true;

                                        var service = EngineContext.Current.Resolve<IDbService<TicketStatus, TicketStatusQuery>>();

                                        if (service.GetBySystemName(ticketStatus.SystemName).IsDuplicate(ticketStatus)) {
                                            context.AddDuplicate<TicketStatus, string>(TicketStatusConstants.Fields.SystemName.Label,
                                                                                       ts => ts.SystemName);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}
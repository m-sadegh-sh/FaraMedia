namespace FaraMedia.Services.Validations.Misc {
    using FaraMedia.Core.Domain.Misc;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Misc;
    using FaraMedia.Services.Extensions.Misc;
    using FaraMedia.Services.Querying.Misc;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class TicketDepartmentValidation : EntityValidationBase<TicketDepartment> {
        public TicketDepartmentValidation() {
            Define(td => td.SystemName)
                .NotNullableAndNotEmpty()
                .WithRequired(TicketDepartmentConstants.Fields.SystemName.Label)
                .And
                .MaxLength(TicketDepartmentConstants.Fields.SystemName.Length)
                .WithInvalidLength(TicketDepartmentConstants.Fields.SystemName.Label,
                                   TicketDepartmentConstants.Fields.SystemName.Length);
 
            Define(td =>td.DisplayName)
                .NotNullableAndNotEmpty()
                .WithRequired(TicketDepartmentConstants.Fields.DisplayName.Label)
                .And
                .MaxLength(TicketDepartmentConstants.Fields.DisplayName.Length)
                .WithInvalidLength(TicketDepartmentConstants.Fields.DisplayName.Label,
                                   TicketDepartmentConstants.Fields.DisplayName.Length);

            Define(td => td.Description)
                .MaxLength();

            Define(td => td.Tickets);

            ValidateInstance.SafeBy((redirector, context) => {
                                        var isValid = true;

                                        var service = EngineContext.Current.Resolve<IDbService<TicketDepartment, TicketDepartmentQuery>>();

                                        if (service.GetBySystemName(redirector.SystemName).IsDuplicate(redirector)) {
                                            context.AddDuplicate<TicketDepartment, string>(TicketDepartmentConstants.Fields.SystemName.Label,
                                                                                     td => td.SystemName);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}
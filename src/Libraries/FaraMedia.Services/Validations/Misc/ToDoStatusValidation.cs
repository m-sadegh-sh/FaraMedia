namespace FaraMedia.Services.Validations.Misc {
    using FaraMedia.Core.Domain.Misc;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Misc;
    using FaraMedia.Services.Extensions.Misc;
    using FaraMedia.Services.Querying.Misc;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class ToDoStatusValidation : EntityValidationBase<ToDoStatus> {
        public ToDoStatusValidation() {
            Define(tds => tds.SystemName)
                .NotNullableAndNotEmpty()
                .WithRequired(ToDoStatusConstants.Fields.SystemName.Label)
                .And
                .MaxLength(ToDoStatusConstants.Fields.SystemName.Length)
                .WithInvalidLength(ToDoStatusConstants.Fields.SystemName.Label,
                                   ToDoStatusConstants.Fields.SystemName.Length);

            Define(tds => tds.DisplayName)
                .NotNullableAndNotEmpty()
                .WithRequired(ToDoStatusConstants.Fields.DisplayName.Label)
                .And
                .MaxLength(ToDoStatusConstants.Fields.DisplayName.Length)
                .WithInvalidLength(ToDoStatusConstants.Fields.DisplayName.Label,
                                   ToDoStatusConstants.Fields.DisplayName.Length);

            Define(tds => tds.Description)
                .MaxLength();

            Define(tds => tds.ToDos);

            ValidateInstance.SafeBy((toDoStatus, context) => {
                                        var isValid = true;

                                        var service = EngineContext.Current.Resolve<IDbService<ToDoStatus, ToDoStatusQuery>>();

                                        if (service.GetBySystemName(toDoStatus.SystemName).IsDuplicate(toDoStatus)) {
                                            context.AddDuplicate<TicketStatus, string>(ToDoStatusConstants.Fields.SystemName.Label,
                                                                                       tds => tds.SystemName);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}
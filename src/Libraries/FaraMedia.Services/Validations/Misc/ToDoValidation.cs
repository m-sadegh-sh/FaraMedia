namespace FaraMedia.Services.Validations.Misc {
    using FaraMedia.Core.Domain.Misc;
    using FaraMedia.Data.Schemas.Misc;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class ToDoValidation : EntityValidationBase<ToDo> {
        public ToDoValidation() {
            Define(td => td.Title)
                .NotNullableAndNotEmpty()
                .WithRequired(ToDoConstants.Fields.Title.Label)
                .And
                .MaxLength(ToDoConstants.Fields.Title.Length)
                .WithInvalidLength(ToDoConstants.Fields.Title.Label,
                                   ToDoConstants.Fields.Title.Length);

            Define(td => td.Description)
                .MaxLength();

            Define(td => td.Performer)
                .NotNullable()
                .WithRequired(ToDoConstants.Fields.Performer.Label);

            Define(td => td.Status)
                .NotNullable()
                .WithRequired(ToDoConstants.Fields.Status.Label);

            Define(td => td.DueDateUtc);
        }
    }
}
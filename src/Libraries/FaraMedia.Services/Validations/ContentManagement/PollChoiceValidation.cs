namespace FaraMedia.Services.Validations.ContentManagement {
    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class PollChoiceValidation : EntityValidationBase<PollChoice> {
        public PollChoiceValidation() {
            Define(pc => pc.Title)
                .NotNullableAndNotEmpty()
                .WithRequired(PollChoiceConstants.Fields.Title.Label)
                .And
                .MaxLength(PollChoiceConstants.Fields.Title.Length)
                .WithInvalidLength(PollChoiceConstants.Fields.Title.Label, 
                PollChoiceConstants.Fields.Title.Length);

            Define(pc => pc.Description)
                .MaxLength();

            Define(pc => pc.IsMultiSelection);

            Define(pc => pc.Poll)
                .NotNullable()
                .WithRequired(PollChoiceConstants.Fields.Poll.Label);

            Define(pc => pc.Items);
        }
    }
}
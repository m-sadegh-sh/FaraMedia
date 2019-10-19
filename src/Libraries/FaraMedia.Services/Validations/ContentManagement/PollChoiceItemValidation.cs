namespace FaraMedia.Services.Validations.ContentManagement {
    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class PollChoiceItemValidation : EntityValidationBase<PollChoiceItem> {
        public PollChoiceItemValidation() {
            Define(pci => pci.Text)
                .NotNullableAndNotEmpty()
                .WithRequired(PollChoiceItemConstants.Fields.Text.Label)
                .And
                .MaxLength(PollChoiceItemConstants.Fields.Text.Length)
                .WithInvalidLength(PollChoiceItemConstants.Fields.Text.Label,
                PollChoiceItemConstants.Fields.Text.Length);

            Define(pci => pci.Choice)
                .NotNullable()
                .WithRequired(PollChoiceItemConstants.Fields.Choice.Label);

            Define(pci => pci.VotingRecords);
        }
    }
}
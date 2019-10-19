namespace FaraMedia.Services.Validations.ContentManagement {
    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class GroupValidation : EntityValidationBase<Group> {
        public GroupValidation() {
            Define(g => g.Title)
                .NotNullableAndNotEmpty()
                .WithRequired(GroupConstants.Fields.Title.Label)
                .And
                .MaxLength(GroupConstants.Fields.Title.Length)
                .WithInvalidLength(GroupConstants.Fields.Title.Label,
                GroupConstants.Fields.Title.Length);

            Define(g => g.Description)
                .MaxLength();

            Define(g => g.Parent);

            Define(g => g.Children);

            Define(g => g.Pages);
        }
    }
}
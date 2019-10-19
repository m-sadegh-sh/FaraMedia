namespace FaraMedia.Services.Validations.Systematic {
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class ActivityValidation : EntityValidationBase<Activity> {
        public ActivityValidation() {
            Define(a => a.Activator)
                .NotNullable()
                .WithRequired(ActivityConstants.Fields.Activator.Label);

            Define(a => a.Type)
                .NotNullable()
                .WithRequired(ActivityConstants.Fields.Type.Label);

            Define(a => a.Comment)
                .MaxLength();

            Define(a => a.ActivationDateUtc);
        }
    }
}
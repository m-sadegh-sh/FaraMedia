namespace FaraMedia.Services.Validations.Systematic {
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Extensions.Systematic;
    using FaraMedia.Services.Querying.Systematic;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class ActivityTypeValidation : EntityValidationBase<ActivityType> {
        public ActivityTypeValidation() {
            Define(at => at.SystemName)
                .NotNullableAndNotEmpty()
                .WithRequired(ActivityTypeConstants.Fields.SystemName.Label)
                .And
                .MaxLength(ActivityTypeConstants.Fields.SystemName.Length)
                .WithInvalidLength(ActivityTypeConstants.Fields.SystemName.Label, ActivityTypeConstants.Fields.SystemName.Length);

            Define(at => at.DisplayName)
                .NotNullableAndNotEmpty()
                .WithRequired(ActivityTypeConstants.Fields.DisplayName.Label)
                .And
                .MaxLength(ActivityTypeConstants.Fields.DisplayName.Length)
                .WithInvalidLength(ActivityTypeConstants.Fields.DisplayName.Label, ActivityTypeConstants.Fields.DisplayName.Length);

            Define(at => at.Description)
                .MaxLength();

            ValidateInstance.SafeBy((activityType, context) => {
                                        var isValid = true;

                                        var service = EngineContext.Current.Resolve<IDbService<ActivityType, ActivityTypeQuery>>();

                                        if (service.GetBySystemName(activityType.SystemName).IsDuplicate(activityType)) {
                                            context.AddDuplicate<ActivityType, string>(ActivityTypeConstants.Fields.SystemName.Label,
                                                                                       at => at.SystemName);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}
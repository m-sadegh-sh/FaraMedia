namespace FaraMedia.Services.Validations.Systematic {
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Extensions.Systematic;
    using FaraMedia.Services.Querying.Systematic;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class ScheduleTaskValidation : EntityValidationBase<ScheduleTask> {
        public ScheduleTaskValidation() {
            Define(st => st.SystemName)
                .NotNullableAndNotEmpty()
                .WithRequired(ScheduleTaskConstants.Fields.SystemName.Label)
                .And
                .MaxLength(ScheduleTaskConstants.Fields.SystemName.Length)
                .WithInvalidLength(ScheduleTaskConstants.Fields.SystemName.Label,
                                   ScheduleTaskConstants.Fields.SystemName.Length);

            Define(st => st.DisplayName)
                .NotNullableAndNotEmpty()
                .WithRequired(ScheduleTaskConstants.Fields.DisplayName.Label)
                .And
                .MaxLength(ScheduleTaskConstants.Fields.DisplayName.Length)
                .WithInvalidLength(ScheduleTaskConstants.Fields.DisplayName.Label,
                                   ScheduleTaskConstants.Fields.DisplayName.Length);

            Define(st => st.TypeName)
                .NotNullableAndNotEmpty()
                .WithRequired(ScheduleTaskConstants.Fields.TypeName.Label)
                .And
                .MaxLength(ScheduleTaskConstants.Fields.TypeName.Length)
                .WithInvalidLength(ScheduleTaskConstants.Fields.TypeName.Label,
                                   ScheduleTaskConstants.Fields.TypeName.Length);

            Define(st => st.Description)
                .MaxLength();

            Define(st => st.ExecutionPriority);

            Define(st => st.IsActive);

            Define(st => st.StopOnError);

            Define(st => st.MaximumRunningSeconds)
                .GreaterThanOrEqualTo(ScheduleTaskConstants.Fields.MaximumRunningSeconds.MinValue)
                .WithInvalidMinValue(ScheduleTaskConstants.Fields.MaximumRunningSeconds.Label,
                                     ScheduleTaskConstants.Fields.MaximumRunningSeconds.MinValue);

            ValidateInstance.SafeBy((scheduleTask, context) => {
                                        var isValid = true;

                                        var service = EngineContext.Current.Resolve<IDbService<ScheduleTask, ScheduleTaskQuery>>();

                                        if (service.GetBySystemName(scheduleTask.SystemName).IsDuplicate(scheduleTask)) {
                                            context.AddDuplicate<ScheduleTask, string>(ScheduleTaskConstants.Fields.SystemName.Label,
                                                                                       st => st.SystemName);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}
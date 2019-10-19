namespace FaraMedia.Services.Validations.Configuration {
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Services.Extensions.Configuration;
    using FaraMedia.Services.Querying.Configuration;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class SettingValidation : EntityValidationBase<Setting> {
        public SettingValidation() {
            Define(s => s.Key)
                .NotNullableAndNotEmpty()
                .WithRequired(SettingConstants.Fields.Key.Label)
                .And
                .MaxLength(SettingConstants.Fields.Key.Length)
                .WithInvalidLength(SettingConstants.Fields.Key.Label,
                SettingConstants.Fields.Key.Length);

            Define(s => s.Value)
                .MaxLength();

            ValidateInstance.SafeBy((setting, context) => {
                                        var isValid = true;

                                        var service = EngineContext.Current.Resolve<IDbService<Setting,SettingQuery>>();

                                        if (service.GetByKey(setting.Key) .IsDuplicate(setting)) {
                                            context.AddDuplicate<Setting, string>(SettingConstants.Fields.Key.Label,
                                                s => s.Key);
                                          
                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}
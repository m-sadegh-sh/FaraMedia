namespace FaraMedia.Services.Validations.Systematic {
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Extensions.Systematic;
    using FaraMedia.Services.Querying.Systematic;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class ResourceValueValidation : EntityValidationBase<ResourceValue> {
        public ResourceValueValidation() {
            Define(rv => rv.Language)
                .NotNullable()
                .WithRequired(ResourceValueConstants.Fields.Language.Label);

            Define(rv => rv.Key)
                .NotNullable()
                .WithRequired(ResourceValueConstants.Fields.Key.Label);

            Define(rv => rv.Value)
                .MaxLength();

            ValidateInstance.SafeBy((resourceValue, context) => {
                                        var isValid = true;

                                        var service = EngineContext.Current.Resolve<IDbService<ResourceValue, ResourceValueQuery>>();

                                        if (service.GetByLanguageIdAndKey(resourceValue.LanguageId, resourceValue.Key.Key).IsDuplicate(resourceValue)) {
                                            context.AddDuplicate<ResourceValue, long>(ResourceValueConstants.Fields.Key.Label,
                                                                                      rv => rv.KeyId);

                                            context.AddDuplicate<ResourceValue, long>(ResourceValueConstants.Fields.Language.Label,
                                                                                      rv => rv.LanguageId);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}
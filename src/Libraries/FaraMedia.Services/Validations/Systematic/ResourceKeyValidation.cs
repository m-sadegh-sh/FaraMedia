namespace FaraMedia.Services.Validations.Systematic {
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Extensions.Systematic;
    using FaraMedia.Services.Querying.Systematic;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class ResourceKeyValidation : EntityValidationBase<ResourceKey> {
        public ResourceKeyValidation() {
            Define(rk => rk.Key)
                .NotNullableAndNotEmpty()
                .WithRequired(ResourceKeyConstants.Fields.Key.Label)
                .And
                .MaxLength(ResourceKeyConstants.Fields.Key.Length)
                .WithInvalidLength(ResourceKeyConstants.Fields.Key.Label,
                                   ResourceKeyConstants.Fields.Key.Length);

            Define(rk => rk.DisplayName)
                .NotNullableAndNotEmpty()
                .WithRequired(ResourceKeyConstants.Fields.DisplayName.Label)
                .And
                .MaxLength(ResourceKeyConstants.Fields.DisplayName.Length)
                .WithInvalidLength(ResourceKeyConstants.Fields.DisplayName.Label,
                                   ResourceKeyConstants.Fields.DisplayName.Length);

            Define(rk => rk.Description)
                .MaxLength();

            Define(rk => rk.Values);

            ValidateInstance.SafeBy((resourceKey, context) => {
                                        var isValid = true;

                                        var service = EngineContext.Current.Resolve<IDbService<ResourceKey, ResourceKeyQuery>>();

                                        if (service.GetByKey(resourceKey.Key).IsDuplicate(resourceKey)) {
                                            context.AddDuplicate<ResourceKey, string>(ResourceKeyConstants.Fields.Key.Label,
                                                                                      rk => rk.Key);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}
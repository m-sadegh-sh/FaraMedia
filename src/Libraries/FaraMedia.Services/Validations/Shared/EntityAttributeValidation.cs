namespace FaraMedia.Services.Validations.Shared {
    using FaraMedia.Core.Domain.Shared;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas;
    using FaraMedia.Data.Schemas.Shared;
    using FaraMedia.Services.Extensions.Shared;
    using FaraMedia.Services.Querying.Shared;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class EntityAttributeValidation : OwnableValidationBase<EntityAttribute> {
        public EntityAttributeValidation() {
            Define(ea => ea.Key)
                .NotNullableAndNotEmpty()
                .WithRequired(EntityAttributeConstants.Fields.Key.Label)
                .And
                .MaxLength(EntityAttributeConstants.Fields.Key.Length)
                .WithInvalidLength(EntityAttributeConstants.Fields.Key.Label,
                                   EntityAttributeConstants.Fields.Key.Length);

            Define(ea => ea.DisplayName)
                .NotNullableAndNotEmpty()
                .WithRequired(EntityAttributeConstants.Fields.DisplayName.Label)
                .And
                .MaxLength(EntityAttributeConstants.Fields.DisplayName.Length)
                .WithInvalidLength(EntityAttributeConstants.Fields.DisplayName.Label,
                                   EntityAttributeConstants.Fields.DisplayName.Length);

            Define(ea => ea.Value)
                .NotNullableAndNotEmpty()
                .WithRequired(EntityAttributeConstants.Fields.Value.Label)
                .And
                .MaxLength(EntityAttributeConstants.Fields.Value.Length)
                .WithInvalidLength(EntityAttributeConstants.Fields.Value.Label,
                                   EntityAttributeConstants.Fields.Value.Length);

            Define(ea => ea.Description)
                .MaxLength();

            ValidateInstance.SafeBy((entityAttribute, context) => {
                                        var isValid = true;

                                        var service = EngineContext.Current.Resolve<IDbService<EntityAttribute, EntityAttributeQuery>>();

                                        if (service.GetByOwnerIdAndKey(entityAttribute.OwnerId, entityAttribute.Key).IsDuplicate(entityAttribute)) {
                                            context.AddDuplicate<EntityAttribute, long>(OwnableConstantsBase<EntityAttribute>.Fields.OwnerId.Label,
                                                                                        ea => ea.OwnerId);

                                            context.AddDuplicate<EntityAttribute, string>(EntityAttributeConstants.Fields.Key.Label,
                                                                                          ea => ea.Key);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}
namespace FaraMedia.Services.Validations.Security {
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Services.Extensions.Security;
    using FaraMedia.Services.Querying.Security;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class BlockTypeValidation : EntityValidationBase<BlockType> {
        public BlockTypeValidation() {
            Define(bt => bt.SystemName)
                .NotNullableAndNotEmpty()
                .WithRequired(BlockTypeConstants.Fields.SystemName.Label)
                .And
                .MaxLength(BlockTypeConstants.Fields.SystemName.Length)
                .WithInvalidLength(BlockTypeConstants.Fields.SystemName.Label,
                                   BlockTypeConstants.Fields.SystemName.Length);

            Define(bt => bt.DisplayName)
                .NotNullableAndNotEmpty()
                .WithRequired(BlockTypeConstants.Fields.DisplayName.Label)
                .And
                .MaxLength(BlockTypeConstants.Fields.DisplayName.Length)
                .WithInvalidLength(BlockTypeConstants.Fields.DisplayName.Label,
                                   BlockTypeConstants.Fields.DisplayName.Length);

            Define(bt => bt.Description);

            Define(bt => bt.Users);

            ValidateInstance.SafeBy((role, context) => {
                                        var isValid = true;

                                        var service = EngineContext.Current.Resolve<IDbService<BlockType, BlockTypeQuery>>();

                                        if (service.GetBySystemName(role.SystemName).IsDuplicate(role)) {
                                            context.AddDuplicate<BlockType, string>(BlockTypeConstants.Fields.SystemName.Label,
                                                                                    bt => bt.SystemName);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}
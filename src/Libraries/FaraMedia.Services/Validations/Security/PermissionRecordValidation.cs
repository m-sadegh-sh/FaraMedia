namespace FaraMedia.Services.Validations.Security {
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Services.Extensions.Security;
    using FaraMedia.Services.Querying.Security;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class PermissionRecordValidation : EntityValidationBase<PermissionRecord> {
        public PermissionRecordValidation() {
            Define(pr => pr.SystemName)
                .NotNullableAndNotEmpty()
                .WithRequired(PermissionRecordConstants.Fields.SystemName.Label)
                .And
                .MaxLength(PermissionRecordConstants.Fields.SystemName.Length)
                .WithInvalidLength(PermissionRecordConstants.Fields.SystemName.Label,
                                   PermissionRecordConstants.Fields.SystemName.Length);

            Define(pr => pr.DisplayName)
                .NotNullableAndNotEmpty()
                .WithRequired(PermissionRecordConstants.Fields.DisplayName.Label)
                .And
                .MaxLength(PermissionRecordConstants.Fields.DisplayName.Length)
                .WithInvalidLength(PermissionRecordConstants.Fields.DisplayName.Label,
                                   PermissionRecordConstants.Fields.DisplayName.Length);

            Define(pr => pr.Category)
                .MaxLength(PermissionRecordConstants.Fields.Category.Length)
                .WithInvalidLength(PermissionRecordConstants.Fields.Category.Label,
                                   PermissionRecordConstants.Fields.Category.Length);

            Define(pr => pr.Description)
                .MaxLength();

            Define(pr => pr.Roles);

            ValidateInstance.SafeBy((permissionRecord, context) => {
                                        var isValid = true;

                                        var service = EngineContext.Current.Resolve<IDbService<PermissionRecord, PermissionRecordQuery>>();

                                        if (service.GetBySystemName(permissionRecord.SystemName).IsDuplicate(permissionRecord)) {
                                            context.AddDuplicate<PermissionRecord, string>(PermissionRecordConstants.Fields.SystemName.Label,
                                                                                           pr => pr.SystemName);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}
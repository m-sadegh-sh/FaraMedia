namespace FaraMedia.Services.Validations.Security {
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Services.Extensions.Security;
    using FaraMedia.Services.Querying.Security;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class RoleValidation : SecurableValidationBase<Role> {
        public RoleValidation() {
            Define(r => r.SystemName)
                .NotNullableAndNotEmpty()
                .WithRequired(RoleConstants.Fields.SystemName.Label)
                .And
                .MaxLength(RoleConstants.Fields.SystemName.Length)
                .WithInvalidLength(RoleConstants.Fields.SystemName.Label,
                                   RoleConstants.Fields.SystemName.Length);

            Define(r => r.DisplayName)
                .NotNullableAndNotEmpty()
                .WithRequired(RoleConstants.Fields.DisplayName.Label)
                .And
                .MaxLength(RoleConstants.Fields.DisplayName.Length)
                .WithInvalidLength(RoleConstants.Fields.DisplayName.Label,
                                   RoleConstants.Fields.DisplayName.Length);

            Define(r => r.Description);

            Define(r => r.IsActive);

            Define(r => r.Records);

            Define(r => r.Users);

            ValidateInstance.SafeBy((role, context) => {
                                        var isValid = true;

                                        var service = EngineContext.Current.Resolve<IDbService<Role, RoleQuery>>();

                                        if (service.GetBySystemName(role.SystemName).IsDuplicate(role)) {
                                            context.AddDuplicate<Role, string>(RoleConstants.Fields.SystemName.Label,
                                                                               r => r.SystemName);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}
namespace FaraMedia.Services.Validations.Components {
    using FaraMedia.Core.Domain.Components;
    using FaraMedia.Data.Schemas.Components;
    using FaraMedia.Services.Validations.Extensions;

    using NHibernate.Validator.Cfg.Loquacious;

    public sealed class ModificationHistoryComponentValidation : ValidationDef<ModificationHistoryComponent> {
        public ModificationHistoryComponentValidation() {
            Define(mhc => mhc.IsModified);

            Define(mhc => mhc.LastModifier)
                .NotNullable()
                .WithRequired(ModificationHistoryComponentConstants.Fields.LastModifier.Label);

            Define(mhc => mhc.LastModifierIp)
                .NotNullableAndNotEmpty()
                .WithRequired(ModificationHistoryComponentConstants.Fields.LastModifierIp.Label)
                .And
                .MaxLength(ModificationHistoryComponentConstants.Fields.LastModifierIp.Length)
                .WithInvalidLength(ModificationHistoryComponentConstants.Fields.LastModifierIp.Label,
                ModificationHistoryComponentConstants.Fields.LastModifierIp.Length)
                .And
                .IsIp()
                .WithInvalidFormat(ModificationHistoryComponentConstants.Fields.LastModifierIp.Label);

            Define(mhc => mhc.LastModifyDateUtc);
        }
    }
}
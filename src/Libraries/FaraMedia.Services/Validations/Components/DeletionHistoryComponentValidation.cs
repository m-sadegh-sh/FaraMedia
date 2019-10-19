namespace FaraMedia.Services.Validations.Components {
    using FaraMedia.Core.Domain.Components;
    using FaraMedia.Data.Schemas.Components;
    using FaraMedia.Services.Validations.Extensions;

    using NHibernate.Validator.Cfg.Loquacious;

    public sealed class DeletionHistoryComponentValidation : ValidationDef<DeletionHistoryComponent> {
        public DeletionHistoryComponentValidation() {
            Define(dhc => dhc.IsDeleted);

            Define(dhc => dhc.Deleter)
                .NotNullable()
                .WithRequired(DeletionHistoryComponentConstants.Fields.Deleter.Label);

            Define(dhc => dhc.DeleterIp)
                .NotNullableAndNotEmpty()
                .WithRequired(DeletionHistoryComponentConstants.Fields.DeleterIp.Label)
                .And
                .MaxLength(DeletionHistoryComponentConstants.Fields.DeleterIp.Length)
                .WithInvalidLength(DeletionHistoryComponentConstants.Fields.DeleterIp.Label,
                DeletionHistoryComponentConstants.Fields.DeleterIp.Length)
                .And
                .IsIp()
                .WithInvalidFormat(DeletionHistoryComponentConstants.Fields.DeleterIp.Label);

            Define(dhc => dhc.DeleteDateUtc);
        }
    }
}
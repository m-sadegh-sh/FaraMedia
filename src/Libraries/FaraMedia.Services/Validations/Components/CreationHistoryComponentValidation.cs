namespace FaraMedia.Services.Validations.Components {
    using FaraMedia.Core.Domain.Components;
    using FaraMedia.Data.Schemas.Components;
    using FaraMedia.Services.Validations.Extensions;

    using NHibernate.Validator.Cfg.Loquacious;

    public sealed class CreationHistoryComponentValidation : ValidationDef<CreationHistoryComponent> {
        public CreationHistoryComponentValidation() {
            Define(chc => chc.Creator)
                .NotNullable()
                .WithRequired(CreationHistoryComponentConstants.Fields.Creator.Label);

            Define(chc => chc.CreatorIp)
                .NotNullableAndNotEmpty()
                .WithRequired(CreationHistoryComponentConstants.Fields.CreatorIp.Label)
                .And
                .MaxLength(CreationHistoryComponentConstants.Fields.CreatorIp.Length)
                .WithInvalidLength(CreationHistoryComponentConstants.Fields.CreatorIp.Label,
                CreationHistoryComponentConstants.Fields.CreatorIp.Length)
                .And
                .IsIp()
                .WithInvalidFormat(CreationHistoryComponentConstants.Fields.CreatorIp.Label);

           Define(chc => chc.CreateDateUtc);
        }
    }
}
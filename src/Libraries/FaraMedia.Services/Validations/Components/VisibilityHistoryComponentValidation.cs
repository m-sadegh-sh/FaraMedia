namespace FaraMedia.Services.Validations.Components {
    using FaraMedia.Core.Domain.Components;
    using FaraMedia.Data.Schemas.Components;
    using FaraMedia.Services.Validations.Extensions;

    using NHibernate.Validator.Cfg.Loquacious;

    public sealed class VisibilityHistoryComponentValidation : ValidationDef<VisibilityHistoryComponent> {
        public VisibilityHistoryComponentValidation() {
            Define(vhc => vhc.IsVisible);

            Define(vhc => vhc.Visibler)
                .NotNullable()
                .WithRequired(VisibilityHistoryComponentConstants.Fields.Visibler.Label);

            Define(vhc => vhc.VisibilerIp)
                .NotNullableAndNotEmpty()
                .WithRequired(VisibilityHistoryComponentConstants.Fields.VisibilerIp.Label)
                .And
                .MaxLength(VisibilityHistoryComponentConstants.Fields.VisibilerIp.Length)
                .WithInvalidLength(VisibilityHistoryComponentConstants.Fields.VisibilerIp.Label,
                VisibilityHistoryComponentConstants.Fields.VisibilerIp.Length)
                .And
                .IsIp()
                .WithInvalidFormat(VisibilityHistoryComponentConstants.Fields.VisibilerIp.Label);

            Define(vhc => vhc.VisibleDateUtc);
        }
    }
}
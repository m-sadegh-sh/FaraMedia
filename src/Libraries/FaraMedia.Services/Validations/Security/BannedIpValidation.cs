namespace FaraMedia.Services.Validations.Security {
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class BannedIpValidation : EntityValidationBase<BannedIp> {
        public BannedIpValidation() {
            Define(bi => bi.IpAdrress)
                .NotNullableAndNotEmpty()
                .WithRequired(BannedIpConstants.Fields.IpAdrress.Label)
                .And
                .MaxLength(BannedIpConstants.Fields.IpAdrress.Length)
                .WithInvalidLength(BannedIpConstants.Fields.IpAdrress.Label,
                                   BannedIpConstants.Fields.IpAdrress.Length)
                .And
                .IsIp()
                .WithInvalidFormat(BannedIpConstants.Fields.IpAdrress.Label);

            Define(bi => bi.Reason)
                .MaxLength(BannedIpConstants.Fields.Reason.Length)
                .WithInvalidLength(BannedIpConstants.Fields.Reason.Label,
                                   BannedIpConstants.Fields.Reason.Length);

            Define(bi => bi.StartDateUtc);

            Define(bi => bi.ExpireDateUtc);
        }
    }
}
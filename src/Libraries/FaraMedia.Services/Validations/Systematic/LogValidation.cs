namespace FaraMedia.Services.Validations.Systematic {
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class LogValidation : EntityValidationBase<Log> {
        public LogValidation() {
            Define(l => l.ShortMessage)
                .MaxLength();

            Define(l => l.FullMessage)
                .MaxLength();

            Define(l => l.RequestedUrl)
                .MaxLength(LogConstants.Fields.RequestedUrl.Length)
                .WithInvalidLength(LogConstants.Fields.RequestedUrl.Label,
                                   LogConstants.Fields.RequestedUrl.Length)
                .And
                .IsUrl()
                .WithInvalidFormat(LogConstants.Fields.RequestedUrl.Label);

            Define(l => l.ReferrerUrl)
                .MaxLength(LogConstants.Fields.ReferrerUrl.Length)
                .WithInvalidLength(LogConstants.Fields.ReferrerUrl.Label,
                                   LogConstants.Fields.ReferrerUrl.Length)
                .And
                .IsUrl()
                .WithInvalidFormat(LogConstants.Fields.ReferrerUrl.Label);

            Define(l => l.Level);

            Define(l => l.LogDateUtc);

            Define(l => l.Invoker);

            Define(l => l.InvokerIp)
                .MaxLength(LogConstants.Fields.InvokerIp.Length)
                .WithInvalidLength(LogConstants.Fields.InvokerIp.Label,
                                   LogConstants.Fields.InvokerIp.Length)
                .And
                .IsIp()
                .WithInvalidFormat(LogConstants.Fields.InvokerIp.Label);
        }
    }
}
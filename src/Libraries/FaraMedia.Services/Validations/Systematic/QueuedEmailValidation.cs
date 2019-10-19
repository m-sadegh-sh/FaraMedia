namespace FaraMedia.Services.Validations.Systematic {
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class QueuedEmailValidation : EntityValidationBase<QueuedEmail> {
        public QueuedEmailValidation() {
            Define(qe => qe.From)
                .NotNullableAndNotEmpty()
                .WithRequired(QueuedEmailConstants.Fields.From.Label)
                .And
                .MaxLength(QueuedEmailConstants.Fields.From.Length)
                .WithInvalidLength(QueuedEmailConstants.Fields.From.Label,
                                   QueuedEmailConstants.Fields.From.Length)
                .And
                .IsEmail()
                .WithInvalidFormat(QueuedEmailConstants.Fields.From.Label);

            Define(qe => qe.FromName)
                .MaxLength(QueuedEmailConstants.Fields.FromName.Length)
                .WithInvalidLength(QueuedEmailConstants.Fields.FromName.Label,
                                   QueuedEmailConstants.Fields.FromName.Length);

            Define(qe => qe.To)
                .NotNullableAndNotEmpty()
                .WithRequired(QueuedEmailConstants.Fields.To.Label)
                .And
                .MaxLength(QueuedEmailConstants.Fields.To.Length)
                .WithInvalidLength(QueuedEmailConstants.Fields.To.Label,
                                   QueuedEmailConstants.Fields.To.Length)
                .And
                .IsEmail()
                .WithInvalidFormat(QueuedEmailConstants.Fields.To.Label);

            Define(qe => qe.ToName)
                .MaxLength(QueuedEmailConstants.Fields.ToName.Length)
                .WithInvalidLength(QueuedEmailConstants.Fields.ToName.Label,
                                   QueuedEmailConstants.Fields.ToName.Length);

            Define(qe => qe.Cc)
                .MaxLength();

            Define(qe => qe.Bcc)
                .MaxLength();

            Define(qe => qe.Subject)
                .NotNullableAndNotEmpty()
                .WithRequired(QueuedEmailConstants.Fields.Subject.Label)
                .And
                .MaxLength(QueuedEmailConstants.Fields.Subject.Length)
                .WithInvalidLength(QueuedEmailConstants.Fields.Subject.Label,
                                   QueuedEmailConstants.Fields.Subject.Length);

            Define(qe => qe.Body)
                .MaxLength();

            Define(qe => qe.SendPriority);

            Define(qe => qe.SendingTries);

            Define(qe => qe.SentDateUtc);

            Define(qe => qe.EmailAccount)
                .NotNullable()
                .WithRequired(QueuedEmailConstants.Fields.EmailAccount.Label);
        }
    }
}
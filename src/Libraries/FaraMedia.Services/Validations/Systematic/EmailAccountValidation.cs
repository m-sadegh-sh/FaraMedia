namespace FaraMedia.Services.Validations.Systematic {
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Extensions.Systematic;
    using FaraMedia.Services.Querying.Systematic;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class EmailAccountValidation : EntityValidationBase<EmailAccount> {
        public EmailAccountValidation() {
            Define(ea => ea.SystemName)
                .NotNullableAndNotEmpty()
                .WithRequired(EmailAccountConstants.Fields.SystemName.Label)
                .And
                .MaxLength(EmailAccountConstants.Fields.SystemName.Length)
                .WithInvalidLength(EmailAccountConstants.Fields.SystemName.Label,
                                   EmailAccountConstants.Fields.SystemName.Length);

            Define(ea => ea.DisplayName)
                .NotNullableAndNotEmpty()
                .WithRequired(EmailAccountConstants.Fields.DisplayName.Label)
                .And
                .MaxLength(EmailAccountConstants.Fields.DisplayName.Length)
                .WithInvalidLength(EmailAccountConstants.Fields.DisplayName.Label,
                                   EmailAccountConstants.Fields.DisplayName.Length);

            Define(ea => ea.Description)
                .MaxLength();

            Define(ea => ea.Email)
                .NotNullableAndNotEmpty()
                .WithRequired(EmailAccountConstants.Fields.Email.Label)
                .And
                .MaxLength(EmailAccountConstants.Fields.DisplayName.Length)
                .WithInvalidLength(EmailAccountConstants.Fields.DisplayName.Label,
                                   EmailAccountConstants.Fields.DisplayName.Length)
                .And
                .IsEmail()
                .WithInvalidFormat(EmailAccountConstants.Fields.Email.Label);

            Define(ea => ea.UserName)
                .MaxLength(EmailAccountConstants.Fields.UserName.Length)
                .WithInvalidLength(EmailAccountConstants.Fields.UserName.Label,
                                   EmailAccountConstants.Fields.UserName.Length);

            Define(ea => ea.Password)
                .MaxLength(EmailAccountConstants.Fields.Password.Length)
                .WithInvalidLength(EmailAccountConstants.Fields.Password.Label,
                                   EmailAccountConstants.Fields.Password.Length);

            Define(ea => ea.Host)
                .NotNullableAndNotEmpty()
                .WithRequired(EmailAccountConstants.Fields.Host.Label)
                .And
                .MaxLength(EmailAccountConstants.Fields.Host.Length)
                .WithInvalidLength(EmailAccountConstants.Fields.Host.Label,
                                   EmailAccountConstants.Fields.Host.Length);

            Define(ea => ea.Port)
                .GreaterThanOrEqualTo(EmailAccountConstants.Fields.Port.MinValue)
                .WithInvalidMinValue(EmailAccountConstants.Fields.Port.Label,
                                     EmailAccountConstants.Fields.Port.MinValue);

            Define(ea => ea.SslEnabled);
            Define(ea => ea.UseDefaultCredentials);

            Define(ea => ea.Templates);
            Define(ea => ea.Emails);

            ValidateInstance.SafeBy((emailAccount, context) => {
                                        var isValid = true;

                                        if (!emailAccount.UseDefaultCredentials) {
                                            if (string.IsNullOrEmpty(emailAccount.UserName)) {
                                                context.AddInvalidLength<EmailAccount, string>(EmailAccountConstants.Fields.UserName.Label,
                                                                                               EmailAccountConstants.Fields.UserName.Length,
                                                                                               ea => ea.UserName);

                                                isValid = false;
                                            }

                                            if (string.IsNullOrEmpty(emailAccount.Password)) {
                                                context.AddInvalidLength<EmailAccount, string>(EmailAccountConstants.Fields.Password.Label,
                                                                                               EmailAccountConstants.Fields.Password.Length,
                                                                                               ea => ea.Password);

                                                isValid = false;
                                            }
                                        } else {
                                            emailAccount.UserName = null;
                                            emailAccount.Password = null;
                                        }

                                        var service = EngineContext.Current.Resolve<IDbService<EmailAccount, EmailAccountQuery>>();
                                        if (service.GetBySystemName(emailAccount.SystemName).IsDuplicate(emailAccount)) {
                                            context.AddDuplicate<EmailAccount, string>(EmailAccountConstants.Fields.SystemName.Label,
                                                                                       ea => ea.SystemName);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}
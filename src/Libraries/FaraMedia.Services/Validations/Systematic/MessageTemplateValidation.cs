namespace FaraMedia.Services.Validations.Systematic {
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Extensions.Systematic;
    using FaraMedia.Services.Querying.Systematic;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class MessageTemplateValidation : EntityValidationBase<MessageTemplate> {
        public MessageTemplateValidation() {
            Define(mt => mt.SystemName)
                .NotNullableAndNotEmpty()
                .WithRequired(MessageTemplateConstants.Fields.SystemName.Label)
                .And
                .MaxLength(MessageTemplateConstants.Fields.SystemName.Length)
                .WithInvalidLength(MessageTemplateConstants.Fields.SystemName.Label,
                                   MessageTemplateConstants.Fields.SystemName.Length);

            Define(mt => mt.DisplayName)
                .NotNullableAndNotEmpty()
                .WithRequired(MessageTemplateConstants.Fields.DisplayName.Label)
                .And
                .MaxLength(MessageTemplateConstants.Fields.DisplayName.Length)
                .WithInvalidLength(MessageTemplateConstants.Fields.DisplayName.Label,
                                   MessageTemplateConstants.Fields.DisplayName.Length);

            Define(mt => mt.Description)
                .MaxLength();

            Define(mt => mt.BccEmailAddresses)
                .MaxLength();

            Define(mt => mt.Subject)
                .MaxLength(MessageTemplateConstants.Fields.Subject.Length)
                .WithInvalidLength(MessageTemplateConstants.Fields.Subject.Label,
                                   MessageTemplateConstants.Fields.Subject.Length);

            Define(mt => mt.Body)
                .MaxLength();

            Define(mt => mt.EmailAccount)
                .NotNullable()
                .WithRequired(MessageTemplateConstants.Fields.EmailAccount.Label);

            ValidateInstance.SafeBy((messageTemplate, context) => {
                                        var isValid = true;

                                        var service = EngineContext.Current.Resolve<IDbService<MessageTemplate, MessageTemplateQuery>>();

                                        if (service.GetBySystemName(messageTemplate.SystemName).IsDuplicate(messageTemplate)) {
                                            context.AddDuplicate<MessageTemplate, string>(MessageTemplateConstants.Fields.SystemName.Label,
                                                                                          mt => mt.SystemName);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}
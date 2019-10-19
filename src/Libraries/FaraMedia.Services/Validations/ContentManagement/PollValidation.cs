namespace FaraMedia.Services.Validations.ContentManagement {
    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Core.States;
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Extensions.ContentManagement;
    using FaraMedia.Services.Querying.ContentManagement;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class PollValidation : UIElementValidationBase<Poll> {
        public PollValidation() {
            Define(p => p.PlaceholderKey)
                .NotNullableAndNotEmpty()
                .WithRequired(PollConstants.Fields.PlaceholderKey.Label)
                .And
                .MaxLength(PollConstants.Fields.PlaceholderKey.Length)
                .WithInvalidLength(PollConstants.Fields.PlaceholderKey.Label,
                PollConstants.Fields.PlaceholderKey.Length);

            Define(p => p.Title)
                .NotNullableAndNotEmpty()
                .WithRequired(PollConstants.Fields.Title.Label)
                .And
                .MaxLength(PollConstants.Fields.Title.Length)
                .WithInvalidLength(PollConstants.Fields.Title.Label, 
                PollConstants.Fields.Title.Length);

            Define(p => p.Description)
                .MaxLength();

            ValidateInstance.SafeBy((poll, context) => {
                                    var isValid = true;

                                    var service = EngineContext.Current.Resolve<IDbService<Poll,PollQuery>>();

                                    if (service.GetBySystemName(poll.SystemName).IsDuplicate(poll)) {
                                        context.AddDuplicate<Poll, string>(PollConstants.Fields.SystemName.Label, 
                                            p => p.SystemName);
                                        
                                        isValid = false;
                                    }

                                    return isValid;
                                });
        }
    }
}
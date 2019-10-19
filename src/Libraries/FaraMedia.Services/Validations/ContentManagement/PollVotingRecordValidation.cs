namespace FaraMedia.Services.Validations.ContentManagement {
    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Extensions.ContentManagement;
    using FaraMedia.Services.Querying.ContentManagement;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class PollVotingRecordValidation : EntityValidationBase<PollVotingRecord> {
        public PollVotingRecordValidation() {
            Define(pvr => pvr.SelectedItem)
                .NotNullable()
                .WithRequired(PollVotingRecordConstants.Fields.SelectedItem.Label);

            ValidateInstance.SafeBy((pollVotingRecord, context) => {
                                        var isValid = true;

                                        var service = EngineContext.Current.Resolve<IDbService<PollVotingRecord, PollVotingRecordQuery>>();

                                        if (pollVotingRecord.IsTransient() || service.AlreadyVoted(pollVotingRecord.SelectedItem.Choice.PollId, pollVotingRecord.VoterId)) {
                                            context.AddLocalizedInvalid<PollVotingRecord, PollVotingRecord>(PollVotingRecordConstants.Messages.AlreadyVoted,
                                                pvr => pvr);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}
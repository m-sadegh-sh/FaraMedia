namespace FaraMedia.Services.Extensions.ContentManagement {
	using FaraMedia.Core;
	using FaraMedia.Core.Domain.ContentManagement;
	using FaraMedia.Services.Querying.ContentManagement;

	public static class PollVotingRecordServiceExtensions {
		public static bool AlreadyVoted(this IDbService<PollVotingRecord, PollVotingRecordQuery> service,
		                                long pollId,
		                                long voterId) {
			if (Neutrals.Is(pollId))
				return false;

			if (Neutrals.Is(voterId))
				return false;

			var pollVotingRecord = service.Get(pvrq => pvrq.WithPollId(pollId).
			                                                WithVoterId(voterId));

			var alreadyVoted = pollVotingRecord != null;

			return alreadyVoted;
		}
	}
}
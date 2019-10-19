namespace FaraMedia.Data.Schemas.ContentManagement {
	using FaraMedia.Core.Domain.ContentManagement;

	public sealed class PollVotingRecordConstants : EntityConstantsBase<PollVotingRecord> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(pvr => pvr.Id);
		}

		public sealed class Messages {
			public static readonly string AlreadyVoted = Helpers.Key<Messages, string>(m => AlreadyVoted);
		}

		public new sealed class Fields : EntityConstantsBase<PollVotingRecord>.Fields {
			public sealed class Voter {
				public static readonly string Label = Helpers.Label<Voter>();
			}

			public sealed class VoterIp {
				public const int Length = Constants.IpAddressLength;

				public static readonly string Label = Helpers.Label<VoterIp>();
			}

			public sealed class VoteDateUtc {
				public static readonly string Label = Helpers.Label<VoteDateUtc>();
			}

			public sealed class SelectedItem {
				public static readonly string Label = Helpers.Label<SelectedItem>();
			}
		}
	}
}
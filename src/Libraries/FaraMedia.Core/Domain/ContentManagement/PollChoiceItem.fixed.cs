namespace FaraMedia.Core.Domain.ContentManagement {
	using Iesi.Collections.Generic;

	public class PollChoiceItem : EntityBase {
		private ISet<PollVotingRecord> _votingRecords;

		public virtual string Text { get; set; }
		public virtual PollChoice Choice { get; set; }

		public virtual ISet<PollVotingRecord> VotingRecords {
			get { return _votingRecords ?? (_votingRecords = new HashedSet<PollVotingRecord>()); }
			protected set { _votingRecords = value; }
		}
	}
}
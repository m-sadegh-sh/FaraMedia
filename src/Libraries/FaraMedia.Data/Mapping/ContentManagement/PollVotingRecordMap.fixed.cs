namespace FaraMedia.Data.Mapping.ContentManagement {
	using FaraMedia.Core.Domain.ContentManagement;

	public sealed class PollVotingRecordMap : EntityMapBase<PollVotingRecord> {
		public PollVotingRecordMap() {
			ManyToOne(pvr => pvr.Voter);
			Property(pvr => pvr.VoterIp);
			Property(pvr => pvr.VoteDateUtc);
			ManyToOne(pvr => pvr.SelectedItem);
		}
	}
}
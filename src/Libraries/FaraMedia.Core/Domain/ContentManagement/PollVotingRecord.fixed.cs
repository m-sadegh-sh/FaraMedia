namespace FaraMedia.Core.Domain.ContentManagement {
	using System;

	using FaraMedia.Core.Domain.Security;

	public class PollVotingRecord : EntityBase {
		public virtual User Voter { get; set; }
		public virtual string VoterIp { get; set; }
		public virtual DateTime VoteDateUtc { get; set; }
		public virtual PollChoiceItem SelectedItem { get; set; }
	}
}
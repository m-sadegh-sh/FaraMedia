namespace FaraMedia.FrontEnd.Administration.Models.ContentManagement {
    using FaraMedia.FrontEnd.Administration.Models.Common;

    public class PollVotingRecordModel : UserContentModelBase {
        public long PollAnswerId { get; set; }
        public string PollAnswerText { get; set; }
    }
}
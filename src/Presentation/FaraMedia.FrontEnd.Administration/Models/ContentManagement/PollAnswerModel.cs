namespace FaraMedia.FrontEnd.Administration.Models.ContentManagement {
    using FaraMedia.Web.Framework.Mvc.Models;

    public class PollAnswerModel : EntityModelBase {
        public string Text { get; set; }

        public long PollId { get; set; }
        public string PollTitle { get; set; }

        public int PollVotingRecordsCount { get; set; }
    }
}
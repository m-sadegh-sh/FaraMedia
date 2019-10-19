namespace FaraMedia.FrontEnd.Administration.Models.Common {
    public class CommentModel : UserContentModelBase {
        public long OwnerId { get; set; }

        public bool Title { get; set; }
        public bool Body { get; set; }

        public long InReplyToId { get; set; }
        public string InReplyToTitle { get; set; }

        public int RepliesCount { get; set; }
    }
}
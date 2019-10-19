namespace FaraMedia.FrontEnd.Administration.Models.Common {
    public abstract class CommentableModelBase : UserContentModelBase {
        public string IsPublished { get; set; }
        public string IsDeleted { get; set; }
        public string AllowComments { get; set; }

        public short DisplayOrder { get; set; }
        public int CommentsCount { get; set; }
        public int LikesCount { get; set; }
        public int SharesCount { get; set; }
    }
}
namespace FaraMedia.FrontEnd.Administration.Models.Common.Editable {
    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Web.Framework.Mvc.Attributes;

    public abstract class EditableCommentModelBase : UserContentModelBase {
        [ResourceDisplayName(CommentConstants.Fields.Title.Label)]
        [ResourceRequired]
        [ResourceStringLength(CommentConstants.Fields.Title.Length)]
        public bool Title { get; set; }

        [ResourceDisplayName(CommentConstants.Fields.Body.Label)]
        [ResourceRequired]
        public bool Body { get; set; }
    }
}
namespace FaraMedia.FrontEnd.Administration.Models.Common.Editable {
    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Web.Framework.Mvc.Attributes;

    public abstract class EditableCommentableModelBase : EditableUserContentModelBase {
        [ResourceDisplayName(CommentableConstants.Fields.AllowComments.Hints)]
        public bool AllowComments { get; set; }
    }
}
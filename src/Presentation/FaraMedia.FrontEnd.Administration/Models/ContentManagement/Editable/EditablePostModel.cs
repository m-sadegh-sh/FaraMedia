namespace FaraMedia.FrontEnd.Administration.Models.Blogs.Editable {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.FrontEnd.Administration.Models.Common.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.Web.Framework.Mvc.Attributes;

    public class EditablePostModel : EditableCommentableModelBase {
        [ResourceDisplayName(PostConstants.Fields.Title.Label)]
        [ResourceRequired]
        [ResourceStringLength(PostConstants.Fields.Title.Length)]
        public string Title { get; set; }

        [ResourceDisplayName(PostConstants.Fields.Body.Label)]
        [ResourceRequired]
        public string Body { get; set; }

        public EditableMetadataComponentModel Metadata { get; set; }

        [ResourceDisplayName(PostConstants.Fields.Blog.Label)]
        [ResourceMin(1)]
        public long BlogId { get; set; }
        public SelectList AvailableBlogs { get; set; }
    }
}
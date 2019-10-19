namespace FaraMedia.FrontEnd.Administration.Models.Blogs.Editable {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditableTagModel : EditableEntityModelBase {
        [ResourceDisplayName(TagConstants.Fields.Text.Label)]
        [ResourceRequired]
        [ResourceStringLength(TagConstants.Fields.Text.Length)]
        public string Text { get; set; }

        public EditableMetadataComponentModel Metadata { get; set; }

        [ResourceDisplayName(TagConstants.Fields.Blog.Label)]
        [ResourceMin(1)]
        public long BlogId { get; set; }
        public SelectList AvailableBlogs { get; set; }
    }
}
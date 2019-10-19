namespace FaraMedia.FrontEnd.Administration.Models.Blogs.Editable {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditableBlogModel : EditableEntityModelBase {
        [ResourceDisplayName(BlogConstants.Fields.IsActive.Label)]
        public bool IsActive { get; set; }

        [ResourceDisplayName(BlogConstants.Fields.Name.Label)]
        [ResourceRequired]
        [ResourceStringLength(BlogConstants.Fields.Name.Length)]
        public string Name { get; set; }

        public EditableMetadataComponentModel Metadata { get; set; }

        [ResourceDisplayName(BlogConstants.Fields.User.Label)]
        [ResourceMin(1)]
        public long UserId { get; set; }

        public SelectList AvailableUsers { get; set; }
    }
}
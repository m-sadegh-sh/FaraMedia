namespace FaraMedia.FrontEnd.Administration.Models.Components.Editable {
    using FaraMedia.Data.Schemas.Components;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models;

    public class EditableMetadataComponentModel : ModelBase {
        [ResourceDisplayName(MetadataComponentConstants.Fields.Title.Label)]
        [ResourceStringLength(MetadataComponentConstants.Fields.Title.Length)]
        public string Title { get; set; }

        [ResourceDisplayName(MetadataComponentConstants.Fields.Slug.Label)]
        [ResourceStringLength(MetadataComponentConstants.Fields.Slug.Length)]
        public string Slug { get; set; }

        [ResourceDisplayName(MetadataComponentConstants.Fields.Keywords.Label)]
        [ResourceStringLength(MetadataComponentConstants.Fields.Keywords.Length)]
        public string Keywords { get; set; }

        [ResourceDisplayName(MetadataComponentConstants.Fields.Description.Label)]
        [ResourceStringLength(MetadataComponentConstants.Fields.Description.Length)]
        public string Description { get; set; }
    }
}
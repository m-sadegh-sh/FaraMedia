namespace FaraMedia.FrontEnd.Administration.Models.ContentManagement.Editable {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditableCategoryModel : EditableEntityModelBase {
        [ResourceDisplayName(CategoryConstants.Fields.Title.Label)]
        [ResourceRequired]
        [ResourceStringLength(CategoryConstants.Fields.Title.Length)]
        public string Title { get; set; }

        public EditableMetadataComponentModel Metadata { get; set; }
        
        [ResourceDisplayName(CategoryConstants.Fields.Parent.Label)]
        [ResourceMin(1)]
        public long? ParentId { get; set; }
        public SelectList AllParents { get; set; }
    }
}
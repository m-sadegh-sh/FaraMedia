namespace FaraMedia.FrontEnd.Administration.Models.ContentManagement.Editable {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditableGroupModel : EditableEntityModelBase {
        [ResourceDisplayName(GroupConstants.Fields.Title.Label)]
        [ResourceRequired]
        [ResourceStringLength(GroupConstants.Fields.Title.Length)]
        public string Title { get; set; }

        public EditableMetadataComponentModel Metadata { get; set; }

        [ResourceDisplayName(GroupConstants.Fields.Parent.Label)]
        [ResourceMin(1)]
        public long ParentId { get; set; }
        public SelectList AvailableParents { get; set; }
    }
}
namespace FaraMedia.FrontEnd.Administration.Models.ContentManagement.Editable {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditablePageModel : EditableEntityModelBase {
        [ResourceDisplayName(PageConstants.Fields.Title.Label)]
        [ResourceRequired]
        [ResourceStringLength(PageConstants.Fields.Title.Length)]
        public string Title { get; set; }

        [ResourceDisplayName(PageConstants.Fields.Body.Label)]
        public string Body { get; set; }

        public EditableMetadataComponentModel Metadata { get; set; }

        [ResourceDisplayName(PageConstants.Fields.Group.Label)]
        [ResourceMin(1)]
        public long GroupId { get; set; }
        public SelectList AvailableGroups { get; set; }
    }
}
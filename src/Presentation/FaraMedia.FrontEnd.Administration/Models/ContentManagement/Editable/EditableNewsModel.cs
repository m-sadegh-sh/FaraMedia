namespace FaraMedia.FrontEnd.Administration.Models.ContentManagement.Editable {
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.FrontEnd.Administration.Models.Common.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.Web.Framework.Mvc.Attributes;

    public class EditableNewsModel : EditableCommentableModelBase {
        [ResourceDisplayName(NewsConstants.Fields.Title.Label)]
        [ResourceRequired]
        [ResourceStringLength(NewsConstants.Fields.Title.Length)]
        public string Title { get; set; }

        [ResourceDisplayName(NewsConstants.Fields.Short.Label)]
        [ResourceRequired]
        [ResourceStringLength(NewsConstants.Fields.Short.Length)]
        [DataType(DataType.MultilineText)]
        public string Short { get; set; }

        [ResourceDisplayName(NewsConstants.Fields.Full.Label)]
        [ResourceRequired]
        [DataType(DataType.MultilineText)]
        public string Full { get; set; }

        public EditableMetadataComponentModel Metadata { get; set; }

        [ResourceDisplayName(NewsConstants.Fields.Category.Label)]
        [ResourceMin(1)]
        public long CategoryId { get; set; }
        public SelectList AvailableCategories { get; set; }
    }
}
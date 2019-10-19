namespace FaraMedia.FrontEnd.Administration.Models.Fundamentals.Editable {
    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.FrontEnd.Administration.Models.Common.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.Web.Framework.Mvc.Attributes;

    public class EditableGenreModel : EditableCommentableModelBase {
        [ResourceDisplayName(GenreConstants.Fields.Title.Label)]
        [ResourceRequired]
        [ResourceStringLength(GenreConstants.Fields.Title.Length)]
        public string Title { get; set; }

        [ResourceDisplayName(GenreConstants.Fields.Description.Label)]
        public string Description { get; set; }

        public EditableMetadataComponentModel Metadata { get; set; }
    }
}
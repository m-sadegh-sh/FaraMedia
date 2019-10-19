namespace FaraMedia.FrontEnd.Administration.Models.Fundamentals.Editable {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.FrontEnd.Administration.Models.Common.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.Web.Framework.Mvc.Attributes;

    public class EditableArtistModel : EditableCommentableModelBase {
        [ResourceDisplayName(ArtistConstants.Fields.BirthDateUtc.Label)]
        [ResourceRequired]
        [ResourceMin(1)]
        public int BirthDateDay { get; set; }

        [ResourceRequired]
        [ResourceMin(1)]
        public int BirthDateMonth { get; set; }

        [ResourceRequired]
        [ResourceMin(1)]
        public int BirthDateYear { get; set; }

        [ResourceDisplayName(ArtistConstants.Fields.FullName.Label)]
        [ResourceRequired]
        [ResourceStringLength(ArtistConstants.Fields.FullName.Length)]
        public string FullName { get; set; }

        [ResourceDisplayName(ArtistConstants.Fields.AlternativeName.Label)]
        [ResourceStringLength(ArtistConstants.Fields.AlternativeName.Length)]
        public string AlternativeName { get; set; }

        [ResourceDisplayName(ArtistConstants.Fields.HomeTown.Label)]
        [ResourceStringLength(ArtistConstants.Fields.HomeTown.Length)]
        public string HomeTown { get; set; }

        [ResourceDisplayName(ArtistConstants.Fields.Biography.Label)]
        public string Biography { get; set; }

        public EditableMetadataComponentModel Metadata { get; set; }

        [ResourceDisplayName(ArtistConstants.Fields.Facebook.Label)]
        [ResourceStringLength(ArtistConstants.Fields.Facebook.Length)]
        [ResourceUrl]
        public string FacebookTargetUrl { get; set; }

        [ResourceDisplayName(ArtistConstants.Fields.Avatar.Label)]
        [ResourceMin(1)]
        public long? AvatarId { get; set; }

        public SelectList AvailableAvatars { get; set; }
    }
}
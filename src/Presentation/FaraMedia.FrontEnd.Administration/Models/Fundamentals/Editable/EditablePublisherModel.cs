namespace FaraMedia.FrontEnd.Administration.Models.Fundamentals.Editable {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.FrontEnd.Administration.Models.Common.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.Web.Framework.Mvc.Attributes;

    public class EditablePublisherModel : EditableCommentableModelBase {
        [ResourceDisplayName(PublisherConstants.Fields.Name.Label)]
        [ResourceRequired]
        [ResourceStringLength(PublisherConstants.Fields.Name.Length)]
        public string Name { get; set; }

        [ResourceDisplayName(PublisherConstants.Fields.Ceo.Label)]
        [ResourceStringLength(PublisherConstants.Fields.Ceo.Length)]
        public string Ceo { get; set; }

        [ResourceDisplayName(PublisherConstants.Fields.RegisterationNumber.Label)]
        [ResourceStringLength(PublisherConstants.Fields.RegisterationNumber.Length)]
        public string RegisterationNumber { get; set; }

        [ResourceDisplayName(PublisherConstants.Fields.Email.Label)]
        [ResourceStringLength(PublisherConstants.Fields.Email.Length)]
        [ResourceEmail]
        public string Email { get; set; }

        [ResourceDisplayName(PublisherConstants.Fields.History.Label)]
        public string History { get; set; }

        public EditableMetadataComponentModel Metadata { get; set; }

        [ResourceDisplayName(PublisherConstants.Fields.Website.Label)]
        [ResourceStringLength(PublisherConstants.Fields.Website.Length)]
        [ResourceUrl]
        public string WebsiteTargetUrl { get; set; }

        [ResourceDisplayName(PublisherConstants.Fields.Logo.Label)]
        [ResourceMin(1)]
        public long? LogoId { get; set; }

        public SelectList AvailableLogos { get; set; }
    }
}
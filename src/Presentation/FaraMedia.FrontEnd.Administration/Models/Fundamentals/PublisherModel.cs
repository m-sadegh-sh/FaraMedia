namespace FaraMedia.FrontEnd.Administration.Models.Fundamentals {
    using FaraMedia.FrontEnd.Administration.Models.Common;
    using FaraMedia.FrontEnd.Administration.Models.Components;

    public class PublisherModel : CommentableModelBase {
        public string Name { get; set; }
        public string Ceo { get; set; }
        public string RegisterationNumber { get; set; }
        public string Email { get; set; }
        public string History { get; set; }

        public MetadataComponentModel Metadata { get; set; }

        public long WebsiteId { get; set; }
        public string WebsiteTargetUrl { get; set; }

        public long LogoId { get; set; }
        public string LogoFileName { get; set; }

        public int TracksCount { get; set; }
    }
}
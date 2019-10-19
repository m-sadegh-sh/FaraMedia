namespace FaraMedia.FrontEnd.Administration.Models.Miscellaneous.Editable {
    using FaraMedia.Data.Schemas.Miscellaneous;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditableRedirectorModel : EditableEntityModelBase {
        [ResourceDisplayName(RedirectorConstants.Fields.UsageTimes.Label)]
        [ResourceMin(1)]
        public int UsageTimes { get; set; }

        [ResourceDisplayName(RedirectorConstants.Fields.TargetUrl.Label)]
        [ResourceRequired]
        [ResourceStringLength(RedirectorConstants.Fields.TargetUrl.Length)]
        [ResourceUrl]
        public string TargetUrl { get; set; }

        [ResourceDisplayName(RedirectorConstants.Fields.Slug.Label)]
        [ResourceStringLength(RedirectorConstants.Fields.Slug.Length)]
        [ResourceSlug]
        public string Slug { get; set; }

        [ResourceDisplayName(RedirectorConstants.Fields.Description.Label)]
        public string Description { get; set; }
    }
}
namespace FaraMedia.FrontEnd.Administration.Models.Systematic.Editable {
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditableActivityTypeModel : EditableEntityModelBase {
        [ResourceDisplayName(ActivityTypeConstants.Fields.SystematicKeyword.Label)]
        [ResourceRequired]
        [ResourceStringLength(ActivityTypeConstants.Fields.SystematicKeyword.Length)]
        public string SystemKeyword { get; set; }

        [ResourceDisplayName(ActivityTypeConstants.Fields.Name.Label)]
        [ResourceRequired]
        [ResourceStringLength(ActivityTypeConstants.Fields.Name.Length)]
        public string Name { get; set; }
    }
}
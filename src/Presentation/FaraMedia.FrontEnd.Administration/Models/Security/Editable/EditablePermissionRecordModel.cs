namespace FaraMedia.FrontEnd.Administration.Models.Security.Editable {
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditablePermissionRecordModel : EditableEntityModelBase {
        [ResourceDisplayName(PermissionRecordConstants.Fields.SystematicName.Label)]
        [ResourceRequired]
        [ResourceStringLength(PermissionRecordConstants.Fields.SystematicName.Length)]
        public string SystemName { get; set; }

        [ResourceDisplayName(PermissionRecordConstants.Fields.Name.Label)]
        [ResourceRequired]
        [ResourceStringLength(PermissionRecordConstants.Fields.Name.Length)]
        public string Name { get; set; }

        [ResourceDisplayName(PermissionRecordConstants.Fields.Category.Label)]
        [ResourceStringLength(PermissionRecordConstants.Fields.Category.Length)]
        public string Category { get; set; }
    }
}
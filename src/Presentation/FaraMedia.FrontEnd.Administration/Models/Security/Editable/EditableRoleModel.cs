namespace FaraMedia.FrontEnd.Administration.Models.Security.Editable {
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditableRoleModel : EditableEntityModelBase {
        [ResourceDisplayName(RoleConstants.Fields.IsSystemRole.Label)]
        public bool IsSystemRole { get; set; }

        [ResourceDisplayName(RoleConstants.Fields.SystematicName.Label)]
        [ResourceRequired]
        [ResourceStringLength(RoleConstants.Fields.SystematicName.Length)]
        public string SystemName { get; set; }

        [ResourceDisplayName(RoleConstants.Fields.Name.Label)]
        [ResourceRequired]
        [ResourceStringLength(RoleConstants.Fields.Name.Length)]
        public string Name { get; set; }
    }
}
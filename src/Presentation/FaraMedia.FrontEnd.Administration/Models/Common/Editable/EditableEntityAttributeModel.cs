namespace FaraMedia.FrontEnd.Administration.Models.Common.Editable {
    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditableEntityAttributeModel : EditableEntityModelBase
    {
        //Code-assigned
        [ResourceDisplayName(EntityAttributeConstants.Fields.OwnerId.Label)]
        public long OwnerId { get; set; }

        [ResourceDisplayName(EntityAttributeConstants.Fields.Key.Label)]
        [ResourceRequired]
        [ResourceStringLength(EntityAttributeConstants.Fields.Key.Length)]
        public string Key { get; set; }

        [ResourceDisplayName(EntityAttributeConstants.Fields.Value.Label)]
        [ResourceRequired]
        [ResourceStringLength(EntityAttributeConstants.Fields.Value.Length)]
        public string Value { get; set; }
    }
}
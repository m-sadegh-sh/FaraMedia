namespace FaraMedia.FrontEnd.Administration.Models.Security.Editable {
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditableBannedIpModel : EditableEntityModelBase {
        [ResourceDisplayName(BannedIpConstants.Fields.ExpireDateUtc.Label)]
        [ResourceRequired]
        [ResourceMin(1)]
        public int ExpireDateDay { get; set; }

        [ResourceRequired]
        [ResourceMin(1)]
        public int ExpireDateMonth { get; set; }

        [ResourceRequired]
        [ResourceMin(1)]
        public int ExpireDateYear { get; set; }

        [ResourceDisplayName(BannedIpConstants.Fields.IpAdrress.Label)]
        [ResourceRequired]
        [ResourceStringLength(BannedIpConstants.Fields.IpAdrress.Length)]
        [ResourceIp]
        public string IpAdrress { get; set; }

        [ResourceDisplayName(BannedIpConstants.Fields.Reason.Label)]
        [ResourceStringLength(BannedIpConstants.Fields.Reason.Length)]
        public string Reason { get; set; }
    }
}
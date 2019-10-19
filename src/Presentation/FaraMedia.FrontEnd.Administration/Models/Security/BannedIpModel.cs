namespace FaraMedia.FrontEnd.Administration.Models.Security {
    using FaraMedia.Core.Globalization;
    using FaraMedia.Web.Framework.Mvc.Models;

    public class BannedIpModel : EntityModelBase {
        public MultiFormatDateTime ExpireDate { get; set; }

        public string IpAdrress { get; set; }
        public string Reason { get; set; }
    }
}
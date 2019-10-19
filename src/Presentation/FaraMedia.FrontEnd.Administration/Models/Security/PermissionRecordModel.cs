namespace FaraMedia.FrontEnd.Administration.Models.Security {
    using FaraMedia.Web.Framework.Mvc.Models;

    public class PermissionRecordModel : EntityModelBase {
        public string SystemName { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public int RolesCount { get; set; }
    }
}
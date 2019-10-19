namespace FaraMedia.FrontEnd.Administration.Models.Security {
    using FaraMedia.Web.Framework.Mvc.Models;

    public class RoleModel : EntityModelBase {
        public string IsSystemRole { get; set; }
        public string SystemName { get; set; }
        public string Name { get; set; }

        public int PermissionRecordsCount { get; set; }
        public int UsersCount { get; set; }
    }
}
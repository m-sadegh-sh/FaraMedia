namespace FaraMedia.FrontEnd.Administration.Models.Common {
    using FaraMedia.Web.Framework.Mvc.Models;

    public class EntityAttributeModel : EntityModelBase {
        public long OwnerId { get; set; }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}
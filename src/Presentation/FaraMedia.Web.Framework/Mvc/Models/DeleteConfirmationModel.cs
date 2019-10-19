namespace FaraMedia.Web.Framework.Mvc.Models {
    public class DeleteConfirmationModel : ModelBase {
        public long EntityId { get; set; }
        public string TemporarilyDeletionUrl { get; set; }
        public string PermanentlyDeletionUrl { get; set; }
    }
}
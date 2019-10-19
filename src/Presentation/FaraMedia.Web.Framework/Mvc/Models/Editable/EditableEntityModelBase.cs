namespace FaraMedia.Web.Framework.Mvc.Models.Editable {
    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Web.Framework.Mvc.Attributes;

    public class EditableEntityModelBase : ModelBase {
        //[ResourceDisplayName(EntityConstants.Fields.IsPublished.Hints)]
        //public bool IsPublished { get; set; }

        //[ResourceDisplayName(EntityConstants.Fields.IsDeleted.Hints)]
        //public bool IsDeleted { get; set; }

        public long Id { get; set; }

        //[ResourceDisplayName(EntityConstants.Fields.DisplayOrder.Label)]
        //public int DisplayOrder { get; set; }
    }
}
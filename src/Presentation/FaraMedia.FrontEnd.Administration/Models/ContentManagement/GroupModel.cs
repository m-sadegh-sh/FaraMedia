namespace FaraMedia.FrontEnd.Administration.Models.ContentManagement {
    using FaraMedia.FrontEnd.Administration.Models.Components;
    using FaraMedia.Web.Framework.Mvc.Models;

    public class GroupModel : EntityModelBase {
        public string Title { get; set; }

        public MetadataComponentModel Metadata { get; set; }

        public long ParentId { get; set; }
        public string ParentTitle { get; set; }

        public int ChildsCount { get; set; }
        public int PagesCount { get; set; }
    }
}
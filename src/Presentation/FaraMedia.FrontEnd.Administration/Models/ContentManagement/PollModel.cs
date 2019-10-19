namespace FaraMedia.FrontEnd.Administration.Models.ContentManagement {
    using FaraMedia.Core.Globalization;
    using FaraMedia.FrontEnd.Administration.Models.Common;
    using FaraMedia.FrontEnd.Administration.Models.Components;
    using FaraMedia.Web.Framework.Mvc.Models;

    public class PollModel : CommentableModelBase {
        public string ShowOnHomePage { get; set; }
        public string IsMultiSelection { get; set; }

        public MultiFormatDateTime StartDate { get; set; }
        public MultiFormatDateTime EndDate { get; set; }

        public string SystemKeyword { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public MetadataComponentModel Metadata { get; set; }

        public int PollAnswersCount { get; set; }
    }
}
namespace FaraMedia.FrontEnd.Administration.Models.ContentManagement.Editable {
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditablePollModel : EditableEntityModelBase {
        [ResourceDisplayName(PollConstants.Fields.ShowOnHomePage.Label)]
        public bool ShowOnHomePage { get; set; }

        [ResourceDisplayName(PollConstants.Fields.IsMultiSelection.Label)]
        public bool IsMultiSelection { get; set; }

        [ResourceDisplayName(PollConstants.Fields.StartDateOnUtc.Label)]
        [ResourceRequired]
        [ResourceMin(1)]
        public int StartDateOnDay { get; set; }

        [ResourceRequired]
        [ResourceMin(1)]
        public int StartDateOnMonth { get; set; }

        [ResourceRequired]
        [ResourceMin(1)]
        public int StartDateOnYear { get; set; }

        [ResourceDisplayName(PollConstants.Fields.EndDateOnUtc.Label)]
        [ResourceRequired]
        [ResourceMin(1)]
        public int EndDateOnDay { get; set; }

        [ResourceRequired]
        [ResourceMin(1)]
        public int EndDateOnMonth { get; set; }

        [ResourceRequired]
        [ResourceMin(1)]
        public int EndDateOnYear { get; set; }

        [ResourceDisplayName(PollConstants.Fields.SystematicKeyword.Label)]
        [ResourceRequired]
        [ResourceStringLength(PollConstants.Fields.SystematicKeyword.Length)]
        public string SystemKeyword { get; set; }

        [ResourceDisplayName(PollConstants.Fields.Title.Label)]
        [ResourceRequired]
        [ResourceStringLength(PollConstants.Fields.Title.Length)]
        public string Title { get; set; }

        [ResourceDisplayName(PollConstants.Fields.Description.Label)]
        public string Description { get; set; }

        public EditableMetadataComponentModel Metadata { get; set; }
    }
}
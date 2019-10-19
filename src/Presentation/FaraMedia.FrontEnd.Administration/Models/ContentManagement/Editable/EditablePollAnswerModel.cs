namespace FaraMedia.FrontEnd.Administration.Models.ContentManagement.Editable {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditablePollAnswerModel : EditableEntityModelBase {
        [ResourceDisplayName(PollAnswerConstants.Fields.Text.Label)]
        [ResourceRequired]
        [ResourceStringLength(PollAnswerConstants.Fields.Text.Length)]
        public string Text { get; set; }

        //Code-assigned
        [ResourceDisplayName(PollAnswerConstants.Fields.Poll.Label)]
        public long PollId { get; set; }
    }
}
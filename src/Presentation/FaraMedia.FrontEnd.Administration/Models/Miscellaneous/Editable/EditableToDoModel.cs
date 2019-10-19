namespace FaraMedia.FrontEnd.Administration.Models.Miscellaneous.Editable {
    using FaraMedia.Data.Schemas.Miscellaneous;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditableToDoModel : EditableEntityModelBase {
        [ResourceDisplayName(ToDoConstants.Fields.ToDoStatus.Label)]
        [ResourceMin(ToDoConstants.Fields.ToDoStatus.MinValue)]
        [ResourceMax(ToDoConstants.Fields.ToDoStatus.MaxValue)]
        public int ToDoStatus { get; set; }

        [ResourceDisplayName(ToDoConstants.Fields.DueDateUtc.Label)]
        [ResourceRequired]
        [ResourceMin(1)]
        public int DueDateDay { get; set; }

        [ResourceRequired]
        [ResourceMin(1)]
        public int DueDateMonth { get; set; }

        [ResourceRequired]
        [ResourceMin(1)]
        public int DueDateYear { get; set; }

        [ResourceDisplayName(ToDoConstants.Fields.Title.Label)]
        [ResourceRequired]
        [ResourceStringLength(ToDoConstants.Fields.Title.Length)]
        public string Title { get; set; }

        [ResourceDisplayName(ToDoConstants.Fields.Description.Label)]
        public string Description { get; set; }

        //Code-assigned
        [ResourceDisplayName(ToDoConstants.Fields.Description.Label)]
        public long PerformerId { get; set; }

        public string PerformerFullName { get; set; }
    }
}
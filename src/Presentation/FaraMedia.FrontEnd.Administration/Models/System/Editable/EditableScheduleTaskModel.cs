namespace FaraMedia.FrontEnd.Administration.Models.Systematic.Editable {
    using FaraMedia.Data.Schemas.Miscellaneous;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditableScheduleTaskModel : EditableEntityModelBase {
        [ResourceDisplayName(ScheduleTaskConstants.Fields.StopOnError.Label)]
        public bool StopOnError { get; set; }

        [ResourceDisplayName(ScheduleTaskConstants.Fields.Seconds.Label)]
        [ResourceMin(ScheduleTaskConstants.Fields.Seconds.MinValue)]
        public int Seconds { get; set; }

        [ResourceDisplayName(ScheduleTaskConstants.Fields.Name.Label)]
        [ResourceRequired]
        [ResourceStringLength(RedirectorConstants.Fields.TargetUrl.Length)]
        public string Name { get; set; }

        [ResourceDisplayName(ScheduleTaskConstants.Fields.Type.Label)]
        [ResourceRequired]
        [ResourceStringLength(ScheduleTaskConstants.Fields.Type.Length)]
        public string Type { get; set; }
    }
}
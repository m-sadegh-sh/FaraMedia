namespace FaraMedia.FrontEnd.Administration.Models.Systematic {
    using FaraMedia.Web.Framework.Mvc.Models;

    public class ScheduleTaskModel : EntityModelBase {
        public string StopOnError { get; set; }

        public int Seconds { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
    }
}
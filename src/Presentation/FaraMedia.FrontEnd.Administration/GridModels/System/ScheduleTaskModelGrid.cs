namespace FaraMedia.FrontEnd.Administration.GridModels.Miscellaneous {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Systematic;
    using FaraMedia.Web.Framework.Mvc.Extensions;

    public sealed class ScheduleTaskModelGrid : EntityModelGridBase<ScheduleTaskModel> {
        public ScheduleTaskModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool stopOnError = true, bool seconds = true, bool name = true, bool type = true)
            : base(htmlHelper, isSelected, false, null, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (stopOnError)
                Column.For(stm => stm.StopOnError).Named(htmlHelper.T(ScheduleTaskConstants.Fields.StopOnError.Label));

            if (seconds)
                Column.For(stm => stm.Seconds).Named(htmlHelper.T(ScheduleTaskConstants.Fields.Seconds.Label));

            if (name)
                Column.For(stm => stm.Name).Named(htmlHelper.T(ScheduleTaskConstants.Fields.Name.Label));

            if (type)
                Column.For(stm => stm.Type).Named(htmlHelper.T(ScheduleTaskConstants.Fields.Type.Label));
        }
    }
}
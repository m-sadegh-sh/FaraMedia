namespace FaraMedia.FrontEnd.Administration.GridModels.Miscellaneous {
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Miscellaneous;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Miscellaneous;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class ToDoModelGrid : EntityModelGridBase<ToDoModel> {
        public ToDoModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, string editRouteName = null, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool toDoStatus = true, bool dueDateOn = true, bool title = true, bool description = true, bool perfotdmer = true)
            : base(htmlHelper, isSelected, edit, MiscellaneousSectionConstants.ToDosController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (toDoStatus)
                Column.For(tdm => tdm.ToDoStatus).Named(htmlHelper.T(ToDoConstants.Fields.ToDoStatus.Label));

            if (dueDateOn)
                Column.For(tdm => GenericHtmlHelper.EditorFor(trap => tdm.DueDate)).Named(htmlHelper.T(ToDoConstants.Fields.DueDateUtc.Label));

            if (title)
                Column.For(tdm => tdm.Title).Named(htmlHelper.T(ToDoConstants.Fields.Title.Label));

            if (description)
                Column.For(tdm => tdm.Description).Named(htmlHelper.T(ToDoConstants.Fields.Description.Label));

            if (perfotdmer) {
                Column.For(tdm => htmlHelper.LocalizedRouteLinkWithId(tdm.PerformerFullName, SecuritySectionConstants.UsersController.Edit.RouteName, tdm.PerformerId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(ToDoConstants.Fields.Performer.Label));
            }
        }
    }
}
namespace FaraMedia.FrontEnd.Administration.GridModels.Miscellaneous {
    using System.Web.Mvc;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Miscellaneous;
    using FaraMedia.Data.Schemas.Miscellaneous;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Miscellaneous;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class TicketModelGrid : EntityModelGridBase<TicketModel> {
        public TicketModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool ticketStatus = true, bool department = true, bool ticketPriority = true, bool subject = true, bool body = true, bool openedBy = true, bool ticketResponses = true)
            : base(htmlHelper, isSelected, false, null, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (ticketStatus)
                Column.For(tm => tm.TicketStatus).Named(htmlHelper.T(TicketConstants.Fields.TicketStatus.Label));

            if (department)
                Column.For(tm => tm.Department).Named(htmlHelper.T(TicketConstants.Fields.Department.Label));

            if (ticketPriority)
                Column.For(tm => tm.TicketPriority).Named(htmlHelper.T(TicketConstants.Fields.TicketPriority.Label));

            if (subject)
                Column.For(tm => tm.Subject).Named(htmlHelper.T(TicketConstants.Fields.Subject.Label));

            if (body)
                Column.For(tm => tm.Body).Named(htmlHelper.T(TicketConstants.Fields.Body.Label));

            if (openedBy) {
                Column.For(tm => htmlHelper.LocalizedRouteLinkWithId(tm.OpenedByFullName, SecuritySectionConstants.UsersController.Edit.RouteName, tm.OpenedById, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(TicketConstants.Fields.Opener.Label));
            }

            if (ticketResponses) {
                Column.For(tm => htmlHelper.LocalizedRouteLink(tm.TicketResponsesCount.ToString(), MiscellaneousSectionConstants.TicketResponsesController.ListByTicketId.RouteName, RouteParameter.Add(KnownParameterNames.TicketId, tm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(TicketConstants.Fields.Responses.Label));
            }
        }
    }
}
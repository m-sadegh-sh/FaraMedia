namespace FaraMedia.FrontEnd.Administration.GridModels.Miscellaneous {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Miscellaneous;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Miscellaneous;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class TicketResponseModelGrid : EntityModelGridBase<TicketResponseModel> {
        public TicketResponseModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool subject = true, bool body = true, bool inResponse = true, bool responder = true)
            : base(htmlHelper, isSelected, edit, MiscellaneousSectionConstants.TicketResponsesController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (subject)
                Column.For(trm => trm.Subject).Named(htmlHelper.T(TicketResponseConstants.Fields.Subject.Label));

            if (body)
                Column.For(trm => trm.Body).Named(htmlHelper.T(TicketResponseConstants.Fields.Body.Label));

            if (inResponse) {
                Column.For(trm => htmlHelper.LocalizedRouteLinkWithId(trm.InResponseToSubject, MiscellaneousSectionConstants.TicketsController.Edit.RouteName, trm.InResponseToId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(TicketResponseConstants.Fields.InResponseTo.Label));
            }

            if (responder) {
                Column.For(trm => htmlHelper.LocalizedRouteLinkWithId(trm.ResponderFullName, SecuritySectionConstants.UsersController.Edit.RouteName, trm.ResponderId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(TicketResponseConstants.Fields.Responder.Label));
            }
        }
    }
}
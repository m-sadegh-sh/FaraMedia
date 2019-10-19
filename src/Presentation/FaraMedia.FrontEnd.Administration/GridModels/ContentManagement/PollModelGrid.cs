namespace FaraMedia.FrontEnd.Administration.GridModels.Poll {
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.ContentManagement;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class PollModelGrid : CommentableModelGridBase<PollModel> {
        public PollModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool ipAddress = true, bool creator = true, bool allowComments = true, bool comments = true, bool likes = true, bool shares = true, bool showOnHomePage = true, bool isMultiSelection = true, bool startDate = true, bool endDate = true, bool systemKeyword = true, bool title = true, bool description = true, bool metadata = true, bool pollAnswers = true)
            : base(htmlHelper, isSelected, edit, ContentManagementSectionConstants.PollsController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn, ipAddress, creator, allowComments, commentsCount, likesCount, shares) {
            if (showOnHomePage)
                Column.For(pm => pm.ShowOnHomePage).Named(htmlHelper.T(PollConstants.Fields.ShowOnHomePage.Label));

            if (isMultiSelection)
                Column.For(pm => pm.IsMultiSelection).Named(htmlHelper.T(PollConstants.Fields.IsMultiSelection.Label));

            if (startDate)
                Column.For(pm => GenericHtmlHelper.EditorFor(trap => pm.StartDate)).Named(htmlHelper.T(PollConstants.Fields.StartDateOnUtc.Label));

            if (endDate)
                Column.For(pm => GenericHtmlHelper.EditorFor(trap => pm.EndDate)).Named(htmlHelper.T(PollConstants.Fields.EndDateOnUtc.Label));

            if (systemKeyword)
                Column.For(pm => pm.SystematicKeyword).Named(htmlHelper.T(PollConstants.Fields.SystematicKeyword.Label));

            if (title)
                Column.For(pm => pm.Title).Named(htmlHelper.T(PollConstants.Fields.Title.Label));

            if (description)
                Column.For(pm => pm.Description).Named(htmlHelper.T(PollConstants.Fields.Description.Label));

            if (metadata)
                Column.For(pm => GenericHtmlHelper.EditorFor(trap => pm.Metadata)).Named(htmlHelper.T(CommonConstants.Fields.Metadata.Label));

            if (pollAnswers) {
                Column.For(cm => htmlHelper.SmartRouteLink(cm.PollAnswersCount.ToString(), ContentManagementSectionConstants.PollAnswersController.ListByPollId.RouteName, RouteParameter.Add(KnownParameterNames.PollId, cm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(PollConstants.Fields.PollAnswers.Label));
            }
        }
    }
}
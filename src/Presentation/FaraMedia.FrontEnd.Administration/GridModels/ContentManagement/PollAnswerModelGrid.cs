namespace FaraMedia.FrontEnd.Administration.GridModels.PollAnswer {
    using System.Web.Mvc;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.ContentManagement;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class PollAnswerModelGrid : EntityModelGridBase<PollAnswerModel> {
        public PollAnswerModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool text = true, bool poll = true, bool pollVotingRecords = true) : base(htmlHelper, isSelected, edit, ContentManagementSectionConstants.PollAnswersController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (text)
                Column.For(pam => pam.Text).Named(htmlHelper.T(PollAnswerConstants.Fields.Text.Label));

            if (poll) {
                Column.For(pam => htmlHelper.LocalizedRouteLinkWithId(pam.PollTitle, ContentManagementSectionConstants.PollsController.Edit.RouteName, pam.PollId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(PollAnswerConstants.Fields.Poll.Label));
            }

            if (pollVotingRecords) {
                Column.For(pam => htmlHelper.SmartRouteLink(pam.PollVotingRecordsCount.ToString(), ContentManagementSectionConstants.PollVotingRecordsController.ListByPollAnswerId.RouteName, RouteParameter.Add(KnownParameterNames.PollAnswerId, pam.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(PollConstants.Fields.PollAnswers.Label));
            }
        }
    }
}
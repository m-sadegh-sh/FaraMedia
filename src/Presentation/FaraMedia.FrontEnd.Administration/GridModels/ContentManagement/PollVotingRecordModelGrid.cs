namespace FaraMedia.FrontEnd.Administration.GridModels.PollVotingRecord {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.ContentManagement;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class PollVotingRecordModelGrid : EntityModelGridBase<PollVotingRecordModel> {
        public PollVotingRecordModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool pollAnswer = true) : base(htmlHelper, isSelected, false, null, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (pollAnswer) {
                Column.For(pvrm => htmlHelper.LocalizedRouteLinkWithId(pvrm.PollAnswerText, ContentManagementSectionConstants.PollAnswersController.Edit.RouteName, pvrm.PollAnswerId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(PollVotingRecordConstants.Fields.PollAnswer.Label));
            }
        }
    }
}
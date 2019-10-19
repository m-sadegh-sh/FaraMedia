namespace FaraMedia.FrontEnd.Administration.GridModels.Miscellaneous {
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Systematic;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class QueuedEmailModelGrid : EntityModelGridBase<QueuedEmailModel> {
        public QueuedEmailModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool sentTries = true, bool queuedEmailPriority = true, bool sentOn = true, bool from = true, bool fromName = true, bool to = true, bool toName = true, bool cc = true, bool bcc = true, bool subject = true, bool emailAccount = true)
            : base(htmlHelper, isSelected, false, null, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (sentTries)
                Column.For(qem => qem.SentTries).Named(htmlHelper.T(QueuedEmailConstants.Fields.SentTries.Label));

            if (queuedEmailPriority)
                Column.For(qem => qem.QueuedEmailPriority).Named(htmlHelper.T(QueuedEmailConstants.Fields.QueuedEmailPriority.Label));

            if (sentOn)
                Column.For(om => GenericHtmlHelper.EditorFor(trap => om.SentDate)).Named(htmlHelper.T(QueuedEmailConstants.Fields.SentDateUtc.Label));

            if (from)
                Column.For(qem => qem.From).Named(htmlHelper.T(QueuedEmailConstants.Fields.From.Label));

            if (fromName)
                Column.For(qem => qem.FromName).Named(htmlHelper.T(QueuedEmailConstants.Fields.FromName.Label));

            if (to)
                Column.For(qem => qem.To).Named(htmlHelper.T(QueuedEmailConstants.Fields.To.Label));

            if (toName)
                Column.For(qem => qem.ToName).Named(htmlHelper.T(QueuedEmailConstants.Fields.ToName.Label));

            if (cc)
                Column.For(qem => qem.Cc).Named(htmlHelper.T(QueuedEmailConstants.Fields.Cc.Label));

            if (bcc)
                Column.For(qem => qem.Bcc).Named(htmlHelper.T(QueuedEmailConstants.Fields.Bcc.Label));

            if (subject)
                Column.For(qem => qem.Subject).Named(htmlHelper.T(QueuedEmailConstants.Fields.Subject.Label));

            if (emailAccount) {
                Column.For(qem => htmlHelper.LocalizedRouteLinkWithId(qem.EmailAccountDisplayName, SystematicSectionConstants.EmailAccountsController.Edit.RouteName, qem.EmailAccountId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(QueuedEmailConstants.Fields.EmailAccount.Label));
            }
        }
    }
}
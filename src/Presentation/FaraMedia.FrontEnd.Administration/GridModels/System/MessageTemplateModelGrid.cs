namespace FaraMedia.FrontEnd.Administration.GridModels.Miscellaneous {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Systematic;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class MessageTemplateModelGrid : EntityModelGridBase<MessageTemplateModel> {
        public MessageTemplateModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool name = true, bool bccEmailAddresses = true, bool subject = true, bool body = true, bool emailAccount = true)
            : base(htmlHelper, isSelected, false, null, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (name)
                Column.For(mtm => mtm.Name).Named(htmlHelper.T(MessageTemplateConstants.Fields.Name.Label));

            if (bccEmailAddresses)
                Column.For(mtm => mtm.BccEmailAddresses).Named(htmlHelper.T(MessageTemplateConstants.Fields.BccEmailAddresses.Label));

            if (subject)
                Column.For(mtm => mtm.Subject).Named(htmlHelper.T(MessageTemplateConstants.Fields.Subject.Label));

            if (body)
                Column.For(mtm => mtm.Body).Named(htmlHelper.T(MessageTemplateConstants.Fields.Body.Label));

            if (emailAccount) {
                Column.For(mtm => htmlHelper.LocalizedRouteLinkWithId(mtm.EmailAccountDisplayName, SystematicSectionConstants.EmailAccountsController.Edit.RouteName, mtm.EmailAccountId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(MessageTemplateConstants.Fields.EmailAccount.Label));
            }
        }
    }
}
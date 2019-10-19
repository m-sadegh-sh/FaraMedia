namespace FaraMedia.FrontEnd.Administration.GridModels.Miscellaneous {
    using System.Web.Mvc;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Systematic;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class EmailAccountModelGrid : EntityModelGridBase<EmailAccountModel> {
        public EmailAccountModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool sslEnabled = true, bool useDefaultCredentials = true, bool port = true, bool displayName = true, bool email = true, bool host = true, bool userName = true, bool password = true, bool messageTemplates = true, bool queuedEmails = true)
            : base(htmlHelper, isSelected, false, null, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (sslEnabled)
                Column.For(eam => eam.SslEnabled).Named(htmlHelper.T(EmailAccountConstants.Fields.SslEnabled.Label));

            if (useDefaultCredentials)
                Column.For(eam => eam.UseDefaultCredentials).Named(htmlHelper.T(EmailAccountConstants.Fields.UseDefaultCredentials.Label));

            if (port)
                Column.For(eam => eam.Port).Named(htmlHelper.T(EmailAccountConstants.Fields.Port.Label));

            if (displayName)
                Column.For(eam => eam.DisplayName).Named(htmlHelper.T(EmailAccountConstants.Fields.DisplayName.Label));

            if (email)
                Column.For(eam => eam.Email).Named(htmlHelper.T(EmailAccountConstants.Fields.Email.Label));

            if (host)
                Column.For(eam => eam.Host).Named(htmlHelper.T(EmailAccountConstants.Fields.Host.Label));

            if (userName)
                Column.For(eam => eam.UserName).Named(htmlHelper.T(EmailAccountConstants.Fields.UserName.Label));

            if (password)
                Column.For(eam => eam.Password).Named(htmlHelper.T(EmailAccountConstants.Fields.Password.Label));

            if (messageTemplates) {
                Column.For(eam => htmlHelper.LocalizedRouteLink(eam.MessageTemplatesCount.ToString(), SystematicSectionConstants.MessageTemplatesController.ListByEmailAccountId.RouteName, RouteParameter.Add(KnownParameterNames.EmailAccountId, eam.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(EmailAccountConstants.Fields.Templates.Label));
            }

            if (queuedEmails) {
                Column.For(eam => htmlHelper.LocalizedRouteLink(eam.QueuedEmailsCount.ToString(), SystematicSectionConstants.QueuedEmailsController.ListByEmailAccountId.RouteName, RouteParameter.Add(KnownParameterNames.EmailAccountId, eam.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(EmailAccountConstants.Fields.Emails.Label));
            }
        }
    }
}
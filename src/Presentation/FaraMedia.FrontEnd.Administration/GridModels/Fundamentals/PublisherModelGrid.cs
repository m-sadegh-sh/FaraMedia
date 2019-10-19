namespace FaraMedia.FrontEnd.Administration.GridModels.Fundamentals {
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Data.Schemas.FileManagement;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.Data.Schemas.Miscellaneous;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Fundamentals;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class PublisherModelGrid : CommentableModelGridBase<PublisherModel> {
        public PublisherModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool ipAddress = true, bool creator = true, bool allowComments = true, bool comments = true, bool likes = true, bool shares = true, bool name = true, bool ceo = true, bool registrationNumber = true, bool email = true, bool history = false, bool metadata = true, bool website = true, bool logo = true, bool tracks = true) : base(htmlHelper, isSelected, edit, FundamentalsSecctionConstants.FundamentalsController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn, ipAddress, creator, allowComments, commentsCount, likesCount, shares) {
            if (name)
                Column.For(pm => pm.Name).Named(htmlHelper.T(PublisherConstants.Fields.Name.Label));

            if (ceo)
                Column.For(pm => pm.Ceo).Named(htmlHelper.T(PublisherConstants.Fields.Ceo.Label));

            if (registrationNumber)
                Column.For(pm => pm.RegisterationNumber).Named(htmlHelper.T(PublisherConstants.Fields.RegisterationNumber.Label));

            if (email)
                Column.For(pm => pm.Email).Named(htmlHelper.T(PublisherConstants.Fields.Email.Label));

            if (history)
                Column.For(pm => pm.History).Named(htmlHelper.T(PublisherConstants.Fields.History.Label));

            if (metadata)
                Column.For(pm => GenericHtmlHelper.EditorFor(trap => pm.Metadata)).Named(htmlHelper.T(CommonConstants.Fields.Metadata.Label));

            if (website) {
                Column.For(pm => htmlHelper.LocalizedRouteLinkWithId(pm.WebsiteTargetUrl, MiscellaneousSectionConstants.RedirectorsController.Edit.RouteName, pm.WebsiteId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(PublisherConstants.Fields.Website.Label));
            }

            if (logo) {
                Column.For(pm => htmlHelper.LocalizedRouteLinkWithId(pm.LogoFileName, FileManagementSectionConstants.PicturesController.Edit.RouteName, pm.LogoId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(PublisherConstants.Fields.Logo.Label));
            }

            if (tracks) {
                Column.For(pm => htmlHelper.LocalizedRouteLink(pm.FundamentalsCount.ToString(), FundamentalsSecctionConstants.FundamentalsController.ListByPublisherId.RouteName, RouteParameter.Add(KnownParameterNames.PublisherId, pm.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(PublisherConstants.Fields.Fundamentals.Label));
            }
        }
    }
}
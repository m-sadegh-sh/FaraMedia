namespace FaraMedia.FrontEnd.Administration.GridModels.Miscellaneous {
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.FrontEnd.Administration.GridModels.Common;
    using FaraMedia.FrontEnd.Administration.Models.Security;
    using FaraMedia.FrontEnd.Administration.Models.Security;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public sealed class UserModelGrid : EntityModelGridBase<UserModel> {
        public UserModelGrid(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, bool id = true, bool isPublished = true, bool isDeleted = true, bool displayOrder = true, bool createdOn = true, bool lastModifiedOn = true, bool isSystemAccount = true, bool isBuyingBlocked = true, bool passwordFormat = true, bool lastLoginDateOn = true, bool lastActivityDateOn = true, bool systemName = true, bool userName = true, bool email = true, bool adminComment = true, bool lastIpAddress = true, bool roles = true, bool activities = true, bool logs = true, bool toDos = true, bool tickets = true, bool ticketResponses = true, bool incomingFriendRequests = true, bool outgoingFriendRequestsCount=true,bool blogsCount=true,bool ordersCount=true)
            : base(htmlHelper, isSelected, edit, SecuritySectionConstants.UsersController.Edit.RouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (isSystemAccount)
                Column.For(um => um.IsSystemAccount).Named(htmlHelper.T(UserConstants.Fields.IsSystemAccount.Label));
            
            if (isBuyingBlocked)
                Column.For(um => um.IsBuyingBlocked).Named(htmlHelper.T(UserConstants.Fields.IsBuyingBlocked.Label));
            
            if (passwordFormat)
                Column.For(um => um.PasswordFormat).Named(htmlHelper.T(UserConstants.Fields.PasswordFormat.Label));
            
            if (lastLoginDateOn)
                Column.For(um => GenericHtmlHelper.EditorFor(trap => um.LastLoginDate)).Named(htmlHelper.T(UserConstants.Fields.LastLoginDateUtc.Label));

            if (lastActivityDateOn)
                Column.For(um => GenericHtmlHelper.EditorFor(trap => um.LastActivityDate)).Named(htmlHelper.T(UserConstants.Fields.LastActivityDateUtc.Label));

            if (systemName)
                Column.For(um => um.SystematicName).Named(htmlHelper.T(UserConstants.Fields.SystematicName.Label));

            if (userName)
                Column.For(um => um.UserName).Named(htmlHelper.T(UserConstants.Fields.UserName.Label));

            if (email)
                Column.For(um => um.Email).Named(htmlHelper.T(UserConstants.Fields.Email.Label));

            if (adminComment)
                Column.For(um => um.AdminComment).Named(htmlHelper.T(UserConstants.Fields.AdminComment.Label));

            if (lastIpAddress)
                Column.For(um => um.LastIpAddress).Named(htmlHelper.T(UserConstants.Fields.LastIpAddress.Label));

            if (roles) {
                Column.For(um => htmlHelper.LocalizedRouteLink(um.RolesCount.ToString(), SecuritySectionConstants.RolesController.ListByUserId.RouteName, RouteParameter.Add(KnownParameterNames.UserId, um.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(UserConstants.Fields.Roles.Label));
            }

            if (activities) {
                Column.For(um => htmlHelper.LocalizedRouteLink(um.ActivitiesCount.ToString(), SecuritySectionConstants.UsersController.ListByUserId.RouteName, RouteParameter.Add(KnownParameterNames.UserId, um.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(UserConstants.Fields.Activities.Label));
            }

            if (logs) {
                Column.For(um => htmlHelper.LocalizedRouteLink(um.LogsCount.ToString(), SecuritySectionConstants.UsersController.ListByUserId.RouteName, RouteParameter.Add(KnownParameterNames.UserId, um.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(UserConstants.Fields.Logs.Label));
            }

            if (toDos) {
                Column.For(um => htmlHelper.LocalizedRouteLink(um.ToDosCount.ToString(), SecuritySectionConstants.UsersController.ListByUserId.RouteName, RouteParameter.Add(KnownParameterNames.UserId, um.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(UserConstants.Fields.ToDos.Label));
            }

            if (tickets) {
                Column.For(um => htmlHelper.LocalizedRouteLink(um.TicketsCount.ToString(), SecuritySectionConstants.UsersController.ListByUserId.RouteName, RouteParameter.Add(KnownParameterNames.UserId, um.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(UserConstants.Fields.Tickets.Label));
            }

            if (ticketResponses) {
                Column.For(um => htmlHelper.LocalizedRouteLink(um.TicketResponsesCount.ToString(), SecuritySectionConstants.UsersController.ListByUserId.RouteName, RouteParameter.Add(KnownParameterNames.UserId, um.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(UserConstants.Fields.Responses.Label));
            }

            if (incomingFriendRequests) {
                Column.For(um => htmlHelper.LocalizedRouteLink(um.IncomingFriendRequestsCount.ToString(), SecuritySectionConstants.UsersController.ListByUserId.RouteName, RouteParameter.Add(KnownParameterNames.UserId, um.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(UserConstants.Fields.IncomingFriendRequests.Label));
            }

            if (outgoingFriendRequests) {
                Column.For(um => htmlHelper.LocalizedRouteLink(um.OutgoingFriendRequestsCount.ToString(), SecuritySectionConstants.UsersController.ListByToId.RouteName, RouteParameter.Add(KnownParameterNames.UserId, um.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(UserConstants.Fields.OutgoingFriendRequests.Label));
            }

            if (blogs) {
                Column.For(um => htmlHelper.LocalizedRouteLink(um.BlogsCount.ToString(), ContentManagementSectionConstants.BlogsController.ListByUserId.RouteName, RouteParameter.Add(KnownParameterNames.UserId, um.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(UserConstants.Fields.Blogs.Label));
            }

            if (orders) {
                Column.For(um => htmlHelper.LocalizedRouteLink(um.BillingCount.ToString(), BillingSectionConstants.BillingController.ListByOrdererId.RouteName, RouteParameter.Add(KnownParameterNames.UserId, um.Id), new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(UserConstants.Fields.Billing.Label));
            }
        }
    }
}
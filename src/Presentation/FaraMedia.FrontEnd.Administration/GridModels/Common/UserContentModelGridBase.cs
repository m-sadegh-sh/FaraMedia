namespace FaraMedia.FrontEnd.Administration.GridModels.Common {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.FrontEnd.Administration.Models.Common;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Routing;

    public abstract class UserContentModelGridBase<TModel> : EntityModelGridBase<TModel> where TModel : UserContentModelBase {
        protected UserContentModelGridBase(HtmlHelper htmlHelper, bool isSelected = true, bool edit = true, string editRouteName = null, bool id = true, bool ipAddress = true, bool creator = true) : base(htmlHelper, isSelected, edit, editRouteName, id, isPublished, isDeleted, displayOrder, createdOn, lastModifiedOn) {
            if (ipAddress)
                Column.For(ucm => ucm.IpAddress).Named(htmlHelper.T(UserContentConstants.Fields.IpAddress.Label));

            if (creator) {
                Column.For(ucm => htmlHelper.LocalizedRouteLinkWithId(ucm.UserFullName, SecuritySectionConstants.UsersController.Edit.RouteName, ucm.UserId, null, new {
                    @class = "btn secondary"
                }, null, null, false, null)).Named(htmlHelper.T(UserContentConstants.Fields.User.Label)).CellCondition(nm => nm.UserFullName != null).Encode(false);
            }
        }
    }
}
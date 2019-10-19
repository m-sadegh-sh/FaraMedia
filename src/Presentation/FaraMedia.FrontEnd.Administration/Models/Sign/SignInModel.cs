namespace FaraMedia.FrontEnd.Administration.Models.Sign {
    using FaraMedia.Data.Schemas.Authenticate;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models;

    public class SignInModel : ModelBase {
        public bool UserNamesEnabled { get; set; }

        [ResourceDisplayName(UserConstants.Fields.UserName.Label)]
        public string UserName { get; set; }

        [ResourceDisplayName(UserConstants.Fields.Email.Label)]
        [ResourceEmail]
        public string Email { get; set; }

        [ResourceDisplayName(UserConstants.Fields.Password.Label)]
        [ResourceRequired]
        public string Password { get; set; }

        [ResourceDisplayName(AuthenticateSectionConstants.SignController.In.Fields.RememberMe.Label)]
        public bool RememberMe { get; set; }
    }
}
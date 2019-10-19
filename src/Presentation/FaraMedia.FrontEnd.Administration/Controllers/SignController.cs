namespace FaraMedia.FrontEnd.Administration.Controllers {
    using System.Web.Mvc;

    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Data.Schemas.Authenticate;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Root;
    using FaraMedia.FrontEnd.Administration.Models.Sign;
    using FaraMedia.Services.Authentication;
    using FaraMedia.Services.Security;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Controllers;
    using FaraMedia.Web.Framework.Mvc.Extensions;
    using FaraMedia.Web.Framework.Security;

    [HttpsRequirement(SslRequirement.Yes)]
    public class SignController : FaraControllerBase {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly MembershipSettings _membershipSettings;

        public SignController(IAuthenticationService authenticationService, IUserService userService, MembershipSettings membershipSettings) {
            _authenticationService = authenticationService;
            _userService = userService;
            _membershipSettings = membershipSettings;
        }

        [HttpGet]
        [ResolveThen]
        public ActionResult In() {
            var signInModel = new SignInModel {
                UserNamesEnabled = _membershipSettings.UserNamesEnabled
            };

            return View(signInModel);
        }

        [HttpPost]
        [PutThen]
        public ActionResult In(SignInModel signInModel, string then) {
            if (_authenticationService.GetAuthenticatedUser() != null) {
                if (Url.IsLocalUrl(then))
                    return Redirect(then);

                return RedirectToRoute(RootSectionConstants.CommonController.Home.RouteName);
            }

            if (!ModelState.IsValid) {
                signInModel = new SignInModel {
                    UserNamesEnabled = _membershipSettings.UserNamesEnabled
                };

                return View(signInModel);
            }

            var operationResult = _userService.ValidateUser(_membershipSettings.UserNamesEnabled ? signInModel.UserName : signInModel.Email, signInModel.Password);

            if (!operationResult.Success || !operationResult.Value) {
                ModelState.InjectMessages(operationResult);

                signInModel = new SignInModel {
                    UserNamesEnabled = _membershipSettings.UserNamesEnabled
                };

                return View(signInModel);
            }

            var user = _membershipSettings.UserNamesEnabled ? _userService.GetUserByUserName(signInModel.UserName) : _userService.GetUserByEmail(signInModel.Email);
            _authenticationService.SignIn(user, signInModel.RememberMe);

            ResourceSuccessNotification(AuthenticateSectionConstants.SignController.In.Systematic.SignedIn);

            if (Url.IsLocalUrl(then))
                return Redirect(then);

            return RedirectToRoute(RootSectionConstants.CommonController.Home.RouteName);
        }

        [Userize]
        [ResolveThen]
        public ActionResult Out(string then) {
            _authenticationService.SignOut();

            ResourceSuccessNotification(AuthenticateSectionConstants.SignController.Out.Systematic.SignedOut);

            if (Url.IsLocalUrl(then))
                return Redirect(then);

            return RedirectToRoute(RootSectionConstants.CommonController.Home.RouteName);
        }
    }
}
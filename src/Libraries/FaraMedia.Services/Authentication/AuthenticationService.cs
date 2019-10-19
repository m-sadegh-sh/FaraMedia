namespace FaraMedia.Services.Authentication {
    using System;
    using System.Web;
    using System.Web.Security;

    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Services.Security;

    public sealed class AuthenticationService : IAuthenticationService {
        private readonly HttpContextBase _httpContext;
        private readonly IUserService _userService;
        private readonly SecuritySettings _securitySettings;
        private readonly TimeSpan _expirationTimeSpan;

        private User _cachedUser;

        public AuthenticationService(HttpContextBase httpContext, IUserService userService, SecuritySettings securitySettings) {
            _httpContext = httpContext;
            _userService = userService;
            _securitySettings = securitySettings;
            _expirationTimeSpan = FormsAuthentication.Timeout;
        }

        public void SignIn(User user, bool createPersistentCookie) {
            var now = DateTime.UtcNow.ToLocalTime();

            var formsAuthenticationTicket = new FormsAuthenticationTicket(1, _securitySettings.UserNamesEnabled ? user.UserName : user.Email, now, now.Add(_expirationTimeSpan), createPersistentCookie, _securitySettings.UserNamesEnabled ? user.UserName : user.Email, FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(formsAuthenticationTicket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket) {
                HttpOnly = true,
                Expires = now.Add(_expirationTimeSpan),
                Secure = FormsAuthentication.RequireSSL,
                Path = FormsAuthentication.FormsCookiePath
            };

            if (FormsAuthentication.CookieDomain != null)
                cookie.Domain = FormsAuthentication.CookieDomain;

            _httpContext.Response.Cookies.Add(cookie);
            _cachedUser = user;
        }

        public void SignOut() {
            _cachedUser = null;
            FormsAuthentication.SignOut();
        }

        public User GetAuthenticatedUser() {
            if (_cachedUser != null)
                return _cachedUser;

            if (_httpContext == null || _httpContext.Request == null || !_httpContext.Request.IsAuthenticated || !(_httpContext.User.Identity is FormsIdentity))
                return null;

            var formsIdentity = (FormsIdentity) _httpContext.User.Identity;
            var user = GetAuthenticatedUserFromTicket(formsIdentity.Ticket);
            if (user != null && user.IsPublished && !user.IsDeleted && user.IsRegistered())
                _cachedUser = user;

            return _cachedUser;
        }

        public User GetAuthenticatedUserFromTicket(FormsAuthenticationTicket formsAuthenticationTicket) {
            if (formsAuthenticationTicket == null)
                throw new ArgumentNullException("formsAuthenticationTicket");

            var userNameOrEmail = formsAuthenticationTicket.UserData;

            if (string.IsNullOrWhiteSpace(userNameOrEmail))
                return null;

            var user = _securitySettings.UserNamesEnabled ? _userService.GetUserByUserName(userNameOrEmail) : _userService.GetUserByEmail(userNameOrEmail);

            return user;
        }
    }
}
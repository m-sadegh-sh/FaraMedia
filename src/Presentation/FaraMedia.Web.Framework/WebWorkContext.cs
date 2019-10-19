namespace FaraMedia.Web.Framework {
    using System;
    using System.Globalization;
    using System.Web;

    using FaraMedia.Core;
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Services.Authentication;
    using FaraMedia.Services.Systematic;
    using FaraMedia.Services.Security;

    public class WebWorkContext : IWorkContext {
        private const string USER_COOKIE_NAME = "faraMedia.user";

        private readonly HttpContextBase _httpContext;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly IUserAttributeService _userAttributeService;
        private readonly ILanguageService _languageService;
        private readonly IWebHelper _webHelper;

        private User _cachedUser;

        public WebWorkContext(HttpContextBase httpContext, IAuthenticationService authenticationService, IUserService userService, IUserAttributeService userAttributeService, ILanguageService languageService, IWebHelper webHelper) {
            _httpContext = httpContext;
            _authenticationService = authenticationService;
            _userService = userService;
            _userAttributeService = userAttributeService;
            _languageService = languageService;
            _webHelper = webHelper;
        }

        public User CurrentUser {
            get { return GetCurrentUser(); }
            set {
                SetUserCookie(value.Guid);
                _cachedUser = value;
            }
        }

        public Language WorkingLanguage {
            get {
                if (CurrentUser != null) {
                    var userLanguageId = _userAttributeService.GetUserAttributeValueByKey(CurrentUser.Id, UserAttributeNames.LanguageId, 0);

                    var userLanguage = _languageService.GetLanguageById(userLanguageId);

                    if (userLanguage != null)
                        return userLanguage;
                }

                var defautlLanguage = _languageService.GetFallbackLanguage();

                return defautlLanguage;
            }
            set {
                if (CurrentUser == null)
                    return;

                var languageAttribute = _userAttributeService.GetUserAttributeByKey(CurrentUser.Id, UserAttributeNames.LanguageId);

                if (languageAttribute != null) {
                    languageAttribute.Value = value.Id.ToString(CultureInfo.InvariantCulture);
                    _userAttributeService.UpdateUserAttribute(languageAttribute);
                } else {
                    languageAttribute = new UserAttribute {
                        IsPublished = true,
                        Key = UserAttributeNames.LanguageId,
                        Value = value.Id.ToString(CultureInfo.InvariantCulture),
                        User = CurrentUser
                    };

                    _userAttributeService.InsertUserAttribute(languageAttribute);
                }
            }
        }

        public bool IsAdmin { get; set; }

        protected User GetCurrentUser() {
            if (_cachedUser != null)
                return _cachedUser;

            User user = null;
            if (_httpContext.IsReady()) {
                if (_webHelper.IsSearchEngine(_httpContext.Request))
                    user = _userService.GetUserBySystemName(UserNames.SearchEngine);

                if (user == null || !user.IsPublished || user.IsDeleted)
                    user = _authenticationService.GetAuthenticatedUser();

                if (user == null || !user.IsPublished || user.IsDeleted) {
                    var userCookie = GetUserCookie();
                    if (userCookie != null && !string.IsNullOrEmpty(userCookie.Value)) {
                        Guid guid;
                        if (Guid.TryParse(userCookie.Value, out guid)) {
                            var userByCookie = _userService.GetUserByGuid(guid);
                            if (userByCookie != null && !userByCookie.IsRegistered() && !userByCookie.IsSearchEngineAccount())
                                user = userByCookie;
                        }
                    }
                }

                if (user == null || !user.IsPublished || user.IsDeleted)
                    user = _userService.GetOrInsertGuestUser();

                SetUserCookie(user.Guid);
            }

            if (user != null && user.IsPublished && !user.IsDeleted) {
                var update = false;
                if (user.LastActivityDateUtc.AddMinutes(1.0) < DateTime.UtcNow) {
                    user.LastActivityDateUtc = DateTime.UtcNow;
                    update = true;
                }

                var currentIpAddress = _webHelper.GetIpAddress();
                if (!string.IsNullOrEmpty(currentIpAddress)) {
                    if (!currentIpAddress.Equals(user.LastIpAddress)) {
                        user.LastIpAddress = currentIpAddress;
                        update = true;
                    }
                }

                if (update)
                    _userService.UpdateUser(user);

                _cachedUser = user;
            }

            return _cachedUser;
        }

        protected HttpCookie GetUserCookie() {
            if (!_httpContext.IsReady())
                return null;

            return _httpContext.Request.Cookies[USER_COOKIE_NAME];
        }

        protected void SetUserCookie(Guid userGuid) {
            if (!_httpContext.IsReady())
                return;

            var cookie = new HttpCookie(USER_COOKIE_NAME) {
                Value = userGuid.ToString()
            };
            if (userGuid == Guid.Empty)
                cookie.Expires = DateTime.Now.AddMonths(-1);
            else {
                const int cookieExpires = 24*365;
                cookie.Expires = DateTime.Now.AddHours(cookieExpires);
            }

            _httpContext.Response.Cookies.Remove(USER_COOKIE_NAME);
            _httpContext.Response.Cookies.Add(cookie);
        }
    }
}
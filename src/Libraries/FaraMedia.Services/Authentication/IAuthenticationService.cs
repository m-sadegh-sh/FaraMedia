namespace FaraMedia.Services.Authentication {
    using FaraMedia.Core.Domain.Security;

    public interface IAuthenticationService {
        void SignIn(User user, bool createPersistentCookie);
        void SignOut();
        User GetAuthenticatedUser();
    }
}
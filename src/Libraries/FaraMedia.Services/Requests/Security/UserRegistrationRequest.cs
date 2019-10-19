namespace FaraMedia.Services.Requests.Security {
    using FaraMedia.Core.Domain.Security;

    public sealed class UserRegistrationRequest {
        public UserRegistrationRequest(User user, string email, string userName, string password, PasswordStoringFormat passwordFormat, string blockTypeSystemName = null) {
            User = user;
            Email = email;
            UserName = userName;
            Password = password;
            PasswordFormat = passwordFormat;
            BlockTypeSystemName = blockTypeSystemName;
        }

        public User User { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public PasswordStoringFormat PasswordFormat { get; set; }
        public string BlockTypeSystemName { get; set; }
    }
}
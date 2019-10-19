namespace FaraMedia.Services.Extensions.Security {
    using FaraMedia.Core.Domain.Security;

    public sealed class ChangePasswordRequest {
        public ChangePasswordRequest(string email, bool validateRequest, PasswordStoringFormat newPasswordFormat, string newPassword, string oldPassword = "") {
            Email = email;
            ValidateRequest = validateRequest;
            NewPasswordFormat = newPasswordFormat;
            NewPassword = newPassword;
            OldPassword = oldPassword;
        }

        public string Email { get; set; }
        public bool ValidateRequest { get; set; }
        public PasswordStoringFormat NewPasswordFormat { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}
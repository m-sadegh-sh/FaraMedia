namespace FaraMedia.Core.Domain.Configuration {
	public class SecuritySettings : ISettings {
		public string EncryptionKey { get; set; }
		public string AdminAreaAllowedIpAddress { get; set; }
		public bool HideLinksBasedOnPermissions { get; set; }
		public bool UseSsl { get; set; }
		public int MaxumimMinutesToDeleteGuestUsers { get; set; }
		public int OnlineUserMinutes { get; set; }
		public UserRegistrationType RegistrationType { get; set; }
		public bool UserNamesEnabled { get; set; }
		public string IllegalUserNameChars { get; set; }
		public DisplayScreenNameFormat ScreenNameFormat { get; set; }
		public int PasswordMinLength { get; set; }
		public string RequiredPasswordChars { get; set; }
		public PasswordHashingAlgorithm PasswordHashingAlgorithm { get; set; }
		public bool NewsletterEnabled { get; set; }
		public bool NotifyForNewUserRegistration { get; set; }
		public bool NotifyForNewComments { get; set; }
	}
}
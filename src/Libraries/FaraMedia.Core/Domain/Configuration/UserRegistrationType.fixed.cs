namespace FaraMedia.Core.Domain.Configuration {
	public enum UserRegistrationType : byte {
		Standard = 1,
		EmailValidation = 2,
		AdminApproval = 4,
		Disabled = 8,
	}
}
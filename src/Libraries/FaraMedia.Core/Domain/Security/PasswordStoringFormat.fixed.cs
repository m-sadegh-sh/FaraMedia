namespace FaraMedia.Core.Domain.Security {
	public enum PasswordStoringFormat : byte {
		Clear = 1,
		Hashed = 2,
		Encrypted = 4
	}
}
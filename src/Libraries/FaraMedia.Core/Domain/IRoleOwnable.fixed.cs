namespace FaraMedia.Core.Domain {
	using FaraMedia.Core.Domain.Security;

	public interface IRoleOwnable {
		Role Owner { get; set; }
	}
}
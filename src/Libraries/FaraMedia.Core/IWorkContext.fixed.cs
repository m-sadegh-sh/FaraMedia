namespace FaraMedia.Core {
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Core.Domain.Systematic;

	public interface IWorkContext {
		bool IsAdmin { get; set; }
		User CurrentUser { get; set; }
		Language WorkingLanguage { get; set; }
	}
}
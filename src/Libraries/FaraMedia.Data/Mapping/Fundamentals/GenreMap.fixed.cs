namespace FaraMedia.Data.Mapping.Fundamentals {
	using FaraMedia.Core.Domain.Fundamentals;

	public sealed class GenreMap : UIElementMapBase<Genre> {
		public GenreMap() {
			Property(g => g.Title);
			Property(g => g.Description);
			Set(g => g.Tracks);
		}
	}
}
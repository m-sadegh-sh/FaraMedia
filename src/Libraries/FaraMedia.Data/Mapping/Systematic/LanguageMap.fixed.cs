namespace FaraMedia.Data.Mapping.Systematic {
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Data.Mapping.Shared;

	public sealed class LanguageMap : AttributeMapBase<Language> {
		public LanguageMap() {
			Property(l => l.NativeName);
			Property(l => l.CultureCode);
			Set(l => l.Values);
		}
	}
}
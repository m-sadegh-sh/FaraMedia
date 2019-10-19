namespace FaraMedia.Data.Mapping.Configuration {
	using FaraMedia.Core.Domain.Configuration;

	public sealed class SettingMap : EntityMapBase<Setting> {
		public SettingMap() {
			Property(s => s.Key,
			         pm => pm.Unique(true));
			Property(s => s.Value);
		}
	}
}
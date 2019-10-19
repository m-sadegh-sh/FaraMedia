namespace FaraMedia.Core.Domain.Configuration {
	public class SystemSettings : ISettings {
		public bool IsClosed { get; set; }
		public string CloseReason { get; set; }
		public bool MobileDevicesSupported { get; set; }
		public bool EnableHttpCompression { get; set; }
		public bool LoadAllLocaleRecordsOnStartup { get; set; }
		public bool ShowHeaderRssUrl { get; set; }
		public bool CaseInvariantReplacement { get; set; }
		public bool ConvertNonWesternChars { get; set; }
		public bool AllowUnicodeCharsInUrls { get; set; }
		public bool CanonicalUrlsEnabled { get; set; }
		public int DashboardPageSize { get; set; }
		public int MainPageSize { get; set; }
		public int ArchivePageSize { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public string DefaultTitle { get; set; }
		public string DefaultMetaKeywords { get; set; }
		public string DefaultMetaDescription { get; set; }
		public string TitleSeparator { get; set; }
		public string BreadcrumbSeparator { get; set; }
		public long? DefaultEmailAccountId { get; set; }
		public bool AllowUsersToSetTimeZone { get; set; }
		public string DefaultTimeZoneId { get; set; }
		public bool AllowUsersToSetLanguage { get; set; }
		public long? DefaultLanguageId { get; set; }
		public bool ImmediatelyRedirection { get; set; }
		public int RedirectionDelay { get; set; }
	}
}
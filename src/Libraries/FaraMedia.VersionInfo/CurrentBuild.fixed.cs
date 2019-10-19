namespace FaraMedia.VersionInfo {
	using System.Reflection;

	public sealed class CurrentBuild {
		public const string Company = "FaraSun™ Inc";
		public const string Copyright = "Copyright © FaraMedia™ Inc 2012";
		public const string Trademark = "FaraSun™";
		public const string Culture = "fa-IR";
		public const string AssemblyVersion = "1.0.*";
		public const string AssemblyFileVersion = "1.0.0.0";

		public static string CurrentVersion {
			get {
				return Assembly.GetExecutingAssembly().
				                GetName().
				                Version.ToString();
			}
		}
	}
}
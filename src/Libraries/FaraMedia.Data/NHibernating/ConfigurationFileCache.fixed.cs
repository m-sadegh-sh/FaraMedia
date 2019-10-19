namespace FaraMedia.Data.NHibernating {
	using System.IO;
	using System.Reflection;
	using System.Runtime.Serialization.Formatters.Binary;

	using FaraMedia.Core;
	using FaraMedia.Core.Configuration;

	using NHibernate.Cfg;

	public sealed class ConfigurationFileCache {
		private readonly string _cacheFile;
		private readonly Assembly _definitionsAssembly;

		public ConfigurationFileCache(FaraConfig faraConfig,
		                              Assembly definitionsAssembly,
		                              IWebHelper webHelper) {
			_definitionsAssembly = definitionsAssembly;
			_cacheFile = webHelper.MapPath(faraConfig.ConfigurationCacheFileName);
		}

		public void DeleteCacheFile() {
			if (File.Exists(_cacheFile))
				File.Delete(_cacheFile);
		}

		public bool IsConfigurationFileValid {
			get {
				if (!File.Exists(_cacheFile))
					return false;

				var configInfo = new FileInfo(_cacheFile);
				var asmInfo = new FileInfo(_definitionsAssembly.Location);

				if (configInfo.Length < 5*1024)
					return false;

				return configInfo.LastWriteTime >= asmInfo.LastWriteTime;
			}
		}

		public void SaveConfigurationToFile(Configuration configuration) {
			using (var file = File.Open(_cacheFile,
			                            FileMode.Create)) {
				var binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(file,
				                          configuration);
			}
		}

		public Configuration LoadConfigurationFromFile() {
			if (!IsConfigurationFileValid)
				return null;

			using (var file = File.Open(_cacheFile,
			                            FileMode.Open,
			                            FileAccess.Read)) {
				var binaryFormatter = new BinaryFormatter();
				return binaryFormatter.Deserialize(file) as Configuration;
			}
		}
	}
}
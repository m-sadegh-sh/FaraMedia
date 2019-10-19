namespace FaraMedia.Core.Configuration {
	using System.Xml;

	public sealed class FaraConfig : ConfigBase<FaraConfig> {
		private static FaraConfig _current;

		public static FaraConfig Current {
			get {
				if (_current == null)
					_current = Load<FaraConfig>();

				return _current;
			}
		}

		public bool DynamicDiscovery { get; private set; }
		public string EngineType { get; private set; }
		public string ConnectionStringName { get; private set; }
		public string ConfigurationCacheFileName { get; private set; }

		public override object Create(object parent,
		                              object configContext,
		                              XmlNode section) {
			var config = new FaraConfig {
					DynamicDiscovery = GetAttribute(section,
					                                fc => fc.DynamicDiscovery),
					EngineType = GetAttribute(section,
					                          fc => fc.EngineType),
					ConnectionStringName = GetAttribute(section,
					                                    fc => fc.ConnectionStringName),
					ConfigurationCacheFileName = GetAttribute(section,
					                                          fc => fc.ConfigurationCacheFileName)
			};

			return config;
		}
	}
}
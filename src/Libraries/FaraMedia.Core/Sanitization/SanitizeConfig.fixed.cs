namespace FaraMedia.Core.Sanitization {
	using System.Xml;

	using FaraMedia.Core.Configuration;

	public sealed class SanitizeConfig : ConfigBase<SanitizeConfig> {
		private static SanitizeConfig _current;

		public static SanitizeConfig Current {
			get {
				if (_current == null)
					_current = Load<SanitizeConfig>();

				return _current;
			}
		}

		public bool UseLowerCase { get; private set; }
		public bool RemoveNonWesternCharacters { get; private set; }
		public bool TrimMultipleSeparators { get; private set; }
		public string Separator { get; private set; }

		public override object Create(object parent,
		                              object configContext,
		                              XmlNode section) {
			var config = new SanitizeConfig {
					UseLowerCase = GetAttribute(section,
					                            sc => sc.UseLowerCase),
					RemoveNonWesternCharacters = GetAttribute(section,
					                                          sc => sc.RemoveNonWesternCharacters),
					TrimMultipleSeparators = GetAttribute(section,
					                                      sc => sc.TrimMultipleSeparators),
					Separator = GetAttribute(section,
					                         sc => sc.Separator)
			};

			return config;
		}
	}
}
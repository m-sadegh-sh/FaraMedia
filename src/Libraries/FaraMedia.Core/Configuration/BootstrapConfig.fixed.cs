namespace FaraMedia.Core.Configuration {
	using System.Xml;

	public sealed class BootstrapConfig : ConfigBase<BootstrapConfig> {
		private static BootstrapConfig _current;

		public static BootstrapConfig Current {
			get {
				if (_current == null)
					_current = Load<BootstrapConfig>();

				return _current;
			}
		}

		public string UserName { get; private set; }
		public string Password { get; private set; }
		public string Email { get; private set; }

		public override object Create(object parent,
		                              object configContext,
		                              XmlNode section) {
			var config = new BootstrapConfig {
					UserName = GetAttribute(section,
					                        bc => bc.UserName),
					Password = GetAttribute(section,
					                        bc => bc.Password),
					Email = GetAttribute(section,
					                     bc => bc.Email)
			};

			return config;
		}
	}
}
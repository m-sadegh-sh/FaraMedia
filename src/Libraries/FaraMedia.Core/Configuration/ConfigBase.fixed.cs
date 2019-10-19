namespace FaraMedia.Core.Configuration {
	using System;
	using System.Configuration;
	using System.Linq.Expressions;
	using System.Xml;

	using TB.ComponentModel;

	using Utilities.DataTypes.ExtensionMethods;
	using Utilities.Reflection.ExtensionMethods;

	public abstract class ConfigBase<TConfig> : IConfigurationSectionHandler where TConfig : ConfigBase<TConfig> {
		public abstract object Create(object parent,
		                              object configContext,
		                              XmlNode section);

		protected static T Load<T>() where T : class, new() {
			var configName = typeof (T).Name.ToTitleCase();

			var config = ConfigurationManager.GetSection(configName) as T;

			return config ?? new T();
		}

		protected TProperty GetAttribute<TProperty>(XmlNode section,
		                                            Expression<Func<TConfig, TProperty>> property,
		                                            TProperty defaultValue = default(TProperty)) {
			var value = GetAttributeCore(section,
			                             property);

			if (value.CanConvertTo<TProperty>())
				return value.ConvertTo<TProperty>();

			return defaultValue;
		}

		private static object GetAttributeCore<TProperty>(XmlNode section,
		                                                  Expression<Func<TConfig, TProperty>> property) {
			if (section.Attributes != null) {
				var propertyName = property.GetPropertyName();
				var attribute = section.Attributes[propertyName];

				if (attribute != null)
					return attribute.Value;
			}

			return null;
		}
	}
}
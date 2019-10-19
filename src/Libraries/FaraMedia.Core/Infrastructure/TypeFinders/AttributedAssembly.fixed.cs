namespace FaraMedia.Core.Infrastructure.TypeFinders {
	using System;
	using System.Reflection;

	internal sealed class AttributedAssembly {
		public Assembly Assembly { get; set; }
		public Type PluginAttributeType { get; set; }
	}
}
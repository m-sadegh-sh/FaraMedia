namespace FaraMedia.Data.Mapping.Extensions {
	using System;

	using FaraMedia.Core.Infrastructure.Extensions;

	public static class MappingExtensions {
		private static readonly string _rootNamespace;

		static MappingExtensions() {
			_rootNamespace = typeof (EntityMapBase<>).Namespace.ToStringOrEmpty();
			_rootNamespace = _rootNamespace.Replace("Common",
			                                        "");
		}

		public static bool IsMappingType(this Type type) {
			if (type == null)
				return false;

			if (!type.IsClass)
				return false;

			if (type.IsAbstract)
				return false;

			if (type.Namespace != null && type.Namespace.StartsWith(_rootNamespace))
				return true;

			return false;
		}
	}
}
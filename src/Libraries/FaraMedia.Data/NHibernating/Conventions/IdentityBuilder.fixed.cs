namespace FaraMedia.Data.NHibernating.Conventions {
	using System;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Infrastructure.Extensions;

	using Utilities.DataTypes.ExtensionMethods;

	public static class IdentityBuilder {
		public static string BuildSchema(string @namespace) {
			var lastDotPosition = @namespace.LastIndexOf(".",
			                                             StringComparison.Ordinal) + 1;
			var schema = @namespace.Substring(lastDotPosition,
			                                  @namespace.Length - lastDotPosition);

			return Scape(schema);
		}

		public static string BuildTableName(string typeName) {
			var tableName = typeName.Pluralize();

			return Scape(tableName);
		}

		public static string BuildTableName<T>(string childTypeName) where T : class {
			var parentTypeName = typeof (T).Name;

			var tableName = string.Concat(parentTypeName,
			                              childTypeName).
			                       Pluralize();

			return Scape(tableName);
		}

		public static string BuildColumnName(params string[] columnNames) {
			var columnName = columnNames.Aggregate("",
			                                       (current,
			                                        result) => current + result);

			if (string.IsNullOrEmpty(columnName)) {
				columnName = string.Concat(CommonHelper.GenerateRandomDigitCode(10),
				                           ConventionNames.PrimaryKeyPostfix);
			}

			return Scape(columnName);
		}

		public static string BuildKeyName(params string[] candidateKeyNames) {
			var keyName = "";

			foreach (var candidateKeyName in candidateKeyNames) {
				if (!string.IsNullOrEmpty(candidateKeyName)) {
					keyName = string.Concat(candidateKeyName,
					                        ConventionNames.PrimaryKeyPostfix);
				}
			}

			if (string.IsNullOrEmpty(keyName)) {
				keyName = string.Concat(CommonHelper.GenerateRandomDigitCode(10),
				                        ConventionNames.PrimaryKeyPostfix);
			}

			return Scape(keyName);
		}

		public static string BuildIndex(Type type) {
			var typeName = type.Name.Pluralize();
			var randomMixedString = CommonHelper.GenerateRandomMixedString(16).
			                                     ToUpper();

			return string.Format("IX__{0}__{1}",
			                     typeName,
			                     randomMixedString);
		}

		private static string Scape(string unscapedString) {
			return string.Format("`{0}`",
			                     unscapedString);
		}

		public static string DefaultSeed() {
			return DateTime.UtcNow.GetTimestamp();
		}
	}
}
namespace FaraMedia.Core {
	using System;

	using CuttingEdge.Conditions;

	using FaraMedia.Core.Domain;

	public static class Neutrals {
		public static bool Is<TEnum>(TEnum? value) where TEnum : struct {
			Condition.Requires(typeof (TEnum),
			                   "value").
			          Evaluate(t => !t.IsEnum);

			return value == null;
		}

		public static bool Is(Guid value) {
			return value == Guid.Empty;
		}

		public static bool Is(Guid? value) {
			return value == null || Is(value.Value);
		}

		public static bool Is(sbyte value) {
			return value < 1;
		}

		public static bool Is(sbyte? value) {
			return value.HasValue && Is(value.Value);
		}

		public static bool Is(byte value) {
			return value < 1;
		}

		public static bool Is(byte? value) {
			return value.HasValue && Is(value.Value);
		}

		public static bool Is(short value) {
			return value < 1;
		}

		public static bool Is(short? value) {
			return value.HasValue && Is(value.Value);
		}

		public static bool Is(ushort value) {
			return value < 1;
		}

		public static bool Is(ushort? value) {
			return value.HasValue && Is(value.Value);
		}

		public static bool Is(int value) {
			return value < 1;
		}

		public static bool Is(int? value) {
			return value.HasValue && Is(value.Value);
		}

		public static bool Is(uint value) {
			return value < 1;
		}

		public static bool Is(uint? value) {
			return value.HasValue && Is(value.Value);
		}

		public static bool Is(long value) {
			return value < 1;
		}

		public static bool Is(long? value) {
			return value.HasValue && Is(value.Value);
		}

		public static bool Is(ulong value) {
			return value < 1;
		}

		public static bool Is(ulong? value) {
			return value.HasValue && Is(value.Value);
		}

		public static bool Is(float value) {
			return value < 1;
		}

		public static bool Is(float? value) {
			return value.HasValue && Is(value.Value);
		}

		public static bool Is(double value) {
			return value < 1;
		}

		public static bool Is(double? value) {
			return value.HasValue && Is(value.Value);
		}

		public static bool Is(decimal value) {
			return value < 1;
		}

		public static bool Is(decimal? value) {
			return value.HasValue && Is(value.Value);
		}

		public static bool Is(string value) {
			return string.IsNullOrWhiteSpace(value);
		}

		public static bool Is<TEntity>(TEntity value) where TEntity : EntityBase {
			return value == null || value.Id == default(long);
		}
	}
}
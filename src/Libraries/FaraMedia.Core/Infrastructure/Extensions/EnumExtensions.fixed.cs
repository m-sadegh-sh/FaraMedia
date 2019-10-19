namespace FaraMedia.Core.Infrastructure.Extensions {
	using System.Linq;

	using CuttingEdge.Conditions;

	using Dnum;

	public static class EnumExtensions {
		public static int GetLowerBound<TEnum>() where TEnum : struct {
			Condition.Requires(typeof (TEnum),
			                   "TEnum").
			          Evaluate(t => !t.IsEnum);

			var values = Dnum<TEnum>.GetValues();

			return values.First();
		}

		public static int GetUpperBound<TEnum>() where TEnum : struct {
			Condition.Requires(typeof (TEnum),
			                   "TEnum").
			          Evaluate(t => !t.IsEnum);

			var values = Dnum<TEnum>.GetValues();

			return values.Last();
		}
	}
}
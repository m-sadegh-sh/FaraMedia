namespace FaraMedia.Core.Infrastructure.Extensions {
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	using CuttingEdge.Conditions;

	public static class EnumerableExtensions {
		public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source) {
			Condition.Requires(source,
			                   "source").
			          IsNotNull();

			return new ObservableCollection<T>(source);
		}
	}
}
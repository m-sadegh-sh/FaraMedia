namespace FaraMedia.Data.Schemas {
	using FaraMedia.Core.Domain;

	public abstract class ConstantsBase<T> where T : class {
		protected static readonly ConstantKeyHelpers<T> Helpers = new ConstantKeyHelpers<T>();
	}
}
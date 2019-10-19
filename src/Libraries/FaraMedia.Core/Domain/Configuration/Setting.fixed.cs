namespace FaraMedia.Core.Domain.Configuration {
	using TB.ComponentModel;

	public class Setting : EntityBase {
		public virtual string Key { get; set; }
		public virtual string Value { get; set; }

		public virtual T As<T>() {
			return Value.ConvertTo<T>();
		}

		public override string ToString() {
			return Key;
		}
	}
}
namespace FaraMedia.Core {
	public interface ISimpleState {
		T Get<T>(string key);

		void Store(string key,
		           object something);
	}
}
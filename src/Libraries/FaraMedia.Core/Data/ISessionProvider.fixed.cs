namespace FaraMedia.Core.Data {
	using NHibernate;

	public interface ISessionProvider {
		ISession Create();
		IStatelessSession CreateStateless();
	}
}
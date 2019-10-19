namespace FaraMedia.Data {
	using FaraMedia.Core.Data;
	using FaraMedia.Data.NHibernating;

	using NHibernate;

	public sealed class SessionProvider : ISessionProvider {
		private readonly ISessionFactory _sessionFactory;

		public SessionProvider(NHibernateConfigurer configurer) {
			_sessionFactory = configurer.SetUpSessionFactory();
		}

		public ISession Create() {
			var session = _sessionFactory.OpenSession();

			return session;
		}

		public IStatelessSession CreateStateless() {
			var session = _sessionFactory.OpenStatelessSession();
			session.SetBatchSize(DbConstants.BatchSize);

			return session;
		}
	}
}
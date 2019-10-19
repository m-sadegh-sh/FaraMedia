namespace FaraMedia.Data {
	using FaraMedia.Core;
	using FaraMedia.Core.Data;

	using NHibernate;

	public sealed class ActiveSessionManager : DisposableBase,
	                                           IActiveSessionManager {
		private const string SESSION_KEY = "_currentSession";

		private readonly ISimpleState _state;
		private readonly ISessionProvider _provider;

		public ActiveSessionManager(ISimpleState state,
		                            ISessionProvider provider) {
			_state = state;
			_provider = provider;
		}

		public ISession GetActiveSession() {
			if (Current == null) {
				var session = _provider.Create();

				Current = session;

				return session;
			}

			return Current;
		}

		public void ClearActiveSession() {
			Current = null;
		}

		public bool HasActiveSession {
			get { return Current != null; }
		}

		protected virtual ISession Current {
			get { return _state.Get<ISession>(SESSION_KEY); }
			set {
				_state.Store(SESSION_KEY,
				             value);
			}
		}

		protected override void CoreDispose(bool disposeManagedResources) {
			var session = Current;

			if (session != null) {
				session.Dispose();
				ClearActiveSession();
			}
		}
	}
}
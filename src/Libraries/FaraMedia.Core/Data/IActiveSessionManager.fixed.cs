namespace FaraMedia.Core.Data {
	using System;

	using NHibernate;

	public interface IActiveSessionManager : IDisposable {
		ISession GetActiveSession();
		void ClearActiveSession();
		bool HasActiveSession { get; }
	}
}
namespace FaraMedia.Data {
	using System;

	using FaraMedia.Core;
	using FaraMedia.Core.Data;

	using NHibernate;

	public sealed class UnitOfWork : DisposableBase,
	                                 IUnitOfWork {
		private readonly IActiveSessionManager _manager;
		private ITransaction _transaction;

		public UnitOfWork(IActiveSessionManager manager) {
			_manager = manager;
		}

		public void BeginTransaction() {
			if (_transaction != null)
				throw new InvalidOperationException("Transaction already started; nested transactions are not supported.");

			_transaction = _manager.GetActiveSession().
			                        BeginTransaction();
		}

		public void EndTransaction() {
			if (_transaction == null)
				throw new InvalidOperationException("No active transaction found.");

			if (!_transaction.IsActive)
				throw new InvalidOperationException("This transaction is no longer active.");

			try {
				_transaction.Commit();
			} catch (Exception) {
				RollBack();
			}
		}

		public void RollBack() {
			if (_transaction == null)
				throw new InvalidOperationException("No active transaction found.");

			_transaction.Rollback();
		}

		protected override void CoreDispose(bool disposeManagedResources) {
			if (_transaction != null)
				_transaction.Dispose();

			_manager.Dispose();
		}
	}
}
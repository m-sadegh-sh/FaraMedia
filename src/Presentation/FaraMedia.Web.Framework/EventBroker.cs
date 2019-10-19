namespace FaraMedia.Core.Infrastructure {
	using System;
	using System.Web;

	using FaraMedia.Core.Patterns;

	public class EventBroker {
		public EventHandler<EventArgs> AcquireRequestState;
		public EventHandler<EventArgs> AuthorizeRequest;
		public EventHandler<EventArgs> BeginRequest;
		public EventHandler<EventArgs> EndRequest;
		public EventHandler<EventArgs> Error;
		public EventHandler<EventArgs> PostMapRequestHandler;
		public EventHandler<EventArgs> PostResolveRequestCache;

		static EventBroker() {
			Instance = new EventBroker();
		}

		public static EventBroker Instance {
			get { return Singleton<EventBroker>.Instance; }
			protected set { Singleton<EventBroker>.Instance = value; }
		}

		public virtual void Attach(HttpApplication application) {
			application.BeginRequest += OnBeginRequest;
			application.AuthorizeRequest += OnAuthorizeRequest;

			application.PostResolveRequestCache += OnPostResolveRequestCache;
			application.PostMapRequestHandler += Application_PostMapRequestHandler;

			application.AcquireRequestState += OnAcquireRequestState;
			application.Error += OnError;
			application.EndRequest += OnEndRequest;

			application.Disposed += OnDisposed;
		}

		protected void OnBeginRequest(object sender,
		                              EventArgs e) {
			if (BeginRequest != null) {
				BeginRequest(sender,
				             e);
			}
		}

		protected void OnAuthorizeRequest(object sender,
		                                  EventArgs e) {
			if (AuthorizeRequest != null) {
				AuthorizeRequest(sender,
				                 e);
			}
		}

		private void OnPostResolveRequestCache(object sender,
		                                       EventArgs e) {
			if (PostResolveRequestCache != null) {
				PostResolveRequestCache(sender,
				                        e);
			}
		}

		private void Application_PostMapRequestHandler(object sender,
		                                               EventArgs e) {
			if (PostMapRequestHandler != null) {
				PostMapRequestHandler(sender,
				                      e);
			}
		}

		protected void OnAcquireRequestState(object sender,
		                                     EventArgs e) {
			if (AcquireRequestState != null) {
				AcquireRequestState(sender,
				                    e);
			}
		}

		protected void OnError(object sender,
		                       EventArgs e) {
			if (Error != null) {
				Error(sender,
				      e);
			}
		}

		protected void OnEndRequest(object sender,
		                            EventArgs e) {
			if (EndRequest != null) {
				EndRequest(sender,
				           e);
			}
		}

		private static void OnDisposed(object sender,
		                               EventArgs e) {}
	}
}
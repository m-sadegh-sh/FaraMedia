namespace FaraMedia.Web.Framework.StaticHandler {
    using System;
    using System.Threading;
    using System.Web;

    public class HttpAsyncResult : IAsyncResult {
        private readonly object _asyncState;
        private readonly AsyncCallback _callback;
        private object _result;

        public HttpAsyncResult(AsyncCallback asyncCallback, object state) {
            _callback = asyncCallback;
            _asyncState = state;
            Status = RequestNotificationStatus.Continue;
        }

        public HttpAsyncResult(AsyncCallback asyncCallback, object state, bool completed, object result, Exception error) {
            _callback = asyncCallback;
            _asyncState = state;
            IsCompleted = completed;
            CompletedSynchronously = completed;
            _result = result;
            Error = error;
            Status = RequestNotificationStatus.Continue;
            if (IsCompleted && (_callback != null))
                _callback(this);
        }

        public Exception Error { get; private set; }

        public RequestNotificationStatus Status { get; private set; }

        public object AsyncState {
            get { return _asyncState; }
        }

        public WaitHandle AsyncWaitHandle {
            get { return null; }
        }

        public bool CompletedSynchronously { get; private set; }

        public bool IsCompleted { get; private set; }

        public void Complete(bool synchronous, object result, Exception error) {
            Complete(synchronous, result, error, RequestNotificationStatus.Continue);
        }

        public void Complete(bool synchronous, object result, Exception error, RequestNotificationStatus status) {
            IsCompleted = true;
            CompletedSynchronously = synchronous;
            _result = result;
            Error = error;
            Status = status;
            if (_callback != null)
                _callback(this);
        }

        public object End() {
            if (Error != null)
                throw new HttpException(null, Error);
            return _result;
        }

        public void SetComplete() {
            IsCompleted = true;
        }
    }
}
namespace FaraMedia.Web.Framework.Modules {
    using System.Web;

    using FaraMedia.Core;

    public abstract class HttpModuleBase : DisposableBase, IHttpModule {
        public void Init(HttpApplication context) {
            context.AuthenticateRequest += (sender, e) => OnAuthenticateRequest(new HttpContextWrapper(((HttpApplication) sender).Context));
            context.UserizeRequest += (sender, e) => OnUserizeRequest(new HttpContextWrapper(((HttpApplication) sender).Context));
            context.BeginRequest += (sender, e) => OnBeginRequest(new HttpContextWrapper(((HttpApplication) sender).Context));
            context.Error += (sender, e) => OnError(new HttpContextWrapper(((HttpApplication) sender).Context));
            context.PreSendRequestHeaders += (sender, e) => OnPreSendRequestHeaders(new HttpContextWrapper(((HttpApplication) sender).Context));
            context.PreSendRequestContent += (sender, e) => OnPreSendRequestHeaders(new HttpContextWrapper(((HttpApplication) sender).Context));
            context.EndRequest += (sender, e) => OnEndRequest(new HttpContextWrapper(((HttpApplication) sender).Context));
        }

        protected virtual void OnAuthenticateRequest(HttpContextBase context) {}

        protected virtual void OnUserizeRequest(HttpContextBase context) {}

        protected virtual void OnBeginRequest(HttpContextBase context) {}

        protected virtual void OnError(HttpContextBase context) {}

        protected virtual void OnPreSendRequestContent(HttpContextBase context) {}

        protected virtual void OnPreSendRequestHeaders(HttpContextBase context) {}

        protected virtual void OnEndRequest(HttpContextBase context) {}

        protected override void CoreDispose(bool disposeManagedResources) {}
    }
}
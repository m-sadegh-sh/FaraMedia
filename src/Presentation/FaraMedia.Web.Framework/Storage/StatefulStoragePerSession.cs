namespace FaraMedia.Web.Framework.Storage {
    using System.Web;

    public class StatefulStoragePerSession : DictionaryStatefulStorage {
        public StatefulStoragePerSession() : base(key => HttpContext.Current.Session[key], (key, value) => HttpContext.Current.Session[key] = value) {}

        public StatefulStoragePerSession(HttpSessionStateBase session) : base(key => session[key], (key, value) => session[key] = value) {}
    }
}
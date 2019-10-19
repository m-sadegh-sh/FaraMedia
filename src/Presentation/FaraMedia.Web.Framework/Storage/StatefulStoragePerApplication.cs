namespace FaraMedia.Web.Framework.Storage {
    using System.Web;

    public class StatefulStoragePerApplication : DictionaryStatefulStorage {
        public StatefulStoragePerApplication() : base(key => HttpContext.Current.Application[key], (key, value) => HttpContext.Current.Application[key] = value) {}

        public StatefulStoragePerApplication(HttpApplicationStateBase app) : base(key => app[key], (key, value) => app[key] = value) {}
    }
}
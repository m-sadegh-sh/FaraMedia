namespace FaraMedia.Web.Framework.Storage {
    using System.Web;

    public class StatefulStoragePerRequest : DictionaryStatefulStorage {
        public StatefulStoragePerRequest() : base(() => HttpContext.Current.Items) {}

        public StatefulStoragePerRequest(HttpContextBase context) : base(() => context.Items) {}
    }
}
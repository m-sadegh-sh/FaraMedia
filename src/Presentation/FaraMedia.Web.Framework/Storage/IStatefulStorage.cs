namespace FaraMedia.Web.Framework.Storage {
    using System;

    public interface IStatefulStorage {
        TValue Get<TValue>(string name);
        TValue GetOrAdd<TValue>(string name, Func<TValue> valueFactory);
    }
}
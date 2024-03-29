namespace FaraMedia.Web.Framework.Storage {
    using System;

    public static class StatefulStorageExtensions {
        public static TValue Get<TValue>(this IStatefulStorage storage) {
            return storage.Get<TValue>(null);
        }

        public static TValue GetOrAdd<TValue>(this IStatefulStorage storage, Func<TValue> valueFactory) {
            return storage.GetOrAdd(null, valueFactory);
        }
    }
}
namespace FaraMedia.Web.Framework.Storage {
    using System;
    using System.Collections;

    public abstract class DictionaryStatefulStorage : IStatefulStorage {
        private readonly Func<string, object> _getter;
        private readonly Action<string, object> _setter;

        protected DictionaryStatefulStorage(Func<IDictionary> dictionaryAccessor) {
            _getter = key => dictionaryAccessor()[key];
            _setter = (key, value) => dictionaryAccessor()[key] = value;
        }

        protected DictionaryStatefulStorage(Func<string, object> getter, Action<string, object> setter) {
            _getter = getter;
            _setter = setter;
        }

        public TValue Get<TValue>(string name) {
            return (TValue) _getter(FullNameOf(typeof (TValue), name));
        }

        public TValue GetOrAdd<TValue>(string name, Func<TValue> valueFactory) {
            var fullName = FullNameOf(typeof (TValue), name);
            var result = (TValue) _getter(fullName);

            if (Equals(result, default(TValue))) {
                result = valueFactory();
                _setter(fullName, result);
            }

            return result;
        }

        protected static string FullNameOf(Type type, string name) {
            var fullName = type.FullName;
            if (!string.IsNullOrWhiteSpace(name))
                fullName += "::" + name;

            return fullName;
        }
    }
}
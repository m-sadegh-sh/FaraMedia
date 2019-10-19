namespace FaraMedia.Services.Utilities {
    public sealed class Token {
        private readonly string _key;
        private readonly bool _neverHtmlEncoded;
        private readonly string _value;

        public Token(string key, string value) : this(key, value, false) {}

        public Token(string key, string value, bool neverHtmlEncoded) {
            _key = key;
            _value = value;
            _neverHtmlEncoded = neverHtmlEncoded;
        }

        public string Key {
            get { return _key; }
        }

        public string Value {
            get { return _value; }
        }

        public bool NeverHtmlEncoded {
            get { return _neverHtmlEncoded; }
        }

        public override string ToString() {
            return string.Format("{0}: {1}", Key, Value);
        }
    }
}
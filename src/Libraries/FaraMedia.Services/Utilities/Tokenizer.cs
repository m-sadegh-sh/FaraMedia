namespace FaraMedia.Services.Utilities {
    using System;
    using System.Collections.Generic;
    using System.Web;

    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Services.Systematic;

    public sealed class Tokenizer : ITokenizer {
        private readonly StringComparison _stringComparison;

        public Tokenizer(SystemSettings systemSettings) {
            _stringComparison = systemSettings.CaseInvariantReplacement ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
        }

        public string Replace(string template, IEnumerable<Token> tokens, bool htmlEncode) {
            if (string.IsNullOrEmpty(template))
                throw new ArgumentNullException("template");

            if (tokens == null)
                throw new ArgumentNullException("tokens");

            foreach (var token in tokens) {
                var tokenValue = token.Value;

                if (htmlEncode && !token.NeverHtmlEncoded)
                    tokenValue = HttpUtility.HtmlEncode(tokenValue);

                template = Replace(template, string.Format(@"%{0}%", token.Key), tokenValue);
            }

            return template;
        }

        private string Replace(string original, string pattern, string replacement) {
            if (_stringComparison == StringComparison.Ordinal)
                return original.Replace(pattern, replacement);

            int position0, position1;
            var count = position0 = 0;
            var inc = (original.Length/pattern.Length)*(replacement.Length - pattern.Length);
            var chars = new char[original.Length + Math.Max(0, inc)];

            while ((position1 = original.IndexOf(pattern, position0, _stringComparison)) != -1) {
                for (var i = position0; i < position1; ++i)
                    chars[count++] = original[i];
                
                foreach (var t in replacement)
                    chars[count++] = t;

                position0 = position1 + pattern.Length;
            }

            if (position0 == 0)
                return original;

            for (var i = position0; i < original.Length; ++i)
                chars[count++] = original[i];

            return new string(chars, 0, count);
        }
    }
}
namespace FaraMedia.Services.Utilities {
    using System.Collections.Generic;

    public interface ITokenizer {
        string Replace(string template, IEnumerable<Token> tokens, bool htmlEncode);
    }
}
namespace FaraMedia.Web.Framework.Parsers {
    public enum JsonToken
    {
        None,
        CurlyOpen,
        CurlyClose,
        SquaredOpen,
        SquaredClose,
        Colon,
        Comma,
        StringSingleQuotation,
        StringDoubleQuotation,
        Number,
        True,
        False,
        Null
    }
}
namespace FaraMedia.Web.Framework.Parsers {
    using System;
    using System.Globalization;
    using System.Text;

    using FaraMedia.Web.Framework.Modules;

    public class JsonParser {
        private const int BUILDER_CAPACITY = 2000;

        public static char[] FixJsonString(string json) {
            if (json != null) {
                var charArray = json.ToCharArray();
                var index = 0;

                if (!ParseValue(charArray, ref index, true))
                    return null;

                return charArray;
            }
            return null;
        }

        protected static bool ParseObject(char[] json, ref int index) {
            NextToken(json, ref index);

            while (true) {
                var token = LookAhead(json, index);

                switch (token) {
                    case JsonToken.None:
                        return false;
                    case JsonToken.Comma:
                        NextToken(json, ref index);
                        break;
                    case JsonToken.CurlyClose:
                        NextToken(json, ref index);
                        return true;
                    default: {
                        var name = ParseString(json, ref index, false);
                        if (name == null)
                            return false;

                        token = NextToken(json, ref index);
                        if (token != JsonToken.Colon)
                            return false;

                        if (!ParseValue(json, ref index, FixFarsiCharsModule.ShouldFixField(name)))
                            return false;
                    }
                        break;
                }
            }
        }

        protected static bool ParseArray(char[] json, ref int index) {
            NextToken(json, ref index);

            while (true) {
                var token = LookAhead(json, index);

                if (token == JsonToken.None)
                    return false;

                if (token == JsonToken.Comma)
                    NextToken(json, ref index);

                else if (token == JsonToken.SquaredClose) {
                    NextToken(json, ref index);
                    break;
                } else {
                    if (!ParseValue(json, ref index, true))
                        return false;
                }
            }

            return true;
        }

        protected static bool ParseValue(char[] json, ref int index, bool shouldFixString) {
            switch (LookAhead(json, index)) {
                case JsonToken.StringSingleQuotation:
                case JsonToken.StringDoubleQuotation:
                    return ParseString(json, ref index, shouldFixString) != null;
                case JsonToken.Number:
                    return ParseNumber(json, ref index);
                case JsonToken.CurlyOpen:
                    return ParseObject(json, ref index);
                case JsonToken.SquaredOpen:
                    return ParseArray(json, ref index);
                case JsonToken.True:
                    NextToken(json, ref index);
                    return true;
                case JsonToken.False:
                    NextToken(json, ref index);
                    return true;
                case JsonToken.Null:
                    NextToken(json, ref index);
                    return true;
                case JsonToken.None:
                    break;
            }
            return false;
        }

        protected static string ParseString(char[] json, ref int index, bool shouldFixString) {
            var stringBuilder = new StringBuilder(BUILDER_CAPACITY);

            EatWhitespace(json, ref index);

            var stringToken = json[index++] == '"' ? JsonToken.StringDoubleQuotation : JsonToken.StringSingleQuotation;

            var complete = false;
            while (true) {
                if (index == json.Length)
                    break;

                var c = json[index++];
                if ((stringToken == JsonToken.StringDoubleQuotation && c == '"') ||
                    (stringToken == JsonToken.StringSingleQuotation && c == '\'')) {
                    complete = true;
                    break;
                }

                if (c == '\\') {
                    if (index == json.Length)
                        break;
                    c = json[index++];
                    if (c == '"')
                        stringBuilder.Append('"');
                    else if (c == '\\')
                        stringBuilder.Append('\\');
                    else if (c == '/')
                        stringBuilder.Append('/');
                    else if (c == 'b')
                        stringBuilder.Append('\b');
                    else if (c == 'f')
                        stringBuilder.Append('\f');
                    else if (c == 'n')
                        stringBuilder.Append('\n');
                    else if (c == 'r')
                        stringBuilder.Append('\r');
                    else if (c == 't')
                        stringBuilder.Append('\t');
                    else if (c == 'u') {
                        var remainingLength = json.Length - index;

                        if (remainingLength >= 4) {
                            uint codePoint;

                            if (!UInt32.TryParse(new string(json, index, 4), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out codePoint))
                                return null;

                            stringBuilder.Append(Char.ConvertFromUtf32((int) codePoint));

                            index += 4;
                        } else
                            break;
                    }
                } else {
                    stringBuilder.Append(c);
                    if (shouldFixString)
                        json[index - 1] = FixFarsiCharsModule.FixValue(c);
                }
            }

            return complete ? stringBuilder.ToString() : null;
        }

        protected static bool ParseNumber(char[] json, ref int index) {
            index = GetLastIndexOfNumber(json, index) + 1;

            return true;
        }

        protected static int GetLastIndexOfNumber(char[] json, int index) {
            int lastIndex;

            for (lastIndex = index; lastIndex < json.Length; lastIndex++) {
                if ("0123456789+-.eE".IndexOf(json[lastIndex]) == -1)
                    break;
            }

            return lastIndex - 1;
        }

        protected static void EatWhitespace(char[] json, ref int index) {
            for (; index < json.Length; index++) {
                if (" \t\n\r".IndexOf(json[index]) == -1)
                    break;
            }
        }

        protected static JsonToken LookAhead(char[] json, int index) {
            var saveIndex = index;

            return NextToken(json, ref saveIndex);
        }

        protected static JsonToken NextToken(char[] json, ref int index) {
            EatWhitespace(json, ref index);

            if (index == json.Length)
                return JsonToken.None;

            var c = json[index];
            index++;

            switch (c) {
                case '{':
                    return JsonToken.CurlyOpen;
                case '}':
                    return JsonToken.CurlyClose;
                case '[':
                    return JsonToken.SquaredOpen;
                case ']':
                    return JsonToken.SquaredClose;
                case ',':
                    return JsonToken.Comma;
                case '\'':
                    return JsonToken.StringSingleQuotation;
                case '"':
                    return JsonToken.StringDoubleQuotation;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '-':
                    return JsonToken.Number;
                case ':':
                    return JsonToken.Colon;
            }
            index--;

            var remainingLength = json.Length - index;

            if (remainingLength >= 5) {
                if (json[index] == 'f' &&
                    json[index + 1] == 'a' &&
                    json[index + 2] == 'l' &&
                    json[index + 3] == 's' &&
                    json[index + 4] == 'e') {
                    index += 5;
                    return JsonToken.False;
                }
            }

            if (remainingLength >= 4) {
                if (json[index] == 't' &&
                    json[index + 1] == 'r' &&
                    json[index + 2] == 'u' &&
                    json[index + 3] == 'e') {
                    index += 4;
                    return JsonToken.True;
                }
            }

            if (remainingLength >= 4) {
                if (json[index] == 'n' &&
                    json[index + 1] == 'u' &&
                    json[index + 2] == 'l' &&
                    json[index + 3] == 'l') {
                    index += 4;
                    return JsonToken.Null;
                }
            }

            return JsonToken.None;
        }
    }
}
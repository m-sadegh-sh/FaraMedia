namespace FaraMedia.Web.Framework.Optimization {
    using System.Text.RegularExpressions;

    using Microsoft.Ajax.Miscellaneous;

    public class FaraMinifier : Minifier {
        public string MinifyHtml(string source) {
            source = Regex.Replace(source, @"\n|\t", " ");
            source = Regex.Replace(source, @">\s+<", "><");
            source = Regex.Replace(source, @"\s{2,}", " ");

            return source;
        }
    }
}
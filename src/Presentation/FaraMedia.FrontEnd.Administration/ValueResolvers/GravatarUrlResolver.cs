namespace FaraMedia.FrontEnd.Administration.ValueResolvers {
    using AutoMapper;

    using FaraMedia.Core.Security;

    public class GravatarUrlResolver : ValueResolver<string, string> {
        private const string GRAVATAR_URL_FORMAT = "http://www.gravatar.com/avatar/{0}";
        private const string DEFAULT_URL = "http://www.gravatar.com/avatar/?d=identicon";

        protected override string ResolveCore(string source) {
            if (source == null)
                return null;

            var url = GetGravatarUrl(source);

            return url;
        }

        public string GetGravatarUrl(string email) {
            if (string.IsNullOrEmpty(email))
                return DEFAULT_URL;

            var emailHash = HashingHelpers.GetHash(email);

            return string.Format(GRAVATAR_URL_FORMAT, emailHash);
        }
    }
}
namespace FaraMedia.Data.Schemas.Layout {
    public class PartialsConstants : ConstantsBase {
        public static class Auth {
            public class Labels {
                public static readonly string Anonymous = Helpers.Key<Labels>(l => Anonymous);
            }

            public class Messages {
                public static readonly string Anonymous = Helpers.Key<Messages>(m => Anonymous);
                public static readonly string SignedInAs = Helpers.Key<Messages>(m => SignedInAs);
            }
        }

        public static class Version {
            public class Messages {
                public static readonly string AppVersion = Helpers.Key<Messages>(m => AppVersion);
            }
        }

        public static class Footer {
            public class Messages {
                public static readonly string Copyright = Helpers.Key<Messages>(m => Copyright);
            }
        }
    }
}
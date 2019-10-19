namespace FaraMedia.Data.Schemas.Layout {
    public class ControlHelpersConstants : ConstantsBase {
        public static class Pager {
            public class Labels {
                public static readonly string Previous = Helpers.Key<Labels>(l => Previous);
                public static readonly string Next = Helpers.Key<Labels>(l => Next);
            }

            public class Texts {
                public static readonly string Format = Helpers.Key<Texts>(t => Format);
                public static readonly string SingleFormat = Helpers.Key<Texts>(t => SingleFormat);
            }
        }
    }
}
namespace FaraMedia.Data.Schemas.Layout {
    public class MappingConstants : ConstantsBase {
        public class Texts {
            public static readonly string False = Helpers.Key<Texts>(t => False);
            public static readonly string True = Helpers.Key<Texts>(t => True);
            public static readonly string Empty = Helpers.Key<Texts>(t => Empty);

            public static readonly string Day = Helpers.Key<Texts>(t => Day);
            public static readonly string Month = Helpers.Key<Texts>(t => Month);
            public static readonly string Year = Helpers.Key<Texts>(t => Year);
        }
    }
}
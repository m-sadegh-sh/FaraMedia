namespace FaraMedia.Data.Schemas {
    public class CommonConstants : ConstantsBase {
        public class Messages {
            public static readonly string NullEntity = Helpers.Key<Messages>(m => NullEntity);
            public static readonly string UnknownEntity = Helpers.Key<Messages>(m => UnknownEntity);
            public static readonly string NullSettings = Helpers.Key<Messages>(m => NullSettings);
            public static readonly string UnknownSettings = Helpers.Key<Messages>(m => UnknownSettings);
            public static readonly string Inserted = Helpers.Key<Messages>(m => Inserted);
            public static readonly string NotInserted = Helpers.Key<Messages>(m => NotInserted);
            public static readonly string Updated = Helpers.Key<Messages>(m => Updated);
            public static readonly string NotUpdated = Helpers.Key<Messages>(m => NotUpdated);
            public static readonly string Deleted = Helpers.Key<Messages>(m => Deleted);
            public static readonly string NotDeleted = Helpers.Key<Messages>(m => NotDeleted);
            public static readonly string DeleteConfirmation = Helpers.Key<Messages>(m => DeleteConfirmation);
            public static readonly string Saved = Helpers.Key<Messages>(m => Saved);
            public static readonly string NotSaved = Helpers.Key<Messages>(m => NotSaved);
            public static readonly string Empty = Helpers.Key<Messages>(m => Empty);

            public static readonly string ActionSucceded = Helpers.Key<Messages>(m => ActionSucceded);
            public static readonly string ActionFailed = Helpers.Key<Messages>(m => ActionFailed);
        }

        public class FormattableMessages {
            public static readonly string Required = Helpers.Key<FormattableMessages>(fm => Required);
            public static readonly string InvalidLength = Helpers.Key<FormattableMessages>(fm => InvalidLength);
            public static readonly string InvalidFormat = Helpers.Key<FormattableMessages>(fm => InvalidFormat);
            public static readonly string InvalidValue = Helpers.Key<FormattableMessages>(fm => InvalidValue);
            public static readonly string InvalidMinValue = Helpers.Key<FormattableMessages>(fm => InvalidMinValue);
            public static readonly string InvalidMaxValue = Helpers.Key<FormattableMessages>(fm => InvalidMaxValue);
            public static readonly string OutOfRangeValue = Helpers.Key<FormattableMessages>(fm => OutOfRangeValue);
            public static readonly string DuplicateValue = Helpers.Key<FormattableMessages>(fm => DuplicateValue);
        }

        public static class Fields {
            public class Metadata {
                public static readonly string Label = Helpers.LabelKey<Metadata>();
            }
        }
    }
}
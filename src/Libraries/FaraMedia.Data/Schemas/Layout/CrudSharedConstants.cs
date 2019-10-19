namespace FaraMedia.Data.Schemas.Layout {
    public class CrudSharedConstants : ConstantsBase {
        public class Commands {
            public static readonly string Back = Helpers.Key<Commands>(c => Back);
            public static readonly string BackTo = Helpers.Key<Commands>(c => BackTo);
            public static readonly string Details = Helpers.Key<Commands>(c => Details);
            public static readonly string New = Helpers.Key<Commands>(c => New);
            public static readonly string Create = Helpers.Key<Commands>(c => Create);
            public static readonly string CreateContinue = Helpers.Key<Commands>(c => CreateContinue);
            public static readonly string Edit = Helpers.Key<Commands>(c => Edit);
            public static readonly string Update = Helpers.Key<Commands>(c => Update);
            public static readonly string UpdateContinue = Helpers.Key<Commands>(c => UpdateContinue);
            public static readonly string Publish = Helpers.Key<Commands>(c => Publish);
            public static readonly string PublishAll = Helpers.Key<Commands>(c => PublishAll);
            public static readonly string Unpublish = Helpers.Key<Commands>(c => Unpublish);
            public static readonly string UnpublishAll = Helpers.Key<Commands>(c => UnpublishAll);
            public static readonly string Delete = Helpers.Key<Commands>(c => Delete);
            public static readonly string TemporarilyDelete = Helpers.Key<Commands>(c => TemporarilyDelete);
            public static readonly string TemporarilyDeleteAll = Helpers.Key<Commands>(c => TemporarilyDeleteAll);
            public static readonly string UnDeleteAll = Helpers.Key<Commands>(c => UnDeleteAll);
            public static readonly string PermanentlyDelete = Helpers.Key<Commands>(c => PermanentlyDelete);
            public static readonly string PermanentlyDeleteAll = Helpers.Key<Commands>(c => PermanentlyDeleteAll);
            public static readonly string Save = Helpers.Key<Commands>(c => Save);
            public static readonly string SaveContinue = Helpers.Key<Commands>(c => SaveContinue);
            public static readonly string YesSure = Helpers.Key<Commands>(c => YesSure);
            public static readonly string NoCancel = Helpers.Key<Commands>(c => NoCancel);
        }

        public class Messages {
            public static readonly string InvalidParameter = Helpers.Key<Messages>(m => InvalidParameter);
            public static readonly string Confirmation = Helpers.Key<Messages>(m => Confirmation);
            public static readonly string AreYouSureToDelete = Helpers.Key<Messages>(m => AreYouSureToDelete);
        }
    }
}
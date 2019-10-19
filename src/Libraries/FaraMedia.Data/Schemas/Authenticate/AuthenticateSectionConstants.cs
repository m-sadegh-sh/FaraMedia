namespace FaraMedia.Data.Schemas.Authenticate {
    public class AuthenticateSectionConstants : ConstantsBase {
        public static readonly string SectionName = Helpers.SectionName<AuthenticateSectionConstants>();

        public class Metadata {
            public static readonly string Title = Helpers.Key<Metadata>(m => Title);
        }

        public class SignController {
            public static readonly string ControllerName = Helpers.ControllerName<SignController>();

            public class In {
                public static readonly string ActionName = Helpers.ActionName<In>();

                public static readonly string RouteName = SectionName + ControllerName + "*" + ActionName;

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                    public static readonly string Description = Helpers.Key<Metadata>(m => Description);
                }

                public class Messages {
                    public static readonly string SignedIn = Helpers.Key<Messages>(m => SignedIn);
                }

                public class Commands {
                    public static readonly string SignIn = Helpers.Key<Commands>(c => SignIn);
                }

                public static class Fields {
                    public class RememberMe {
                        public static readonly string Label = Helpers.LabelKey<RememberMe>();
                    }
                }
            }

            public class Out {
                public static readonly string ActionName = Helpers.ActionName<Out>();

                public static readonly string RouteName = SectionName + ControllerName + "*" + ActionName;

                public class Messages {
                    public static readonly string SignedOut = Helpers.Key<Messages>(m => SignedOut);
                }

                public class Commands {
                    public static readonly string SignOut = Helpers.Key<Commands>(c => SignOut);
                }
            }
        }
    }
}
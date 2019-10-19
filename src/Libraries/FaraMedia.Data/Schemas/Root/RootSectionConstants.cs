namespace FaraMedia.Data.Schemas.Root {
    public class RootSectionConstants : ConstantsBase {
        public class Metadata {
            public static readonly string Title = Helpers.Key<Metadata>(m => Title);
            public static readonly string Description = Helpers.Key<Metadata>(m => Description);
        }

        public class CommonController {
            public static readonly string ControllerName = Helpers.ControllerName<CommonController>();

            public class Root {
                public static readonly string ActionName = Helpers.ActionName<Root>();

                public static readonly string RouteName = ControllerName + ActionName;
            }

            public class Home {
                public static readonly string ActionName = Helpers.ActionName<Home>();

                public static readonly string RouteName = ControllerName + ActionName;

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                }

                public class Commands {
                    public static readonly string Home = Helpers.Key<Commands>(c => Home);
                }
            }
        }

        public class ErrorsController {
            public static readonly string ControllerName = Helpers.ControllerName<ErrorsController>();

            public class GenericError {
                public static readonly string ActionName = Helpers.ActionName<GenericError>();

                public static readonly string RouteName = ControllerName + ActionName;

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                    public static readonly string Description = Helpers.Key<Metadata>(m => Description);
                }
            }

            public class NotFound {
                public static readonly string ActionName = Helpers.ActionName<NotFound>();

                public static readonly string RouteName = ControllerName + ActionName;

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                    public static readonly string Description = Helpers.Key<Metadata>(m => Description);
                }
            }

            public class AccessDenied {
                public static readonly string ActionName = Helpers.ActionName<AccessDenied>();

                public static readonly string RouteName = ControllerName + ActionName;

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                    public static readonly string Description = Helpers.Key<Metadata>(m => Description);
                }
            }

            public class AppClosed {
                public static readonly string ActionName = Helpers.ActionName<AppClosed>();

                public static readonly string RouteName = ControllerName + ActionName;

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                    public static readonly string Description = Helpers.Key<Metadata>(m => Description);
                }
            }
        }

        public class MaintenanceController {
            public static readonly string ControllerName = Helpers.ControllerName<MaintenanceController>();

            public class Metadata {
                public static readonly string Title = Helpers.Key<Metadata>(m => Title);
            }

            public class Get {
                public static readonly string ActionName = Helpers.ActionName<Get>();

                public static readonly string RouteName = ControllerName + ActionName;
            }

            public class ClearCache {
                public static readonly string ActionName = Helpers.ControllerName<ClearCache>();

                public static readonly string RouteName = ControllerName + ActionName;

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                }
            }

            public class RecoverDefaults {
                public static readonly string ActionName = Helpers.ActionName<RecoverDefaults>();

                public static readonly string RouteName = ControllerName + ActionName;

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                }
            }

            public class RestartApplication {
                public static readonly string ActionName = Helpers.ActionName<RestartApplication>();

                public static readonly string RouteName = ControllerName + ActionName;

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                }
            }
        }
    }
}
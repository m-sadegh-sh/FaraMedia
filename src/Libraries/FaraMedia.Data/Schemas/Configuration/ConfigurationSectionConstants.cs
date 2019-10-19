namespace FaraMedia.Data.Schemas.Configuration {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;

    public class ConfigurationSectionConstants : ConstantsBase {
        public static readonly string SectionName = Helpers.SectionName<ConfigurationSectionConstants>();
        public const string ControllerName = "Sections";
        public static readonly string ActionName = SectionName;

        public static readonly string RouteName = SectionName;

        public class Metadata {
            public static readonly string Title = Helpers.Key<Metadata>(m => Title);
            public static readonly string Description = Helpers.Key<Metadata>(m => Description);
        }

        public class BillingSettingsController {
            public static readonly string ControllerName = Helpers.ControllerName<BillingSettingsController>();

            public static class Save {
                public static readonly string ActionName = KnownActionNames.Save;

                public static readonly string RouteName = SectionName + ControllerName;

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                    public static readonly string Description = Helpers.Key<Metadata>(m => Description);
                }
            }
        }

        public class FileManagementSettingsController {
            public static readonly string ControllerName = Helpers.ControllerName<FileManagementSettingsController>();

            public static class Save {
                public static readonly string ActionName = KnownActionNames.Save;

                public static readonly string RouteName = SectionName + ControllerName;

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                    public static readonly string Description = Helpers.Key<Metadata>(m => Description);
                }
            }
        }

        public class SecuritySettingsController {
            public static readonly string ControllerName = Helpers.ControllerName<SecuritySettingsController>();

            public static class Save {
                public static readonly string ActionName = KnownActionNames.Save;

                public static readonly string RouteName = SectionName + ControllerName;

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                    public static readonly string Description = Helpers.Key<Metadata>(m => Description);
                }
            }
        }

        public class SystemSettingsController {
            public static readonly string ControllerName = Helpers.ControllerName<SystemSettingsController>();

            public static class Save {
                public static readonly string ActionName = KnownActionNames.Save;

                public static readonly string RouteName = SectionName + ControllerName;

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                    public static readonly string Description = Helpers.Key<Metadata>(m => Description);
                }
            }
        }

        public class SettingsController {
            public static readonly string ControllerName = Helpers.ControllerName<SettingsController>();

            public static class List {
                public static readonly string ActionName = KnownActionNames.List;

                public static readonly string RouteName = SectionName + ControllerName + KnownParameterNames.Page.ToExpression();

                public static RouteValueDictionary Defaults = RouteParameter.Add(KnownParameterNames.Page, 1);

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                    public static readonly string Description = Helpers.Key<Metadata>(m => Description);
                }
            }

            public static class New {
                public static readonly string ActionName = KnownActionNames.New;

                public static readonly string RouteName = SectionName + ControllerName + ActionName;

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                    public static readonly string Description = Helpers.Key<Metadata>(m => Description);
                }
            }

            public static class Edit {
                public static readonly string ActionName = KnownActionNames.Edit;

                public static readonly string RouteName = SectionName + ControllerName + KnownParameterNames.Id.ToExpression() + ActionName;

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                    public static readonly string Description = Helpers.Key<Metadata>(m => Description);
                }
            }
        }
    }
}
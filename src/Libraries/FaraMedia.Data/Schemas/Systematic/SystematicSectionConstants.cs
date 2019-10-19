namespace FaraMedia.Data.Schemas.Systematic {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;

    public class SystematicSectionConstants : ConstantsBase {
        public static readonly string SectionName = Helpers.SectionName<SystematicSectionConstants>();
        public const string ControllerName = "Sections";
        public static readonly string ActionName = SectionName;

        public static readonly string RouteName = SectionName;

        public class Metadata {
            public static readonly string Title = Helpers.Key<Metadata>(m => Title);
            public static readonly string Description = Helpers.Key<Metadata>(m => Description);
        }

        public class LanguagesController {
            public static readonly string ControllerName = Helpers.ControllerName<LanguagesController>();

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

        public class ResourceKeysController {
            public static readonly string ControllerName = Helpers.ControllerName<ResourceKeysController>();

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

        public class ResourceValuesController {
            public static readonly string ControllerName = Helpers.ControllerName<ResourceValuesController>();

            public static class List {
                public static readonly string ActionName = KnownActionNames.List;

                public static readonly string RouteName = SectionName + ControllerName + KnownParameterNames.ResourceKeyId.ToExpression() + KnownParameterNames.Page.ToExpression();

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

        public class ActivityTypesController {
            public static readonly string ControllerName = Helpers.ControllerName<ActivityTypesController>();

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

        public class ActivitiesController {
            public static readonly string ControllerName = Helpers.ControllerName<ActivitiesController>();

            public static class List {
                public static readonly string ActionName = KnownActionNames.List;

                public static readonly string RouteName = SectionName + ControllerName + KnownParameterNames.Page.ToExpression();

                public static RouteValueDictionary Defaults = RouteParameter.Add(KnownParameterNames.Page, 1);

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                    public static readonly string Description = Helpers.Key<Metadata>(m => Description);
                }
            }
        }

        public class LogsController {
            public static readonly string ControllerName = Helpers.ControllerName<LogsController>();

            public static class List {
                public static readonly string ActionName = KnownActionNames.List;

                public static readonly string RouteName = SectionName + ControllerName + KnownParameterNames.Page.ToExpression();

                public static RouteValueDictionary Defaults = RouteParameter.Add(KnownParameterNames.Page, 1);

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                    public static readonly string Description = Helpers.Key<Metadata>(m => Description);
                }
            }
        }

        public class EmailAccountsController {
            public static readonly string ControllerName = Helpers.ControllerName<EmailAccountsController>();

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

        public class MessageTemplatesController {
            public static readonly string ControllerName = Helpers.ControllerName<MessageTemplatesController>();

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

        public class NewsletterSubscriptionsController {
            public static readonly string ControllerName = Helpers.ControllerName<NewsletterSubscriptionsController>();

            public static class List {
                public static readonly string ActionName = KnownActionNames.List;

                public static readonly string RouteName = SectionName + ControllerName + KnownParameterNames.Page.ToExpression();

                public static RouteValueDictionary Defaults = RouteParameter.Add(KnownParameterNames.Page, 1);

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                    public static readonly string Description = Helpers.Key<Metadata>(m => Description);
                }
            }
        }

        public class QueuedEmailsController {
            public static readonly string ControllerName = Helpers.ControllerName<QueuedEmailsController>();

            public static class List {
                public static readonly string ActionName = KnownActionNames.List;

                public static readonly string RouteName = SectionName + ControllerName + KnownParameterNames.Page.ToExpression();

                public static RouteValueDictionary Defaults = RouteParameter.Add(KnownParameterNames.Page, 1);

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                    public static readonly string Description = Helpers.Key<Metadata>(m => Description);
                }
            }
        }

        public class ScheduleTasksController {
            public static readonly string ControllerName = Helpers.ControllerName<ScheduleTasksController>();

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
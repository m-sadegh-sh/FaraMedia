namespace FaraMedia.Data.Schemas.Shared {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;

    public class SharedSectionConstants : ConstantsBase {
        public static readonly string SectionName = Helpers.SectionName<SharedSectionConstants>();
        public const string ControllerName = "Sections";
        public static readonly string ActionName = SectionName;

        public static readonly string RouteName = SectionName;

        public class Metadata {
            public static readonly string Title = Helpers.Key<Metadata>(m => Title);
            public static readonly string Description = Helpers.Key<Metadata>(m => Description);
        }

        public class EntityAttributesController {
            public static readonly string ControllerName = Helpers.ControllerName<EntityAttributesController>();

            public static class List {
                public static readonly string ActionName = KnownActionNames.List;

                public static readonly string RouteName = SectionName + ControllerName + KnownParameterNames.OwnerId.ToExpression() + KnownParameterNames.Page.ToExpression();

                public static RouteValueDictionary Defaults = RouteParameter.Add(KnownParameterNames.Page, 1);

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                    public static readonly string Description = Helpers.Key<Metadata>(m => Description);
                }
            }

            public static class New {
                public static readonly string ActionName = KnownActionNames.New;

                public static readonly string RouteName = SectionName + ControllerName + KnownParameterNames.OwnerId.ToExpression() + ActionName;

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

        public class CommentsController {
            public static readonly string ControllerName = Helpers.ControllerName<CommentsController>();

            public static class List {
                public static readonly string ActionName = KnownActionNames.List;

                public static readonly string RouteName = SectionName + ControllerName + KnownParameterNames.OwnerId.ToExpression() + KnownParameterNames.Page.ToExpression();

                public static RouteValueDictionary Defaults = RouteParameter.Add(KnownParameterNames.Page, 1);

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

        public class LikesController {
            public static readonly string ControllerName = Helpers.ControllerName<LikesController>();

            public static class List {
                public static readonly string ActionName = KnownActionNames.List;

                public static readonly string RouteName = SectionName + ControllerName + KnownParameterNames.OwnerId.ToExpression() + KnownParameterNames.Page.ToExpression();

                public static RouteValueDictionary Defaults = RouteParameter.Add(KnownParameterNames.Page, 1);

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                    public static readonly string Description = Helpers.Key<Metadata>(m => Description);
                }
            }
        }

        public class SharesController {
            public static readonly string ControllerName = Helpers.ControllerName<SharesController>();

            public static class List {
                public static readonly string ActionName = KnownActionNames.List;

                public static readonly string RouteName = SectionName + ControllerName + KnownParameterNames.OwnerId.ToExpression() + KnownParameterNames.Page.ToExpression();

                public static RouteValueDictionary Defaults = RouteParameter.Add(KnownParameterNames.Page, 1);

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                    public static readonly string Description = Helpers.Key<Metadata>(m => Description);
                }
            }
        }
    }
}
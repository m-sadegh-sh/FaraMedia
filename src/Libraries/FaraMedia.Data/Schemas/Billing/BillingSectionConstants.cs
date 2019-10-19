namespace FaraMedia.Data.Schemas.Billing {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;

    public class BillingSectionConstants : ConstantsBase {
        public static readonly string SectionName = Helpers.SectionName<BillingSectionConstants>();
        public const string ControllerName = "Sections";
        public static readonly string ActionName = SectionName;

        public static readonly string RouteName = SectionName;

        public class Metadata {
            public static readonly string Title = Helpers.Key<Metadata>(m => Title);
            public static readonly string Description = Helpers.Key<Metadata>(m => Description);
        }

        public class OrderStatusesController {
            public static readonly string ControllerName = Helpers.ControllerName<OrderStatusesController>();

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

                public static readonly string RouteName = SectionName + ControllerName + KnownParameterNames.OrderId.ToExpression() + ActionName;

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
        
        public class OrdersController {
            public static readonly string ControllerName = Helpers.ControllerName<OrdersController>();

            public static class List {
                public static readonly string ActionName = KnownActionNames.List;

                public static readonly string RouteName = SectionName + ControllerName + KnownParameterNames.Page.ToExpression();

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

        public class OrderNotesController {
            public static readonly string ControllerName = Helpers.ControllerName<OrderNotesController>();

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

                public static readonly string RouteName = SectionName + ControllerName + KnownParameterNames.OrderId.ToExpression() + ActionName;

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

        public class OrderLinesController {
            public static readonly string ControllerName = Helpers.ControllerName<OrderLinesController>();

            public static class List {
                public static readonly string ActionName = KnownActionNames.List;

                public static readonly string RouteName = SectionName + ControllerName + KnownParameterNames.OrderId.ToExpression() + KnownParameterNames.Page.ToExpression();

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

        public class TransactionRequestsController {
            public static readonly string ControllerName = Helpers.ControllerName<TransactionRequestsController>();

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

                public static readonly string RouteName = SectionName + ControllerName + KnownParameterNames.OrderId.ToExpression() + ActionName;

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

        public class TransactionResponsesController {
            public static readonly string ControllerName = Helpers.ControllerName<TransactionResponsesController>();

            public static class List {
                public static readonly string ActionName = KnownActionNames.List;

                public static readonly string RouteName = SectionName + ControllerName+KnownParameterNames.TransactionRequestId.ToExpression() + KnownParameterNames.Page.ToExpression();

                public static RouteValueDictionary Defaults = RouteParameter.Add(KnownParameterNames.Page, 1);

                public class Metadata {
                    public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                    public static readonly string Description = Helpers.Key<Metadata>(m => Description);
                }
            }
        }
    }
}
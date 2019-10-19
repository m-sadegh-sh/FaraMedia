namespace FaraMedia.Data.Schemas.Fundamentals {
    using System.Web.Routing;

    using FaraMedia.Core.Routing;
    using FaraMedia.Data.Knowns;

    public class FundamentalsSectionConstants : ConstantsBase {
        public static readonly string SectionName = Helpers.SectionName<FundamentalsSectionConstants>();
        public const string ControllerName = "Sections";
        public static readonly string ActionName = SectionName;

        public static readonly string RouteName = SectionName;

        public class Metadata {
            public static readonly string Title = Helpers.Key<Metadata>(m => Title);
            public static readonly string Description = Helpers.Key<Metadata>(m => Description);
        }

        public class GenresController {
            public static readonly string ControllerName = Helpers.ControllerName<GenresController>();

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

        public class PublishersController {
            public static readonly string ControllerName = Helpers.ControllerName<PublishersController>();

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

        public class ArtistsController {
            public static readonly string ControllerName = Helpers.ControllerName<ArtistsController>();

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

        public class PhotoAlbumsController {
            public static readonly string ControllerName = Helpers.ControllerName<PhotoAlbumsController>();

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

                public static readonly string RouteName = SectionName + ArtistsController.ControllerName + KnownParameterNames.ArtistId.ToExpression() + ControllerName + ActionName;

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

        public class PhotosController {
            public static readonly string ControllerName = Helpers.ControllerName<PhotosController>();

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

                public static readonly string RouteName = SectionName + ArtistsController.ControllerName + KnownParameterNames.PhotoAlbumId.ToExpression() + ControllerName + ActionName;

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

        public class AlbumsController {
            public static readonly string ControllerName = Helpers.ControllerName<AlbumsController>();

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

        public class TracksController {
            public static readonly string ControllerName = Helpers.ControllerName<TracksController>();

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
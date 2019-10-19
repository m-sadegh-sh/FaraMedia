namespace FaraMedia.Web.Framework {
    using System;
    using System.Linq;
    using System.Web;

    using Autofac;
    using Autofac.Integration.Mvc;

    using FaraMedia.Core;
    using FaraMedia.Core.Events;
    using FaraMedia.Core.Infrastructure.DependencyManagement;
    using FaraMedia.Core.Infrastructure.TypeFinders;
    using FaraMedia.Web.Framework.EmbeddedViews;
    using FaraMedia.Web.Framework.Routing;
    using FaraMedia.Web.Framework.Routing.Seo;
    using FaraMedia.Web.Framework.UI;

    public class DependencyRegistrar : IDependencyRegistrar {
        public int RegistrationOrder {
            get { return 3; }
        }

        public virtual void Register(ContainerBuilder containerBuilder, ITypeFinder typeFinder) {
            RegisterFrameworkLevelTypes(containerBuilder);
            RegisterHelperTypes(containerBuilder);
            RegisterPresentationTypes(containerBuilder, typeFinder);
            RegisterRoutingRelatedTypes(containerBuilder, typeFinder);
        }

        private static void RegisterFrameworkLevelTypes(ContainerBuilder containerBuilder) {
            containerBuilder.Register(cc => (new HttpContextWrapper(HttpContext.Current) as HttpContextBase)).As<HttpContextBase>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<HttpContextBase>().Request).As<HttpRequestBase>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<HttpContextBase>().Response).As<HttpResponseBase>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<HttpContextBase>().Server).As<HttpServerUtilityBase>().InstancePerHttpRequest();
            containerBuilder.Register(cc => cc.Resolve<HttpContextBase>().Session).As<HttpSessionStateBase>().InstancePerHttpRequest();
        }

        private static void RegisterHelperTypes(ContainerBuilder containerBuilder) {
            containerBuilder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerHttpRequest();
            containerBuilder.RegisterType<WebWorkContext>().As<IWorkContext>().InstancePerHttpRequest();
        }

        private static void RegisterPresentationTypes(ContainerBuilder containerBuilder, ITypeFinder typeFinder) {
            containerBuilder.RegisterType<SitemapGenerator>().As<ISitemapGenerator>().InstancePerHttpRequest();
            containerBuilder.RegisterType<PagePartBuilder>().As<IPagePartBuilder>().InstancePerHttpRequest();

            containerBuilder.RegisterType<EmbeddedViewResolver>().As<IEmbeddedViewResolver>().SingleInstance();
        }

        private static void RegisterRoutingRelatedTypes(ContainerBuilder containerBuilder, ITypeFinder typeFinder) {
            var routeProviders = typeFinder.FindClassesOfType<IRouteProvider>();

            foreach (var routeProvider in routeProviders)
                containerBuilder.RegisterType(routeProvider).As<IRouteProvider>().SingleInstance();

            containerBuilder.RegisterType<RoutePublisher>().As<IRoutePublisher>().SingleInstance();
        }
    }
}
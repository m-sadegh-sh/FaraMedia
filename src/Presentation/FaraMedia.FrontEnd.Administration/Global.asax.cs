namespace FaraMedia.FrontEnd.Administration {
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using FaraMedia.Core;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Core.States;
    using FaraMedia.Services.Integrations;
    using FaraMedia.Services.Systematic;
    using FaraMedia.Services.Systematic;
    using FaraMedia.Services.Systematic;
    using FaraMedia.Web.Framework.Modules;
    using FaraMedia.Web.Framework.Mvc;
    using FaraMedia.Web.Framework.Mvc.Attributes.Adapters;
    using FaraMedia.Web.Framework.Mvc.Validators;
    using FaraMedia.Web.Framework.Routing;

    public class MvcApplication : HttpApplication {
        protected void Application_Start() {
            EngineContext.Initialize(false);

            EngineContext.Current.Resolve<IDatabaseSyncer>().ForceToSync();

            TaskManager.Instance.Initialize();
            TaskManager.Instance.Start();

            DependencyResolver.SetResolver(new FaraDependencyResolver());

            ModelBinders.Binders.DefaultBinder = new FaraModelBinder();

            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
            RegisterGlobalFilters(GlobalFilters.Filters);

            FaraAttributeAdaptersRegisterar.RegisterAllAdapters();

            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;

            var clientDataTypeModelValidatorProvider = ModelValidatorProviders.Providers.FirstOrDefault(mvp => mvp.GetType() == typeof (ClientDataTypeModelValidatorProvider));
            ModelValidatorProviders.Providers.Remove(clientDataTypeModelValidatorProvider);
            ModelValidatorProviders.Providers.Add(new ClientNumericModelValidatorProvider());
            ModelValidatorProviders.Providers.Add(new ClientDateTimeModelValidatorProvider());

            //var embeddedViewResolver = EngineContext.Current.Resolve<IEmbeddedViewResolver>();
            //var embeddedProvider = new EmbeddedViewVirtualPathProvider(embeddedViewResolver.GetEmbeddedViews());
            //HostingEnvironment.RegisterVirtualPathProvider(embeddedProvider);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {
            SetWorkingCulture();
        }

        protected void Application_Error(object sender, EventArgs e) {
            ResponseCompressorModule.DisableCompression(new HttpContextWrapper(HttpContext.Current));

            LogException(Server.GetLastError());
        }

        private static void RegisterRoutes(RouteCollection routeCollection) {
            var routePublisher = EngineContext.Current.Resolve<IRoutePublisher>();
            routePublisher.RegisterRoutes(routeCollection);
        }

        private static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            //filters.Add(new ProfilingActionFilter());
        }

        private void SetWorkingCulture() {
            var dbConfigurationState = EngineContext.Current.Resolve<DbConfigurationState>();
            if (!dbConfigurationState.IsDbSynced)
                return;

            var webHelper = EngineContext.Current.Resolve<IWebHelper>();
            if (webHelper.IsStaticResource(Request))
                return;

            var workContext = EngineContext.Current.Resolve<IWorkContext>();
            var workingLanguage = workContext.WorkingLanguage;

            if (workingLanguage == null) {
                var languageService = EngineContext.Current.Resolve<ILanguageService>();
                workingLanguage = languageService.GetAllLanguages().FirstOrDefault();
            }

            var culture = new CultureInfo(workingLanguage != null ? workingLanguage.IsoCode : "fa");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        private static void LogException(Exception exception) {
            if (exception == null)
                return;

            try {
                var logService = EngineContext.Current.Resolve<ILogService>();
                var workContext = EngineContext.Current.Resolve<IWorkContext>();

                logService.Error(exception.Message, exception, workContext.CurrentUser);
            } catch (Exception exc) {
                Debug.Write(exc);
            }
        }
    }
}
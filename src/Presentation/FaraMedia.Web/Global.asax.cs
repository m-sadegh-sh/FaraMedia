using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using FluentValidation.Mvc;
using MvcMiniProfiler;
using MvcMiniProfiler.MVCHelpers;
using Fara.Core;
using Fara.Core.Data;
using Fara.Core.Domain;
using Fara.Core.Infrastructure;
using Fara.Services.Logging;
using Fara.Services.Tasks;
using Fara.Web.Framework;
using Fara.Web.Framework.EmbeddedViews;
using Fara.Web.Framework.Mvc;
using Fara.Web.Framework.Mvc.Routes;
using Fara.Web.Framework.Themes;

namespace Fara.Web
{
    
    

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            
            
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            
            var routePublisher = EngineContext.Current.Resolve<IRoutePublisher>();
            routePublisher.RegisterRoutes(routes);
            
            routes.MapRoute(
                "Default", 
                "{controller}/{action}/{id}", 
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Fara.Web.Controllers" }
            );
        }

        protected void Application_Start()
        {
            
            EngineContext.Initialize(false);

            
            if (DataSettingsHelper.DatabaseIsInstalled())
            {
                TaskManager.Instance.Initialize();
                TaskManager.Instance.Start();
            }

            
            var dependencyResolver = new FaraDependencyResolver();
            DependencyResolver.SetResolver(dependencyResolver);

            
            ModelBinders.Binders.Add(typeof(BaseFaraModel), new FaraModelBinder());

            if (DataSettingsHelper.DatabaseIsInstalled())
            {
                
                ViewEngines.Engines.Clear();
                
                ViewEngines.Engines.Add(new ThemeableRazorViewEngine());
            }

            
            ModelMetadataProviders.Current = new FaraMetadataProvider();

            
            AreaRegistration.RegisterAllAreas();
            if (DataSettingsHelper.DatabaseIsInstalled() &&
                EngineContext.Current.Resolve<StoreInformationSettings>().DisplayMiniProfilerInPublicStore)
            {
                GlobalFilters.Filters.Add(new ProfilingActionFilter());
            }
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            
            

            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;

            ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(new FaraValidatorFactory()));

            
            var embeddedViewResolver = EngineContext.Current.Resolve<IEmbeddedViewResolver>();
            var embeddedProvider = new EmbeddedViewVirtualPathProvider(embeddedViewResolver.GetEmbeddedViews());
            HostingEnvironment.RegisterVirtualPathProvider(embeddedProvider);

            if (DataSettingsHelper.DatabaseIsInstalled())
            {
                if (EngineContext.Current.Resolve<StoreInformationSettings>().MobileDevicesSupported)
                {
                    
                    HttpCapabilitiesBase.BrowserCapabilitiesProvider = new FiftyOne.Foundation.Mobile.Detection.MobileCapabilitiesProvider();
                }
                else
                {
                    
                    
                    HttpCapabilitiesBase.BrowserCapabilitiesProvider = null;
                }
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            EnsureDatabaseIsInstalled();

            if (DataSettingsHelper.DatabaseIsInstalled() && 
                EngineContext.Current.Resolve<StoreInformationSettings>().DisplayMiniProfilerInPublicStore)
            {
                MiniProfiler.Start();
            }
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            if (DataSettingsHelper.DatabaseIsInstalled() &&
                EngineContext.Current.Resolve<StoreInformationSettings>().DisplayMiniProfilerInPublicStore)
            {
                
                MiniProfiler.Stop();
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        { 
            
            SetWorkingCulture();
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            
            CompressAttribute.DisableCompression(HttpContext.Current);
            
            LogException(Server.GetLastError());
        }
        
        protected void EnsureDatabaseIsInstalled()
        {
            var webHelper = EngineContext.Current.Resolve<IWebHelper>();
            string installUrl = string.Format("{0}install", webHelper.GetStoreLocation());
            if (!webHelper.IsStaticResource(this.Request) &&
                !DataSettingsHelper.DatabaseIsInstalled() &&
                !webHelper.GetThisPageUrl(false).StartsWith(installUrl, StringComparison.InvariantCultureIgnoreCase))
            {
                this.Response.Redirect(installUrl);
            }
        }

        protected void SetWorkingCulture()
        {
            if (DataSettingsHelper.DatabaseIsInstalled())
            {
                var webHelper = EngineContext.Current.Resolve<IWebHelper>();
                if (!webHelper.IsStaticResource(this.Request))
                {
                    if (webHelper.GetThisPageUrl(false).StartsWith(string.Format("{0}admin", webHelper.GetStoreLocation()), StringComparison.InvariantCultureIgnoreCase))
                    {
                        


                        
                        
                        
                        
                        var culture = new CultureInfo("en-US");
                        Thread.CurrentThread.CurrentCulture = culture;
                        Thread.CurrentThread.CurrentUICulture = culture;
                    }
                    else
                    {
                        
                        var workContext = EngineContext.Current.Resolve<IWorkContext>();
                        if (workContext.CurrentCustomer != null && workContext.WorkingLanguage != null)
                        {
                            var culture = new CultureInfo(workContext.WorkingLanguage.LanguageCulture);
                            Thread.CurrentThread.CurrentCulture = culture;
                            Thread.CurrentThread.CurrentUICulture = culture;
                        }
                    }
                }
            }
        }

        protected void LogException(Exception exc)
        {
            if (exc == null)
                return;
            
            if (!DataSettingsHelper.DatabaseIsInstalled())
                return;
            
            try
            {
                var logger = EngineContext.Current.Resolve<ILogger>();
                var workContext = EngineContext.Current.Resolve<IWorkContext>();
                logger.Error(exc.Message, exc, workContext.CurrentCustomer);
            }
            catch (Exception)
            {
                
            }
        }
    }
}
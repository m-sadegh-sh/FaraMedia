using System.Web.Mvc;
using System.Web.Routing;
using Fara.Web.Framework.Mvc.Routes;

namespace Fara.Web.Infrastructure
{
    
    public  class UpgradeRouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            
            routes.MapRoute(string.Empty, "{oldfilename}.aspx",
                            new { controller = "BackwardCompatibility1X", action = "GeneralRedirect" },
                            new[] { "Fara.Web.Controllers" });
            
            
            routes.MapRoute(string.Empty, "products/{id}.aspx",
                            new { controller = "BackwardCompatibility1X", action = "RedirectProduct"},
                            new[] { "Fara.Web.Controllers" });
            
            
            routes.MapRoute(string.Empty, "category/{id}.aspx",
                            new { controller = "BackwardCompatibility1X", action = "RedirectCategory" },
                            new[] { "Fara.Web.Controllers" });

            
            routes.MapRoute(string.Empty, "publisher/{id}.aspx",
                            new { controller = "BackwardCompatibility1X", action = "RedirectPublisher" },
                            new[] { "Fara.Web.Controllers" });

            
            routes.MapRoute(string.Empty, "producttag/{id}.aspx",
                            new { controller = "BackwardCompatibility1X", action = "RedirectProductTag" },
                            new[] { "Fara.Web.Controllers" });

            
            routes.MapRoute(string.Empty, "news/{id}.aspx",
                            new { controller = "BackwardCompatibility1X", action = "RedirectNewsItem" },
                            new[] { "Fara.Web.Controllers" });

            
            routes.MapRoute(string.Empty, "blog/{id}.aspx",
                            new { controller = "BackwardCompatibility1X", action = "RedirectBlogPost" },
                            new[] { "Fara.Web.Controllers" });

            
            routes.MapRoute(string.Empty, "topic/{id}.aspx",
                            new { controller = "BackwardCompatibility1X", action = "RedirectTopic" },
                            new[] { "Fara.Web.Controllers" });

            
            routes.MapRoute(string.Empty, "boards/fg/{id}.aspx",
                            new { controller = "BackwardCompatibility1X", action = "RedirectForumGroup" },
                            new[] { "Fara.Web.Controllers" });
            routes.MapRoute(string.Empty, "boards/f/{id}.aspx",
                            new { controller = "BackwardCompatibility1X", action = "RedirectForum" },
                            new[] { "Fara.Web.Controllers" });
            routes.MapRoute(string.Empty, "boards/t/{id}.aspx",
                            new { controller = "BackwardCompatibility1X", action = "RedirectForumTopic" },
                            new[] { "Fara.Web.Controllers" });
        }

        public int Priority
        {
            get
            {
                
                return -1;
            }
        }
    }
}

using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Fara.Core.Domain.Cms;
using Fara.Services.Cms;
using Fara.Web.Models.Cms;

namespace Fara.Web.Controllers
{
    public class WidgetController : BaseFaraController
    {
		

        private readonly IWidgetService _widgetService;

        

		

        public WidgetController(IWidgetService widgetService)
        {
            this._widgetService = widgetService;
        }

        

        

        [ChildActionOnly]
        public ActionResult WidgetsByZone(WidgetZone widgetZone)
        {
            
            var model = new List<WidgetModel>();

            var widgets = _widgetService.GetAllWidgetsByZone(widgetZone);
            foreach (var widget in widgets)
            {
                var widgetPlugin = _widgetService.LoadWidgetPluginBySystemName(widget.PluginSystemName);
                if (widgetPlugin == null || !widgetPlugin.PluginDescriptor.Installed)
                    continue;   

                var widgetModel = new WidgetModel();

                string actionName;
                string controllerName;
                RouteValueDictionary routeValues;
                widgetPlugin.GetDisplayWidgetRoute(widget.Id, out actionName, out controllerName, out routeValues);
                widgetModel.ActionName = actionName;
                widgetModel.ControllerName = controllerName;
                widgetModel.RouteValues = routeValues;

                model.Add(widgetModel);
            }

            return PartialView(model);
        }

        
    }
}

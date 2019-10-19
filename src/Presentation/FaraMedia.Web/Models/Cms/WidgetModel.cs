using System.Web.Routing;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Cms
{
    public class WidgetModel : BaseFaraModel
    {
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public RouteValueDictionary RouteValues { get; set; }
    }
}
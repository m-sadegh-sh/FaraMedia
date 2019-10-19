namespace FaraMedia.Web.Framework.Mvc.Attributes {
    using System.Web.Mvc;

    public sealed class SectionNameAttribute : ActionFilterAttribute {
        private readonly string _sectionName;

        public SectionNameAttribute(string sectionName) {
            _sectionName = sectionName;
        }

        public override void OnResultExecuting(ResultExecutingContext resultExecutingContext) {
            resultExecutingContext.Controller.ViewBag.SectionControllerName = _sectionName;
        }
    }
}
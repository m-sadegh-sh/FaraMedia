namespace FaraMedia.Web.Framework.Mvc.Attributes {
    using System.Web.Mvc;

    public class ResolveThenAttribute : ThenAttributeBase {
        public override void OnResultExecuting(ResultExecutingContext resultExecutingContext) {
            var then = resultExecutingContext.RequestContext.HttpContext.Request.QueryString[ParameterName];

            resultExecutingContext.Controller.ViewBag.Then = FormatOrRenewParameter(resultExecutingContext, then);
        }
    }
}
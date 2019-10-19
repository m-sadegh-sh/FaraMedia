namespace FaraMedia.Web.Framework.Mvc.Attributes {
    using System.Web.Mvc;

    public class PutThenAttribute : ThenAttributeBase {
        public override void OnActionExecuting(ActionExecutingContext actionExecutingContext) {
            var then = actionExecutingContext.RequestContext.HttpContext.Request.Form[ParameterName];

            actionExecutingContext.ActionParameters[ParameterName] = FormatOrRenewParameter(actionExecutingContext, then);
        }
    }
}
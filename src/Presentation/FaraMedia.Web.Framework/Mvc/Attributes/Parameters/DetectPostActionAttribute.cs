namespace FaraMedia.Web.Framework.Mvc.Attributes {
    using System.Web.Mvc;

    using FaraMedia.Web.Framework.Mvc.Controllers;

    public class DetectPostActionAttribute : FilterAttribute, IActionFilter {
        private readonly string _actionParameterName;

        public DetectPostActionAttribute(string actionParameterName) {
            _actionParameterName = actionParameterName;
        }

        public void OnActionExecuted(ActionExecutedContext actionExecutedContext) {}

        public void OnActionExecuting(ActionExecutingContext actionExecutingContext) {
            var formValue = actionExecutingContext.RequestContext.HttpContext.Request.Form["post-actions"];
            var postAction = PostAction.Unknown;

            switch (formValue) {
                case "publish-all":
                    postAction = PostAction.PublishAll;
                    break;
                case "unpublish-all":
                    postAction = PostAction.UnpublishAll;
                    break;
                case "temporarily-delete-all":
                    postAction = PostAction.TemporarilyDeleteAll;
                    break;
                case "undelete-all":
                    postAction = PostAction.UnDeleteAll;
                    break;
                case "permanently-delete-all":
                    postAction = PostAction.PermanentlyDeleteAll;
                    break;
            }

            actionExecutingContext.ActionParameters[_actionParameterName] = postAction;
        }
    }
}
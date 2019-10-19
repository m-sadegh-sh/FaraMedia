namespace FaraMedia.Web.Framework.Mvc.Attributes {
    using System.Web.Mvc;

    public class FormValueExistsAttribute : ActionFilterAttribute {
        private readonly string _actionParameterName;
        private readonly string _name;
        private readonly string _value;

        public FormValueExistsAttribute(string name, string value, string actionParameterName) {
            _name = name;
            _value = value;
            _actionParameterName = actionParameterName;
        }

        public override void OnActionExecuting(ActionExecutingContext actionExecutingContext) {
            var formValue = actionExecutingContext.RequestContext.HttpContext.Request.Form[_name];

            actionExecutingContext.ActionParameters[_actionParameterName] = !string.IsNullOrEmpty(formValue) && formValue.ToLower().Equals(_value.ToLower());
        }
    }
}
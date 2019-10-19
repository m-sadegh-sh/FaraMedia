namespace FaraMedia.Web.Framework.Mvc.Attributes {
    using System.Collections.Generic;
    using System.Web.Mvc;

    using FaraMedia.Core.Infrastructure.Extensions;

    public class FormValuesToArrayAttribute : FilterAttribute, IActionFilter {
        private readonly string _actionParameterName;

        public FormValuesToArrayAttribute(string actionParameterName) {
            _actionParameterName = actionParameterName;
        }

        public void OnActionExecuted(ActionExecutedContext actionExecutedContext) {}

        public void OnActionExecuting(ActionExecutingContext actionExecutingContext) {
            var formValues = actionExecutingContext.RequestContext.HttpContext.Request.Form.ToDictionary();

            var acceptedFormValues = new List<long>();

            foreach (var formValue in formValues) {
                var formValueValue = formValue.Value;

                if (string.IsNullOrEmpty(formValueValue))
                    continue;

                var indexOfSemiColon = formValueValue.IndexOf(",");

                if (indexOfSemiColon > -1)
                    formValueValue = formValueValue.Substring(0, indexOfSemiColon);

                bool t;

                if (bool.TryParse(formValueValue, out t) && t) {
                    long l;

                    if (long.TryParse(formValue.Key, out l))
                        acceptedFormValues.Add(l);
                }
            }

            actionExecutingContext.ActionParameters[_actionParameterName] = acceptedFormValues.ToArray();
        }
    }
}
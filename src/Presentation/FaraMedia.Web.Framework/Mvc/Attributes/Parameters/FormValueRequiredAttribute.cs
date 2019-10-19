namespace FaraMedia.Web.Framework.Mvc.Attributes {
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Web.Mvc;

    public class FormValueRequiredAttribute : ActionMethodSelectorAttribute {
        private readonly FormValueRequirement _requirement;
        private readonly string[] _submitButtonNames;

        public FormValueRequiredAttribute(params string[] submitButtonNames) : this(FormValueRequirement.Equal, submitButtonNames) {}

        public FormValueRequiredAttribute(FormValueRequirement requirement, params string[] submitButtonNames) {
            _submitButtonNames = submitButtonNames;
            _requirement = requirement;
        }

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo) {
            foreach (var buttonName in _submitButtonNames) {
                try {
                    var value = string.Empty;
                    switch (_requirement) {
                        case FormValueRequirement.Equal: {
                            value = controllerContext.HttpContext.Request.Form[buttonName];
                        }
                            break;
                        case FormValueRequirement.StartsWith: {
                            foreach (var formValue in controllerContext.HttpContext.Request.Form.AllKeys) {
                                if (!formValue.StartsWith(buttonName, StringComparison.InvariantCultureIgnoreCase))
                                    continue;

                                value = controllerContext.HttpContext.Request.Form[formValue];
                                break;
                            }
                        }
                            break;
                    }
                    if (!string.IsNullOrEmpty(value))
                        return true;
                } catch (Exception exception) {
                    Debug.WriteLine(exception.Message);
                }
            }
            return false;
        }
    }
}
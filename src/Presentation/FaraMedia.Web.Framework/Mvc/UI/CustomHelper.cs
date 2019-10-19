namespace FaraMedia.Web.Framework.Mvc.UI {
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using FaraMedia.Core.Routing;
    using FaraMedia.Core.Sanitization;

	public class CustomHelper {
        private readonly HtmlHelper _htmlHelper;

        public CustomHelper(HtmlHelper htmlHelper) {
            _htmlHelper = htmlHelper;
        }

        protected static string GetUserErrorMessageOrDefault(HttpContextBase httpContext, ModelError error, ModelState modelState) {
            if (!string.IsNullOrEmpty(error.ErrorMessage))
                return error.ErrorMessage;

            return "";
        }

        public MvcForm BeginRouteForm(string routeName) {
            return BeginRouteForm(routeName, null);
        }

        public MvcForm BeginRouteForm(string routeName, object htmlAttributes) {
            return _htmlHelper.BeginRouteForm(routeName, null, FormMethod.Post, htmlAttributes);
        }

        public MvcForm BeginRouteFormWithId(string routeName, long id) {
            return _htmlHelper.BeginRouteForm(routeName, new {
                id
            }, FormMethod.Post);
        }

        public MvcHtmlString ResolveThen() {
            var then = _htmlHelper.ViewBag.Then as string;

            return _htmlHelper.Hidden("then", then);
        }

        public MvcHtmlString ValidationSummary() {
            return ValidationSummary(false);
        }

        public MvcHtmlString ValidationSummary(bool excludePropertyErrors) {
            return ValidationSummary(excludePropertyErrors, null);
        }

        public MvcHtmlString ValidationSummary(string message) {
            return ValidationSummary(false, message, null);
        }

        public MvcHtmlString ValidationSummary(bool excludePropertyErrors, string message) {
            return ValidationSummary(excludePropertyErrors, message, null);
        }

        public MvcHtmlString ValidationSummary(string message, object htmlAttributes) {
            return ValidationSummary(false, message, htmlAttributes);
        }

        public MvcHtmlString ValidationSummary(bool excludePropertyErrors, string message, object htmlAttributes) {
            var formContext = _htmlHelper.ViewContext.FormContext;
            if (_htmlHelper.ViewData.ModelState.IsValid) {
                if (formContext == null)
                    return null;

                if (_htmlHelper.ViewContext.UnobtrusiveJavaScriptEnabled && excludePropertyErrors)
                    return null;
            }

            const string closeButton = "<a class=\"close\" href=\"#\">×</a>";

            string messageP;
            if (!string.IsNullOrEmpty(message)) {
                var pTag = new TagBuilder("p");
                pTag.SetInnerText(message);
                messageP = pTag.ToString(TagRenderMode.Normal);
            } else
                messageP = null;

            var htmlSummary = new StringBuilder();
            var unorderedList = new TagBuilder("ul");

            IEnumerable<ModelState> modelStates = null;
            if (excludePropertyErrors) {
                ModelState modelState;
                _htmlHelper.ViewData.ModelState.TryGetValue(_htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix, out modelState);
                if (modelState != null)
                    modelStates = new[] {modelState};
            } else
                modelStates = _htmlHelper.ViewData.ModelState.Values;

            if (modelStates != null) {
                foreach (var modelState in modelStates) {
                    foreach (var modelError in modelState.Errors) {
                        var errorText = GetUserErrorMessageOrDefault(_htmlHelper.ViewContext.HttpContext, modelError, null);
                        if (!string.IsNullOrEmpty(errorText)) {
                            var liTag = new TagBuilder("li");
                            liTag.SetInnerText(errorText);
                            htmlSummary.AppendLine(liTag.ToString(TagRenderMode.Normal));
                        }
                    }
                }
            } else if (string.IsNullOrEmpty(messageP))
                return null;

            unorderedList.InnerHtml = htmlSummary.ToString();

            var divBuilder = new TagBuilder("div");
            divBuilder.MergeAttributes(RouteValueDictionaryExtensions.Convert(htmlAttributes));
            divBuilder.AddCssClass("alert-message block-message");
            divBuilder.AddCssClass(_htmlHelper.ViewData.ModelState.IsValid ? "success" : "error");
            divBuilder.InnerHtml = string.Concat(closeButton, messageP, unorderedList.ToString(TagRenderMode.Normal));

            if (formContext != null) {
                if (_htmlHelper.ViewContext.UnobtrusiveJavaScriptEnabled) {
                    if (!excludePropertyErrors)
                        divBuilder.MergeAttribute("data-valmsg-summary", "true");
                } else {
                    divBuilder.GenerateId("validationSummary");
                    formContext.ValidationSummaryId = divBuilder.Attributes["id"];
                    formContext.ReplaceValidationSummary = !excludePropertyErrors;
                }
            }
            return divBuilder.ToMvcHtmlString(TagRenderMode.Normal);
        }

        public MvcHtmlString RequiredHints(string additionalText = null) {
            var spanTag = new TagBuilder("span");
            spanTag.AddCssClass("required");
            var innerText = "*";

            if (!String.IsNullOrEmpty(additionalText))
                innerText += " " + additionalText;

            spanTag.SetInnerText(innerText);

            return MvcHtmlString.Create(spanTag.ToString());
        }

        public string FieldNameFor<T, TResult>(Expression<Func<T, TResult>> expression) {
            var expressionText = GetExpressionText(expression);

            return _htmlHelper.ViewData.TemplateInfo.GetFullHtmlFieldName(expressionText);
        }

        public string FieldIdFor<T, TResult>(Expression<Func<T, TResult>> expression) {
            var expressionText = GetExpressionText(expression);

            var id = _htmlHelper.ViewData.TemplateInfo.GetFullHtmlFieldId(expressionText);

            return id.Replace('[', '_').Replace(']', '_');
        }

        protected static string GetExpressionText<TProperty, TModel>(Expression<Func<TModel, TProperty>> expression) {
            var expressionText = ExpressionHelper.GetExpressionText(expression);

            return Sanitizer.Slug(expressionText);
        }
    }
}
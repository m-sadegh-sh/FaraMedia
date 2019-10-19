namespace FaraMedia.Web.Framework.Mvc.Extensions {
    using System.Linq;
    using System.Web.Mvc;

    using FaraMedia.Core.Sanitization;
    using FaraMedia.Services.Infrastructure;

    public static class ModelStateDictionaryExtensions {
        public static void InjectMessages(this ModelStateDictionary modelStateDictionary, ServiceOperationResult serviceOperationResult) {
            foreach (var errorMessage in serviceOperationResult.Errors) {
                if (string.IsNullOrEmpty(errorMessage.Key)) {
                    modelStateDictionary.AddModelError("", errorMessage.Value);
                    continue;
                }

                var key = Sanitizer.Slug(errorMessage.Key);

                var modelError = modelStateDictionary.Keys.Where(k => k.EndsWith(key)).OrderBy(k => k.Length).FirstOrDefault();

                if (modelError == null)
                    return;

                modelStateDictionary[modelError].Errors.Add(errorMessage.Value);
            }
        }
    }
}
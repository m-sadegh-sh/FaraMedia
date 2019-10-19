namespace FaraMedia.Web.Framework.Mvc.Models {
    using System.Web.Mvc;

    public class ModelBase {
        public bool IsSelected { get; set; }

        public virtual void BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {}
    }
}
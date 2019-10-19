namespace FaraMedia.Web.Framework.Mvc.Controllers {
    using System.Web.Mvc;

    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Common;

    public abstract class CrudControllerBase : UserizedAreaControllerBase {
        public abstract ActionResult List(int page = 1);

        protected virtual ActionResult HandleUnknown(long key) {
            ResourceErrorNotification(CommonConstants.Systematic.UnknownEntity);

            return RedirectToAction(KnownActionNames.List);
        }
    }
}
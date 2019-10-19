namespace FaraMedia.FrontEnd.Administration.Controllers {
    using System.Net;
    using System.Web.Mvc;

    using FaraMedia.Web.Framework.Mvc.Controllers;

    public class ErrorsController : FaraControllerBase {
        [HttpGet]
        public ActionResult GenericError(string url) {
            Request.RequestContext.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            return View(model: url);
        }

        [HttpGet]
        public ActionResult NotFound(string url) {
            Request.RequestContext.HttpContext.Response.StatusCode = (int) HttpStatusCode.NotFound;

            return View(model: url);
        }

        [HttpGet]
        public ActionResult AccessDenied(string url) {
            Request.RequestContext.HttpContext.Response.StatusCode = (int) HttpStatusCode.Forbidden;

            return View(model: url);
        }

        [HttpGet]
        public ActionResult AppClosed() {
            Request.RequestContext.HttpContext.Response.StatusCode = (int) HttpStatusCode.ServiceUnavailable;

            return View();
        }
    }
}
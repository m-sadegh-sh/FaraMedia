namespace FaraMedia.FrontEnd.Administration.Controllers {
    using System.Web.Mvc;
    using System.Web.UI;

    using FaraMedia.Core;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Root;
    using FaraMedia.FrontEnd.Administration.Models.Common;
    using FaraMedia.Web.Framework.Mvc.Controllers;

    public class CommonController : SecuredAreaControllerBase {
        private readonly IWebHelper _webHelper;

        public CommonController(IWebHelper webHelper) {
            _webHelper = webHelper;
        }

        [HttpGet]
        public ActionResult Root() {
            return RedirectToRoutePermanent(RootSectionConstants.CommonController.Home.RouteName);
        }

        [HttpGet]
        //[OutputCache(CacheProfile = "Long")]
        [OutputCache(Duration = 600, VaryByParam = "*", Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult Home() {
            return View();
        }

        [HttpGet]
        public PartialViewResult Favicon() {
            var faviconModel = new FaviconModel {
                Uploaded = System.IO.File.Exists(Request.PhysicalApplicationPath + "favicon.ico"),
                FaviconUrl = _webHelper.GetLocation+ "favicon.ico"
            };

            return PartialView(faviconModel);
        }
    }
}
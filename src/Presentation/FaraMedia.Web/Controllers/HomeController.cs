using System.Web.Mvc;

namespace Fara.Web.Controllers
{
    public class HomeController : BaseFaraController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

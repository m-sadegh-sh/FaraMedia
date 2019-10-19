namespace FaraMedia.Web.Framework.Mvc.Controllers {
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Security;

    [RedirectToSignIn]
    public abstract class SecuredAreaControllerBase:FaraControllerBase {
        
    }
}
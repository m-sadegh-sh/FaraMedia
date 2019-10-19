namespace FaraMedia.Services.Helpers {
    using System.Web;

    public interface IMobileDeviceHelper {
        bool IsMobileDevice(HttpContextBase httpContext);
        bool MobileDevicesSupported();
        bool UserDontUseMobileVersion();
    }
}
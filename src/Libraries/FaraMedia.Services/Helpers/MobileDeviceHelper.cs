namespace FaraMedia.Services.Helpers {
    using System.Web;

    using FaraMedia.Core;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Domain.Shared;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Knowns.Security;
    using FaraMedia.Services.Extensions.Shared;
    using FaraMedia.Services.Querying.Shared;

    public sealed class MobileDeviceHelper : IMobileDeviceHelper {
        private readonly IDbService<EntityAttribute, EntityAttributeQuery> _entityAttributeService;
        private readonly IWorkContext _workContext;
        private readonly SystemSettings _systemSettings;

        public MobileDeviceHelper(IDbService<EntityAttribute, EntityAttributeQuery> entityAttributeService, IWorkContext workContext, SystemSettings systemSettings)
        {
            _entityAttributeService = entityAttributeService;
            _workContext = workContext;
            _systemSettings = systemSettings;
        }

        public bool IsMobileDevice(HttpContextBase httpContext) {
            return httpContext.Request.Browser.IsMobileDevice;
        }

        public bool MobileDevicesSupported() {
            return _systemSettings.MobileDevicesSupported;
        }

        public bool UserDontUseMobileVersion() {
            return _entityAttributeService.GetValueByOwnerIdAndKey(_workContext.CurrentUser.Id, UserAttributeNames.DontUseMobileVersion, true);
        }
    }
}
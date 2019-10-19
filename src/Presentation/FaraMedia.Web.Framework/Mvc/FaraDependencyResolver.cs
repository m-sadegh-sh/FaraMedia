namespace FaraMedia.Web.Framework.Mvc {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using FaraMedia.Core.Infrastructure;

    public class FaraDependencyResolver : IDependencyResolver {
        public object GetService(Type serviceType) {
            try {
                return EngineContext.Current.Resolve(serviceType);
            } catch {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return Enumerable.Empty<object>();
        }
    }
}
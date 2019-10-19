namespace FaraMedia.Services.Installation.Abstraction {
    using FaraMedia.Core;
    using FaraMedia.Core.Domain.Systematic;

    using NHibernate;

    public abstract class ResourceInstallerBase {
        public abstract void InstallResources(IStatelessSession session);

        private IStatelessSession _session;

        protected void UseSession(IStatelessSession session) {
            _session = session;
        }

        protected void NewResource(string key, string value, params object[] args) {
            if (_session == null)
                throw new FaraException("Before installing new resource key/value you should initialize session field.");

            var resourceKey = new ResourceKey {
                Key = key
            };

            var resourceValue = new ResourceValue();

            if (args != null && args.Length > 0)
                resourceValue.Value = string.Format(value, args);
            else
                resourceValue.Value = value;

            resourceKey.Values.Add(resourceValue);

            _session.Insert(resourceKey);
        }
    }
}
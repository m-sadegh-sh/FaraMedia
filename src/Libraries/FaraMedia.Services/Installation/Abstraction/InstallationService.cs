namespace FaraMedia.Services.Installation.Abstraction {
    using System.Collections.Generic;
    using System.Linq;

    using FaraMedia.Core;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Services.Installation.Security;
    using FaraMedia.Services.Installation.Systematic;

    using NHibernate;
    using NHibernate.Linq;

    public class InstallationService : DisposableBase, IInstallationService {
        private readonly IStatelessSession _statelessSession;
        private bool _dependeciesInjected;
        private IEnumerable<ResourceInstallerBase> _installers;

        public InstallationService(IStatelessSession statelessSession) {
            _statelessSession = statelessSession;
        }

        public void InstallAll(bool checkDependencies = true) {
            InstallResources(checkDependencies);
            InstallSettings(checkDependencies);
            InstallEntities(checkDependencies);
        }

        public void InstallResources(bool checkDependencies = true) {
            if (checkDependencies)
                EnsureFromDependencies();

            GetAllInstallers().ForEach(i => i.InstallResources(_statelessSession));
        }

        public void InstallSettings(bool checkDependencies = true) {
            if (checkDependencies)
                EnsureFromDependencies();

            GetAllInstallers().OfType<SettingsInstallerBase>().ForEach(i => i.InstallSettings());
        }

        public void InstallEntities(bool checkDependencies = true) {
            if (checkDependencies)
                EnsureFromDependencies();

            GetAllInstallers().OfType<EntityInstallerBase>().ForEach(i => i.InstallEntities(_statelessSession));
        }

        private void EnsureFromDependencies() {
            if (_dependeciesInjected)
                return;

            GetAllInstallers().OfType<LanguageInstaller>().First().InstallEntities(_statelessSession);
            GetAllInstallers().OfType<RoleInstaller>().First().InstallEntities(_statelessSession);
            GetAllInstallers().OfType<EmailAccountInstaller>().First().InstallEntities(_statelessSession);

            _dependeciesInjected = true;
        }

        private IEnumerable<ResourceInstallerBase> GetAllInstallers() {
            if (_installers == null)
                _installers = EngineContext.Current.ResolveAll<ResourceInstallerBase>();

            return _installers;
        }

        protected override void CoreDispose(bool disposeManagedResources) {
            _statelessSession.Dispose();
        }
    }
}
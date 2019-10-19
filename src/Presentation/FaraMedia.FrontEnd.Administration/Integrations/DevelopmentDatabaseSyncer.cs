namespace FaraMedia.FrontEnd.Administration.Integrations {
    using Autofac;
    using Autofac.Integration.Mvc;

    using FaraMedia.Core.Data;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Core.States;
    using FaraMedia.Services.Installation;
    using FaraMedia.Services.Integrations;
    using FaraMedia.Services.Systematic;

    public sealed class DevelopmentDatabaseSyncer : IDatabaseSyncer {
        public void ForceToSync() {
            var dbConfigurationState = EngineContext.Current.Resolve<DbConfigurationState>();

            //dbConfigurationState.TouchDbIsAllowed = false;
            //dbConfigurationState.IsDbSynced = false;

            //EngineContext.Current.Resolve<IInstallationService>().InstallResources(false);

            EngineContext.Current.Resolve<ISessionProvider>();

            dbConfigurationState.TouchDbIsAllowed = true;

            EngineContext.Current.ContainerManager.UpdateContainer(cb => cb.RegisterType<StringResourceService>().As<IStringResourceService>().InstancePerHttpRequest());

            //EngineContext.Current.Resolve<IInstallationService>().InstallAll();

            dbConfigurationState.IsDbSynced = true;
        }
    }
}
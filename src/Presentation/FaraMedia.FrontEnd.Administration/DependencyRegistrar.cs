namespace FaraMedia.FrontEnd.Administration {
    using System.Linq;

    using Autofac;
    using Autofac.Integration.Mvc;

    using FaraMedia.Core.Infrastructure.DependencyManagement;
    using FaraMedia.Core.Infrastructure.TypeFinders;
    using FaraMedia.FrontEnd.Administration.Integrations;
    using FaraMedia.Services.Integrations;

    public class DependencyRegistrar : IDependencyRegistrar {
        public int RegistrationOrder {
            get { return 4; }
        }

        public virtual void Register(ContainerBuilder containerBuilder, ITypeFinder typeFinder) {
            RegisterDataLayerTypes(containerBuilder);
            RegisterPresentationTypes(containerBuilder, typeFinder);
        }
        
        private static void RegisterDataLayerTypes(ContainerBuilder containerBuilder) {
            containerBuilder.RegisterType<DevelopmentDatabaseSyncer>().As<IDatabaseSyncer>().InstancePerHttpRequest();
        }
        
        private static void RegisterPresentationTypes(ContainerBuilder containerBuilder, ITypeFinder typeFinder) {
            containerBuilder.RegisterControllers(typeFinder.GetAssemblies().ToArray());
        }
    }
}
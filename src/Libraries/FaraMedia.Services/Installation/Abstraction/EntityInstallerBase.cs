namespace FaraMedia.Services.Installation.Abstraction {
    using NHibernate;

    public abstract class EntityInstallerBase : ResourceInstallerBase {
        public abstract void InstallEntities(IStatelessSession session);
    }
}
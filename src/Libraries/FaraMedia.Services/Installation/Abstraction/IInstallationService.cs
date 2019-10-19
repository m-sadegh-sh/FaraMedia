namespace FaraMedia.Services.Installation.Abstraction {
    public interface IInstallationService {
        void InstallAll(bool checkDependencies = true);
        void InstallResources(bool checkDependencies = true);
        void InstallSettings(bool checkDependencies = true);
        void InstallEntities(bool checkDependencies = true);
    }
}
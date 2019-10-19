namespace FaraMedia.Services {
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Services.Infrastructure;

    public interface IDbSettingsService<TSettings> where TSettings : class, ISettings, new() {
        TSettings Get();
        ServiceOperationResult Save(TSettings settings);
    }
}
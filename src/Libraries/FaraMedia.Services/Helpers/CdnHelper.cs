namespace FaraMedia.Services.Helpers {
    using FaraMedia.Core.Domain.Configuration;

    public sealed class CdnHelper : ICdnHelper {
        private readonly FileManagementSettings _fileManagementSettings;

        public CdnHelper(FileManagementSettings fileManagementSettings) {
            _fileManagementSettings = fileManagementSettings;
        }

        public string GetImagePath(string fileName) {
            return string.Concat(_fileManagementSettings.CdnUrl, _fileManagementSettings.ImagesPath, fileName).ToLowerInvariant();
        }

        public string GetStylePath(string fileName) {
            return string.Concat(_fileManagementSettings.CdnUrl, _fileManagementSettings.StylesPath, fileName).ToLowerInvariant();
        }

        public string GetScriptPath(string fileName) {
            return string.Concat(_fileManagementSettings.CdnUrl, _fileManagementSettings.ScriptsPath, fileName).ToLowerInvariant();
        }
    }
}
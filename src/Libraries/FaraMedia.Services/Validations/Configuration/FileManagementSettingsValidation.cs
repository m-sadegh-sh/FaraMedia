namespace FaraMedia.Services.Validations.Configuration {
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Services.Validations.Extensions;

    using NHibernate.Validator.Cfg.Loquacious;

    public sealed class FileManagementSettingsValidation : ValidationDef<FileManagementSettings> {
        public FileManagementSettingsValidation() {
            Define(fms => fms.DefaultPictureZoomEnabled);

            Define(fms => fms.MaximumImageSize)
                .GreaterThanOrEqualTo(FileManagementSettingsConstants.Fields.MaximumImageSize.MinValue)
                .WithInvalidMinValue(FileManagementSettingsConstants.Fields.MaximumImageSize.Label,
                                     FileManagementSettingsConstants.Fields.MaximumImageSize.MinValue);

            Define(fms => fms.AvatarPictureSize)
                .GreaterThanOrEqualTo(FileManagementSettingsConstants.Fields.AvatarPictureSize.MinValue)
                .WithInvalidMinValue(FileManagementSettingsConstants.Fields.AvatarPictureSize.Label,
                                     FileManagementSettingsConstants.Fields.AvatarPictureSize.MinValue);

            Define(fms => fms.ThumbPictureSize)
                .GreaterThanOrEqualTo(FileManagementSettingsConstants.Fields.ThumbPictureSize.MinValue)
                .WithInvalidMinValue(FileManagementSettingsConstants.Fields.ThumbPictureSize.Label,
                                     FileManagementSettingsConstants.Fields.ThumbPictureSize.MinValue);

            Define(fms => fms.DetailsPictureSize)
                .GreaterThanOrEqualTo(FileManagementSettingsConstants.Fields.DetailsPictureSize.MinValue)
                .WithInvalidMinValue(FileManagementSettingsConstants.Fields.DetailsPictureSize.Label,
                                     FileManagementSettingsConstants.Fields.DetailsPictureSize.MinValue);

            Define(fms => fms.ImageQuality)
                .IncludedBetween(FileManagementSettingsConstants.Fields.ImageQuality.MinValue,
                                 FileManagementSettingsConstants.Fields.ImageQuality.MaxValue)
                .WithInvalidRange(FileManagementSettingsConstants.Fields.ImageQuality.Label,
                                  FileManagementSettingsConstants.Fields.ImageQuality.MinValue,
                                  FileManagementSettingsConstants.Fields.ImageQuality.MaxValue);

            Define(ms => ms.DefaultAvatarImageName)
                .MaxLength(FileManagementSettingsConstants.Fields.DefaultAvatarImageName.Length)
                .WithInvalidLength(FileManagementSettingsConstants.Fields.DefaultAvatarImageName.Label,
                                   FileManagementSettingsConstants.Fields.DefaultAvatarImageName.Length);

            Define(ms => ms.DefaultEntityImageName)
                .MaxLength(FileManagementSettingsConstants.Fields.DefaultEntityImageName.Length)
                .WithInvalidLength(FileManagementSettingsConstants.Fields.DefaultEntityImageName.Label,
                                   FileManagementSettingsConstants.Fields.DefaultEntityImageName.Length);

            Define(fms => fms.CdnUrl)
                .MaxLength(FileManagementSettingsConstants.Fields.CdnUrl.Length)
                .WithInvalidLength(FileManagementSettingsConstants.Fields.CdnUrl.Label,
                                   FileManagementSettingsConstants.Fields.CdnUrl.Length)
                .And
                .IsUrl()
                .WithInvalidFormat(FileManagementSettingsConstants.Fields.CdnUrl.Label);

            Define(fms => fms.ImagesPath)
                .MaxLength(FileManagementSettingsConstants.Fields.ImagesPath.Length)
                .WithInvalidLength(FileManagementSettingsConstants.Fields.ImagesPath.Label,
                                   FileManagementSettingsConstants.Fields.ImagesPath.Length)
                .And
                .IsPath()
                .WithInvalidFormat(FileManagementSettingsConstants.Fields.ImagesPath.Label);

            Define(fms => fms.StylesPath)
                .MaxLength(FileManagementSettingsConstants.Fields.StylesPath.Length)
                .WithInvalidLength(FileManagementSettingsConstants.Fields.StylesPath.Label,
                                   FileManagementSettingsConstants.Fields.StylesPath.Length)
                .And
                .IsPath()
                .WithInvalidFormat(FileManagementSettingsConstants.Fields.StylesPath.Label);

            Define(fms => fms.ScriptsPath)
                .MaxLength(FileManagementSettingsConstants.Fields.ScriptsPath.Length)
                .WithInvalidLength(FileManagementSettingsConstants.Fields.ScriptsPath.Label,
                                   FileManagementSettingsConstants.Fields.ScriptsPath.Length)
                .And
                .IsPath()
                .WithInvalidFormat(FileManagementSettingsConstants.Fields.ScriptsPath.Label);

            Define(fms => fms.DownloadsPath)
                .MaxLength(FileManagementSettingsConstants.Fields.DownloadsPath.Length)
                .WithInvalidLength(FileManagementSettingsConstants.Fields.DownloadsPath.Label,
                                   FileManagementSettingsConstants.Fields.DownloadsPath.Length)
                .And
                .IsPath()
                .WithInvalidFormat(FileManagementSettingsConstants.Fields.DownloadsPath.Label);
        }
    }
}
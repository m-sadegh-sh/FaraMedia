namespace FaraMedia.FrontEnd.Administration.Models.Configuration {
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Configuration;

    public class EditableFileManagementSettingsModel : EditableSettingsModelBase {
        [ResourceDisplayName(FileManagementSettingsConstants.Fields.DefaultPictureZoomEnabled.Label)]
        public bool DefaultPictureZoomEnabled { get; set; }
        
        [ResourceDisplayName(FileManagementSettingsConstants.Fields.MaximumImageSize.Label)]
        [ResourceMin(FileManagementSettingsConstants.Fields.MaximumImageSize.MinValue)]
        public int MaximumImageSize { get; set; }

        [ResourceDisplayName(FileManagementSettingsConstants.Fields.AvatarPictureSize.Label)]
        [ResourceMin(FileManagementSettingsConstants.Fields.AvatarPictureSize.MinValue)]
        public int AvatarPictureSize { get; set; }

        [ResourceDisplayName(FileManagementSettingsConstants.Fields.ThumbPictureSize.Label)]
        [ResourceMin(FileManagementSettingsConstants.Fields.ThumbPictureSize.MinValue)]
        public int ThumbPictureSize { get; set; }

        [ResourceDisplayName(FileManagementSettingsConstants.Fields.DetailsPictureSize.Label)]
        [ResourceMin(FileManagementSettingsConstants.Fields.DetailsPictureSize.MinValue)]
        public int DetailsPictureSize { get; set; }

        [ResourceDisplayName(FileManagementSettingsConstants.Fields.ImageQuality.Label)]
        [ResourceMin(FileManagementSettingsConstants.Fields.ImageQuality.MinValue)]
        [ResourceMax(FileManagementSettingsConstants.Fields.ImageQuality.MaxValue)]
        public long ImageQuality { get; set; }

        [ResourceDisplayName(FileManagementSettingsConstants.Fields.DefaultAvatarImageName.Label)]
        [ResourceStringLength(FileManagementSettingsConstants.Fields.DefaultAvatarImageName.Length)]
        public string DefaultAvatarImageName { get; set; }

        [ResourceDisplayName(FileManagementSettingsConstants.Fields.DefaultEntityImageName.Label)]
        [ResourceStringLength(FileManagementSettingsConstants.Fields.DefaultEntityImageName.Length)]
        public string DefaultEntityImageName { get; set; }

        [ResourceDisplayName(FileManagementSettingsConstants.Fields.LocalImagePath.Label)]
        [ResourceStringLength(FileManagementSettingsConstants.Fields.LocalImagePath.Length)]
        [ResourcePath]
        public string LocalImagePath { get; set; }

        [ResourceDisplayName(FileManagementSettingsConstants.Fields.LocalThumbImagePath.Label)]
        [ResourceStringLength(FileManagementSettingsConstants.Fields.LocalThumbImagePath.Length)]
        [ResourcePath]
        public string LocalThumbImagePath { get; set; }
    }
}
namespace FaraMedia.FrontEnd.Administration.Models.Configuration {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Configuration;

    public class EditableMembershipSettingsModel : EditableSettingsModelBase {
        [ResourceDisplayName(MembershipSettingsConstants.Fields.UserNameFormat.Label)]
        public bool UserNamesEnabled { get; set; }

        [ResourceDisplayName(MembershipSettingsConstants.Fields.CheckUserNameAvailabilityEnabled.Label)]
        public bool CheckUserNameAvailabilityEnabled { get; set; }

        [ResourceDisplayName(MembershipSettingsConstants.Fields.AllowUsersToChangeUserNames.Label)]
        public bool AllowUsersToChangeUserNames { get; set; }

        [ResourceDisplayName(MembershipSettingsConstants.Fields.AllowUserToUploadAvatar.Label)]
        public bool AllowUserToUploadAvatar { get; set; }

        [ResourceDisplayName(MembershipSettingsConstants.Fields.DefaultAvatarEnabled.Label)]
        public bool DefaultAvatarEnabled { get; set; }

        [ResourceDisplayName(MembershipSettingsConstants.Fields.ShowUserJoinDate.Label)]
        public bool ShowUserJoinDate { get; set; }

        [ResourceDisplayName(MembershipSettingsConstants.Fields.AllowViewingProfiles.Label)]
        public bool AllowViewingProfiles { get; set; }
        
        [ResourceDisplayName(MembershipSettingsConstants.Fields.GenderEnabled.Label)]
        public bool GenderEnabled { get; set; }

        [ResourceDisplayName(MembershipSettingsConstants.Fields.DateOfBirthEnabled.Label)]
        public bool DateOfBirthEnabled { get; set; }

        [ResourceDisplayName(MembershipSettingsConstants.Fields.CountryEnabled.Label)]
        public bool CountryEnabled { get; set; }

        [ResourceDisplayName(MembershipSettingsConstants.Fields.CityEnabled.Label)]
        public bool CityEnabled { get; set; }

        [ResourceDisplayName(MembershipSettingsConstants.Fields.ContentManagementletterEnabled.Label)]
        public bool NewsletterEnabled { get; set; }

        [ResourceDisplayName(MembershipSettingsConstants.Fields.HideNewsletterBlock.Label)]
        public bool HideNewsletterBlock { get; set; }

        [ResourceDisplayName(MembershipSettingsConstants.Fields.PasswordMinLength.Label)]
        [ResourceMin(MembershipSettingsConstants.Fields.PasswordMinLength.MinValue)]
        public int PasswordMinLength { get; set; }

        [ResourceDisplayName(MembershipSettingsConstants.Fields.OnlineUserMinutes.Label)]
        [ResourceMin(MembershipSettingsConstants.Fields.OnlineUserMinutes.MinValue)]
        public int OnlineUserMinutes { get; set; }

        [ResourceDisplayName(MembershipSettingsConstants.Fields.UserRegistrationType.Label)]
        [ResourceMin(MembershipSettingsConstants.Fields.UserRegistrationType.MinValue)]
        [ResourceMax(MembershipSettingsConstants.Fields.UserRegistrationType.MaxValue)]
        public int UserRegistrationType { get; set; }
        public SelectList AvailableUserRegistrationTypes { get; set; }

        [ResourceDisplayName(MembershipSettingsConstants.Fields.UserNameFormat.Label)]
        [ResourceMin(MembershipSettingsConstants.Fields.UserNameFormat.MinValue)]
        [ResourceMax(MembershipSettingsConstants.Fields.UserNameFormat.MaxValue)]
        public int UserNameFormat { get; set; }
        public SelectList AvailableUserNameFormats { get; set; }

        [ResourceDisplayName(MembershipSettingsConstants.Fields.HashedPasswordFormat.Label)]
        [ResourceMin(MembershipSettingsConstants.Fields.HashedPasswordFormat.MinValue)]
        [ResourceMax(MembershipSettingsConstants.Fields.HashedPasswordFormat.MaxValue)]
        public int HashedPasswordFormat { get; set; }
        public SelectList AvailableHashedPasswordFormats { get; set; }
    }
}
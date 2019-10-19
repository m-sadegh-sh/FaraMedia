namespace FaraMedia.FrontEnd.Administration.Controllers {
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.FrontEnd.Administration.Controllers.Abstracts;
    using FaraMedia.FrontEnd.Administration.Models.Configuration;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.Security;
    using FaraMedia.Services.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.UI;

    [SectionName(SettingsSectionConstants.SectionName)]
    public class MembershipSettingsController : SettingsCrudControllerBase<MembershipSettings, EditableMembershipSettingsModel> {
        private readonly IMembershipSettingsService _membershipSettingsService;

        public MembershipSettingsController(IMembershipSettingsService membershipSettingsService) {
            _membershipSettingsService = membershipSettingsService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageMembershipSettings; }
        }

        protected override void InjectModelDependencies(EditableMembershipSettingsModel editableMembershipSettingsModel) {
            var availableUserRegistrationTypes = new List<SelectListItem> {
                new SelectListItem {
                    Text = T(MembershipSettingsConstants.Fields.UserRegistrationType.Standard),
                    Value = ((int) UserRegistrationType.Standard).ToString()
                },
                new SelectListItem {
                    Text = T(MembershipSettingsConstants.Fields.UserRegistrationType.EmailValidation),
                    Value = ((int) UserRegistrationType.EmailValidation).ToString()
                },
                new SelectListItem {
                    Text = T(MembershipSettingsConstants.Fields.UserRegistrationType.AdminApproval),
                    Value = ((int) UserRegistrationType.AdminApproval).ToString()
                },
                new SelectListItem {
                    Text = T(MembershipSettingsConstants.Fields.UserRegistrationType.Disabled),
                    Value = ((int) UserRegistrationType.Disabled).ToString()
                }
            };

            editableMembershipSettingsModel.AvailableUserRegistrationTypes = availableUserRegistrationTypes.ToSelectList(sli => sli.Value, sli => sli.Text, editableMembershipSettingsModel.UserRegistrationType);

            var availableUserNameFormats = new List<SelectListItem> {
                new SelectListItem {
                    Text = T(MembershipSettingsConstants.Fields.UserNameFormat.Email),
                    Value = ((int) UserNameFormat.Email).ToString()
                },
                new SelectListItem {
                    Text = T(MembershipSettingsConstants.Fields.UserNameFormat.UserName),
                    Value = ((int) UserNameFormat.UserName).ToString()
                },
                new SelectListItem {
                    Text = T(MembershipSettingsConstants.Fields.UserNameFormat.FullName),
                    Value = ((int) UserNameFormat.FullName).ToString()
                }
            };

            editableMembershipSettingsModel.AvailableUserNameFormats = availableUserNameFormats.ToSelectList(sli => sli.Value, sli => sli.Text, editableMembershipSettingsModel.UserNameFormat);

            var availableHashedPasswordFormats = new List<SelectListItem> {
                new SelectListItem {
                    Text = T(MembershipSettingsConstants.Fields.HashedPasswordFormat.Sha1),
                    Value = ((int) HashedPasswordFormat.Sha1).ToString()
                },
                new SelectListItem {
                    Text = T(MembershipSettingsConstants.Fields.HashedPasswordFormat.Md5),
                    Value = ((int) HashedPasswordFormat.Md5).ToString()
                }
            };

            editableMembershipSettingsModel.AvailableHashedPasswordFormats = availableHashedPasswordFormats.ToSelectList(sli => sli.Value, sli => sli.Text, editableMembershipSettingsModel.HashedPasswordFormat);
        }

        protected override Func<MembershipSettings> GetSettings() {
            return () => _membershipSettingsService.LoadMembershipSettings();
        }

        protected override Func<ServiceOperationResult> SaveSettingsAndReturnOperationResult(MembershipSettings membershipSettings) {
            return () => _membershipSettingsService.SaveMembershipSettings(membershipSettings);
        }
    }
}
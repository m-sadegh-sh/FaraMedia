namespace FaraMedia.FrontEnd.Administration.Models.Security.Editable {
    using System;
    using System.Web.Mvc;

    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public sealed class EditableUserModel : EditableEntityModelBase {
        [ResourceDisplayName(UserConstants.Fields.IsSystemAccount.Hints)]
        public bool IsSystemAccount { get; set; }

        [ResourceDisplayName(UserConstants.Fields.IsBuyingBlocked.Hints)]
        public bool IsBuyingBlocked { get; set; }

        [ResourceDisplayName(UserConstants.Fields.PasswordFormat.Label)]
        [ResourceMin(UserConstants.Fields.PasswordFormat.MinValue)]
        [ResourceMax(UserConstants.Fields.PasswordFormat.MaxValue)]
        public int PasswordFormat { get; set; }

        public SelectList AvailablePasswordFormats { get; set; }
        
        [ResourceDisplayName(UserConstants.Fields.SystematicName.Label)]
        [ResourceStringLength(UserConstants.Fields.SystematicName.Length)]
        public string SystemName { get; set; }

        [ResourceDisplayName(UserConstants.Fields.UserName.Label)]
        [ResourceRequired]
        [ResourceStringLength(UserConstants.Fields.UserName.Length)]
        public string UserName { get; set; }

        [ResourceDisplayName(UserConstants.Fields.Email.Label)]
        [ResourceRequired]
        [ResourceStringLength(UserConstants.Fields.Email.Length)]
        [ResourceEmail]
        public string Email { get; set; }

        [ResourceDisplayName(UserConstants.Fields.Password.Label)]
        [ResourceRequired]
        [ResourceStringLength(UserConstants.Fields.Password.Length)]
        public string Password { get; set; }

        [ResourceDisplayName(UserConstants.Fields.AdminComment.Label)]
        public string AdminComment { get; set; }
    }
}
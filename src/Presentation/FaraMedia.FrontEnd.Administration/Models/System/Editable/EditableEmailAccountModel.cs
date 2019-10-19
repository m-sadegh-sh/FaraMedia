namespace FaraMedia.FrontEnd.Administration.Models.Systematic.Editable {
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class EditableEmailAccountModel : EditableEntityModelBase {
        [ResourceDisplayName(EmailAccountConstants.Fields.SslEnabled.Label)]
        public bool SslEnabled { get; set; }

        [ResourceDisplayName(EmailAccountConstants.Fields.UseDefaultCredentials.Label)]
        public bool UseDefaultCredentials { get; set; }

        [ResourceDisplayName(EmailAccountConstants.Fields.Port.Label)]
        [ResourceMin(EmailAccountConstants.Fields.Port.MinValue)]
        public int Port { get; set; }

        [ResourceDisplayName(EmailAccountConstants.Fields.DisplayName.Label)]
        [ResourceStringLength(EmailAccountConstants.Fields.DisplayName.Length)]
        public string DisplayName { get; set; }

        [ResourceDisplayName(EmailAccountConstants.Fields.Email.Label)]
        [ResourceRequired]
        [ResourceStringLength(EmailAccountConstants.Fields.Email.Length)]
        [ResourceEmail]
        public string Email { get; set; }

        [ResourceDisplayName(EmailAccountConstants.Fields.Host.Label)]
        [ResourceRequired]
        [ResourceStringLength(EmailAccountConstants.Fields.Host.Length)]
        public string Host { get; set; }

        [ResourceDisplayName(EmailAccountConstants.Fields.UserName.Label)]
        [ResourceStringLength(EmailAccountConstants.Fields.UserName.Length)]
        public string UserName { get; set; }

        [ResourceDisplayName(EmailAccountConstants.Fields.Password.Label)]
        [ResourceStringLength(EmailAccountConstants.Fields.Password.Length)]
        public string Password { get; set; }
    }
}
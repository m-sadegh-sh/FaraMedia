namespace FaraMedia.Data.Mapping.Systematic {
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Data.Mapping.Shared;

	public sealed class EmailAccountMap : AttributeMapBase<EmailAccount> {
		public EmailAccountMap() {
			Property(ea => ea.Email);
			Property(ea => ea.UserName);
			Property(ea => ea.Password);
			Property(ea => ea.Host);
			Property(ea => ea.Port);
			Property(ea => ea.SslEnabled);
			Property(ea => ea.UseDefaultCredentials);
			Set(ea => ea.Templates);
			Set(ea => ea.Emails);
		}
	}
}
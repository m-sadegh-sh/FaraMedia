namespace FaraMedia.Data.Schemas.Configuration {
	using FaraMedia.Core.Domain.Configuration;
	using FaraMedia.Core.Infrastructure.Extensions;

	public sealed class SecuritySettingsConstants : ConstantsBase<SecuritySettings> {
		public sealed class Fields {
			public sealed class EncryptionKey {
				public const int Length = 160;

				public static readonly string Label = Helpers.Label<EncryptionKey>();
			}

			public sealed class AdminAreaAllowedIpAddress {
				public const int Length = Constants.IpAddressLength;

				public static readonly string Label = Helpers.Label<AdminAreaAllowedIpAddress>();
			}

			public sealed class HideLinksBasedOnPermissions {
				public static readonly string Label = Helpers.Label<HideLinksBasedOnPermissions>();
			}

			public sealed class UseSsl {
				public static readonly string Label = Helpers.Label<UseSsl>();
			}

			public sealed class MaxumimMinutesToDeleteGuestUsers {
				public const int MinValue = Constants.ZeroAllowedDigits;

				public static readonly string Label = Helpers.Label<MaxumimMinutesToDeleteGuestUsers>();
			}

			public sealed class OnlineUserMinutes {
				public const int MinValue = Constants.PositiveDigits;

				public static readonly string Label = Helpers.Label<OnlineUserMinutes>();
			}

			public sealed class RegistrationType {
				public static int MinValue = EnumExtensions.GetLowerBound<UserRegistrationType>();
				public static int MaxValue = EnumExtensions.GetUpperBound<UserRegistrationType>();

				public static readonly string Label = Helpers.Label<RegistrationType>();

				public static readonly string Standard = Helpers.Enum<RegistrationType, UserRegistrationType>(UserRegistrationType.Standard);
				public static readonly string EmailValidation = Helpers.Enum<RegistrationType, UserRegistrationType>(UserRegistrationType.EmailValidation);
				public static readonly string AdminApproval = Helpers.Enum<RegistrationType, UserRegistrationType>(UserRegistrationType.AdminApproval);
				public static readonly string Disabled = Helpers.Enum<RegistrationType, UserRegistrationType>(UserRegistrationType.Disabled);
			}

			public sealed class UserNamesEnabled {
				public static readonly string Label = Helpers.Label<UserNamesEnabled>();
			}

			public sealed class IllegalUserNameChars {
				public static readonly string Label = Helpers.Label<IllegalUserNameChars>();
			}

			public sealed class ScreenNameFormat {
				public static int MinValue = EnumExtensions.GetLowerBound<DisplayScreenNameFormat>();
				public static int MaxValue = EnumExtensions.GetUpperBound<DisplayScreenNameFormat>();

				public static readonly string Label = Helpers.Label<ScreenNameFormat>();

				public static readonly string Email = Helpers.Enum<ScreenNameFormat, DisplayScreenNameFormat>(DisplayScreenNameFormat.Email);
				public static readonly string UserName = Helpers.Enum<ScreenNameFormat, DisplayScreenNameFormat>(DisplayScreenNameFormat.UserName);
				public static readonly string FullName = Helpers.Enum<ScreenNameFormat, DisplayScreenNameFormat>(DisplayScreenNameFormat.FullName);
			}

			public sealed class PasswordMinLength {
				public const int MinValue = Constants.PositiveDigits;

				public static readonly string Label = Helpers.Label<PasswordMinLength>();
			}

			public sealed class RequiredPasswordChars {
				public static readonly string Label = Helpers.Label<RequiredPasswordChars>();
			}

			public sealed class HashAlgorithm {
				public static int MinValue = EnumExtensions.GetLowerBound<PasswordHashingAlgorithm>();
				public static int MaxValue = EnumExtensions.GetUpperBound<PasswordHashingAlgorithm>();

				public static readonly string Label = Helpers.Label<HashAlgorithm>();

				public static readonly string Sha1 = Helpers.Enum<HashAlgorithm, PasswordHashingAlgorithm>(PasswordHashingAlgorithm.Sha1);
				public static readonly string Md5 = Helpers.Enum<HashAlgorithm, PasswordHashingAlgorithm>(PasswordHashingAlgorithm.Md5);
			}

			public sealed class NewsletterEnabled {
				public static readonly string Label = Helpers.Label<NewsletterEnabled>();
			}

			public sealed class NotifyForNewUserRegistration {
				public static readonly string Label = Helpers.Label<NotifyForNewUserRegistration>();
			}

			public sealed class NotifyForNewComments {
				public static readonly string Label = Helpers.Label<NotifyForNewComments>();
			}
		}
	}
}
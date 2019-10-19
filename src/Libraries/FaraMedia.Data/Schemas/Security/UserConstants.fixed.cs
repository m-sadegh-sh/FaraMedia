namespace FaraMedia.Data.Schemas.Security {
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Core.Infrastructure.Extensions;

	public sealed class UserConstants : EntityConstantsBase<User> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(u => u.Id);
			public static readonly string BySystemName = Helpers.CacheKey(u => u.SystemName);
			public static readonly string ByEmail = Helpers.CacheKey(u => u.Email);
			public static readonly string ByUserName = Helpers.CacheKey(u => u.UserName);
		}

		public sealed class Messages {
			public static readonly string SearchEngine = Helpers.Key<Messages, string>(m => SearchEngine);
			public static readonly string AlreadyRegistered = Helpers.Key<Messages, string>(m => AlreadyRegistered);
			public static readonly string InvalidOldPassword = Helpers.Key<Messages, string>(m => InvalidOldPassword);
			public static readonly string UserNameDisabled = Helpers.Key<Messages, string>(m => UserNameDisabled);
			public static readonly string ChangingUserNameNotAllowed = Helpers.Key<Messages, string>(m => ChangingUserNameNotAllowed);
			public static readonly string DeletionSystemAccountNotAllowed = Helpers.Key<Messages, string>(m => DeletionSystemAccountNotAllowed);
			public static readonly string InvalidUserNameEmailOrPassword = Helpers.Key<Messages, string>(m => InvalidUserNameEmailOrPassword);
			public static readonly string InvalidUserNameOrEmail = Helpers.Key<Messages, string>(m => InvalidUserNameOrEmail);
			public static readonly string YourAccountIsNotValid = Helpers.Key<Messages, string>(m => YourAccountIsNotValid);
			public static readonly string YourAccountIsNotActivatedYet = Helpers.Key<Messages, string>(m => YourAccountIsNotActivatedYet);
			public static readonly string YourAccountWasBlocked = Helpers.Key<Messages, string>(m => YourAccountWasBlocked);
		}

		public new sealed class Fields : EntityConstantsBase<User> {
			public sealed class SystemName {
				public const int Length = Constants.SystemNameLength;

				public static readonly string Label = Helpers.Label<SystemName>();
			}

			public sealed class UserName {
				public const int Length = 30;

				public static readonly string Label = Helpers.Label<UserName>();
			}

			public sealed class Email {
				public const int Length = Constants.EmailLength;

				public static readonly string Label = Helpers.Label<Email>();
			}

			public sealed class Password {
				public const int Length = 60;

				public static readonly string Label = Helpers.Label<Password>();
			}

			public sealed class PasswordSalt {
				public const int Length = 80;
			}

			public sealed class PasswordFormat {
				public static int MinValue = EnumExtensions.GetLowerBound<PasswordStoringFormat>();
				public static int MaxValue = EnumExtensions.GetUpperBound<PasswordStoringFormat>();

				public static readonly string Label = Helpers.Label<PasswordFormat>();

				public static readonly string Clear = Helpers.Enum<PasswordFormat, PasswordStoringFormat>(PasswordStoringFormat.Clear);
				public static readonly string Hashed = Helpers.Enum<PasswordFormat, PasswordStoringFormat>(PasswordStoringFormat.Hashed);
				public static readonly string Encrypted = Helpers.Enum<PasswordFormat, PasswordStoringFormat>(PasswordStoringFormat.Encrypted);
			}

			public sealed class LastLoginDateUtc {
				public static readonly string Label = Helpers.Label<LastLoginDateUtc>();
			}

			public sealed class LastActivityDateUtc {
				public static readonly string Label = Helpers.Label<LastActivityDateUtc>();
			}

			public sealed class LastIpAddress {
				public const int Length = Constants.IpAddressLength;

				public static readonly string Label = Helpers.Label<LastIpAddress>();
			}

			public sealed class AdminComment {
				public static readonly string Label = Helpers.Label<AdminComment>();
			}

			public sealed class CurrentBlockReason {
				public static readonly string Label = Helpers.Label<CurrentBlockReason>();
			}

			public sealed class Roles {
				public static readonly string Label = Helpers.Label<Roles>();
			}

			public sealed class Activities {
				public static readonly string Label = Helpers.Label<Activities>();
			}

			public sealed class Logs {
				public static readonly string Label = Helpers.Label<Logs>();
			}

			public sealed class ToDos {
				public static readonly string Label = Helpers.Label<ToDos>();
			}

			public sealed class Tickets {
				public static readonly string Label = Helpers.Label<Tickets>();
			}

			public sealed class Responses {
				public static readonly string Label = Helpers.Label<Responses>();
			}

			public sealed class IncomingFriendRequests {
				public static readonly string Label = Helpers.Label<IncomingFriendRequests>();
			}

			public sealed class OutgoingFriendRequests {
				public static readonly string Label = Helpers.Label<OutgoingFriendRequests>();
			}

			public sealed class Blogs {
				public static readonly string Label = Helpers.Label<Blogs>();
			}

			public sealed class Orders {
				public static readonly string Label = Helpers.Label<Orders>();
			}

			public sealed class Likes {
				public static readonly string Label = Helpers.Label<Likes>();
			}

			public sealed class Shares {
				public static readonly string Label = Helpers.Label<Shares>();
			}

			public sealed class VotingRecords {
				public static readonly string Label = Helpers.Label<VotingRecords>();
			}
		}
	}
}
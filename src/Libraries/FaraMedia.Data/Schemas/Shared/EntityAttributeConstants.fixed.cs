namespace FaraMedia.Data.Schemas.Shared {
	using FaraMedia.Core.Domain.Shared;

	public sealed class EntityAttributeConstants : OwnableConstantsBase<EntityAttribute> {
		public sealed class Messages {
			public static readonly string NotSupportedValueType = Helpers.Key<Messages, string>(m => NotSupportedValueType);
			public static readonly string InvalidOwnerId = Helpers.Key<Messages, string>(m => InvalidOwnerId);
		}

		public new sealed class Fields : OwnableConstantsBase<EntityAttribute>.Fields {
			public sealed class Key {
				public const int Length = Constants.SystemNameLength;

				public static readonly string Label = Helpers.Label<Key>();
			}

			public sealed class DisplayName {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<DisplayName>();
			}

			public sealed class Value {
				public static readonly string Label = Helpers.Label<Value>();
			}

			public sealed class Description {
				public static readonly string Label = Helpers.Label<Description>();
			}
		}
	}
}
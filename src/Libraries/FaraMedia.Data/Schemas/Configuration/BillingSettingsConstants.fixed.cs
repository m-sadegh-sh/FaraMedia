namespace FaraMedia.Data.Schemas.Configuration {
	using FaraMedia.Core.Domain.Configuration;
	using FaraMedia.Core.Infrastructure.Extensions;

	public sealed class BillingSettingsConstants : ConstantsBase<BillingSettings> {
		public sealed class Messages {
			public static readonly string PricePerTrackShouldNotBeGreaterThanPricePerAlbum = Helpers.Key<Messages, string>(m => PricePerTrackShouldNotBeGreaterThanPricePerAlbum);
		}

		public sealed class Fields {
			public sealed class PricePerTrack {
				public const int MinValue = Constants.ZeroAllowedDigits;

				public static readonly string Label = Helpers.Label<PricePerTrack>();
			}

			public sealed class PublisherPercentagePerTrack {
				public const int MinValue = Constants.ZeroAllowedDigits;
				public const int MaxValue = 100;

				public static readonly string Label = Helpers.Label<PublisherPercentagePerTrack>();
			}

			public sealed class PricePerAlbum {
				public const int MinValue = Constants.ZeroAllowedDigits;

				public static readonly string Label = Helpers.Label<PricePerAlbum>();
			}

			public sealed class PublisherPercentagePerAlbum {
				public const int MinValue = Constants.ZeroAllowedDigits;
				public const int MaxValue = 100;

				public static readonly string Label = Helpers.Label<PublisherPercentagePerAlbum>();
			}

			public sealed class MaximumAccessTries {
				public static readonly string Label = Helpers.Label<MaximumAccessTries>();
			}

			public sealed class TaxPayer {
				public static int MinValue = EnumExtensions.GetLowerBound<TaxPayType>();
				public static int MaxValue = EnumExtensions.GetUpperBound<TaxPayType>();

				public static readonly string Label = Helpers.Label<TaxPayType>();

				public static readonly string Publisher = Helpers.Enum<TaxPayer, TaxPayType>(TaxPayType.Publisher);
				public static readonly string User = Helpers.Enum<TaxPayer, TaxPayType>(TaxPayType.User);
			}

			public sealed class MerchantId {
				public static readonly string Label = Helpers.Label<MerchantId>();
			}

			public sealed class TransactionKey {
				public static readonly string Label = Helpers.Label<TransactionKey>();
			}
		}
	}
}